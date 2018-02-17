import { Component, OnInit, Inject, Input, ElementRef, Renderer2, ViewChild, ViewContainerRef, ComponentRef, ComponentFactoryResolver} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Seance } from '../../../shared/models/seance.model';
import { DomService } from '../../../shared/services/dom.service';
import { HallMappings } from '../../../shared/mappings-consts/halls.mappings';
import { DataService } from '../../../shared/services/data.service';
import { Router } from '@angular/router';
import { Place } from '../../../shared/models/place.model';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { PurchasePageComponent } from '../../purchase-page.components/purchase-page/purchase-page.component';
import { setTimeout } from 'timers';
import { PurchaseService } from '../../../shared/services/purchase.service';
import { City } from '../../../shared/models/city.model';

import {serialize} from 'json-typescript-mapper';
import { SeanceService } from '../../../shared/services/seance.service';
import { loadavg, constants } from 'os';
import { element } from 'protractor';
import { Tariff } from '../../../shared/models/tariff.model';
import { Movie } from '../../../shared/models/movie.model';
import { Hall } from '../../../shared/models/hall.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Sector } from '../../../shared/models/sector.model';
import { SectorService } from '../../../shared/services/sector.service';


@Component({
  selector: 'app-hall-dialog',
  templateUrl: './hall-dialog.component.html',
  styleUrls: ['./hall-dialog.component.css']
})

export class HallDialogComponent implements OnInit {

  @ViewChild('hallcomponent', { read: ViewContainerRef })
    
  container: ViewContainerRef;
  componentRef: ComponentRef<{}>;

  seance: Seance;
  movie: Movie;
  hall: Hall;
  cinema: Cinema;

  places: Place[] = [];
  tickets: Ticket[] =[];
  purchase: Purchase;
  show: boolean = false;
  sum: number = 0;
  tariffs: Tariff[] = [];
  sectors: Sector[] = [];


  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService,
    private dataService: DataService,
    private purchaseService: PurchaseService,
    private sectorService: SectorService,
    private seanceService: SeanceService,
    private router: Router,
    private rd: Renderer2,
    private elRef:ElementRef
  )
  { }

  ngOnInit() {

    this.seanceService.getOne(this.data.seanceId).subscribe( seance => 
      {
        this.seance = seance;
        this.movie = this.seance.movie;
        this.hall = this.seance.hall;
        this.cinema = this.hall.cinema;
        
        this.sectors = this.data.sectors;            

        let typeInfo = this.seance.hall.name;
      
        let componentType = this.getComponentType(typeInfo);
        let factory = this.domService.createFactory(componentType);    
        let componentRef = this.container.createComponent(factory); 

        let dataInfo = {
            city: this.cinema.cityId,
            cinema: this.cinema.id,
            hall: this.hall.name,
            seance: this.seance.id
        };
        (componentRef.instance).data = dataInfo;

        this.tariffs = this.seance.tariffs; 
        this.createSectorTariffs();
        
        this.dataService.placesSelected$.subscribe(place => this.createTicket(place));
        this.dataService.placesCanceles$.subscribe(place => this.cancelTicket(place));
       
      }
    );
     
  }

  setSectorColor(sectorId: number): string {
    let sector = this.sectors.find(s => s.id == sectorId);
    let sectorName = sector.name.toLowerCase();
    if(sectorName.includes(" "))
        sectorName = sectorName.replace(" ", "_");

    return `${sectorName}-sector`;
  }

  createSectorTariffs(){
    let root = this.elRef.nativeElement.querySelector(`#sectors_tariffs`);
    let outerContainer = this.createDivClass("container");
    let outerRow = this.createDivClass("row");

    this.rd.appendChild(root, outerContainer);
    this.rd.appendChild(outerContainer, outerRow);

    //prices of sectors
    for(let item of this.tariffs){
      this.createColorSquare(outerRow, this.setSectorColor(item.sectorId), `${item.price} грн.`);    
    }

    //busy places
    this.createColorSquare(outerRow, "busy-sector", `Недоступные`);

    //selected places
    this.createColorSquare(outerRow, "selected-sector", `Выбранные`);

  }

  createColorSquare(outerRow: any, colorClass: string, text: string){
      let outerCol = this.rd.createElement('div');    
      this.rd.addClass(outerCol, "col");                                    

      let sector = this.rd.createElement('div');
      this.rd.addClass(sector, "sector_squre_style");
      this.rd.addClass(sector, colorClass);       

      let spanText = this.createSpanText(text);      
      
      this.rd.appendChild(outerRow, outerCol);
      this.rd.appendChild(outerCol, sector);
      this.rd.appendChild(sector, spanText);
  }


  goToPayment(){
    //create purchase
    let _idPurchase: string = this.zeroPad(this.getRandomInt(1,10000),5);  
    let purchase = {
      Id: _idPurchase,
      Sum: this.sum,
      TicketViewModels: []
    };
   
    //create tickets
    for(let place of this.places){ 

      let tariff = this.tariffs.find(t => t.sectorId == place.sectorId);
      let TicketViewModel = {
        Id: this.zeroPad(this.getRandomInt(1,100000),6),
        PurchaseId: _idPurchase,
        State: 1,
        SeanceId: this.seance.id,
        PlaceId: place.id, 
        TariffId:  tariff.id  
      };     
      purchase.TicketViewModels.push(TicketViewModel);
    } 
    


    //post to server
    this.purchaseService.saveInDb(purchase);

    //go to purchase
    setTimeout(() => {
      this.router.navigate(["purchase", _idPurchase]);
      this.dialogRef.close();
    }, 2000)
  
  }

  private addPlaceRow(place: Place, tariff: Tariff){  
    let container = this.createRowContainerRow(place.id);
    let row =  this.createDivClass('row');
    
    this.setColText(row,`Ряд: ${place.row}`, 'col-lg-4', 'col-md-4');
    this.setColText(row,`Место: ${place.num}`, 'col-lg-4', 'col-md-4');
    this.setColText(row,`${tariff.price} грн.`, 'col-lg-2', 'col-md-2');
    this.setBtnDelete(row, place);

    this.rd.appendChild(container, row);
  }

  private setColText(rootDiv, text: string, className_lg, className_md){
    let div = this.rd.createElement('div');
    this.rd.addClass(div, className_lg);
    this.rd.addClass(div, className_md);
    let span = this.createSpanText(text);
    this.rd.appendChild(rootDiv, div);
    this.rd.appendChild(div, span);
  }

  private setBtnDelete(row, place: Place){
    let div = this.rd.createElement('div');
    this.rd.addClass(div, 'col-lg-2');
    this.rd.addClass(div, 'col-md-2');

    let button = this.rd.createElement('button');
    this.rd.addClass(button, 'btn');
    this.rd.addClass(button, 'button-margin');
    this.rd.setAttribute(button, 'id', `place_${place.id}`);
    let x = this.rd.createText("Отмена");
    this.rd.listen(button, 'click', ()=>
    {
      this.cancelTicket(place);
      this.dataService.removePlace(place);
    });

    this.rd.appendChild(row, div);
    this.rd.appendChild(div, button);
    this.rd.appendChild(button, x);   
  }

  cancelTicket(place: Place){
    let tariff = this.tariffs.filter(t=>{ return t.sectorId == place.sectorId })[0];
    this.removePlaceRow(place.id);
    this.deleteObjectFromArray(place.id);
    this.disablePayButton();
    this.sum -=tariff.price;
  }

  createTicket(place: Place){
    let tariff = this.tariffs.filter(t=>{ return t.sectorId == place.sectorId })[0];
    this.places.push(place);
    this.addPlaceRow(place, tariff);  
    this.enablePayButton();
    this.sum += tariff.price;    
  }


  private removePlaceRow(placeId : number){
    let placeContainer = this.elRef.nativeElement.querySelector('#selected_places');
    let placeIdDiv = this.elRef.nativeElement.querySelector(`#place_${placeId}`);
    this.rd.removeChild(placeContainer, placeIdDiv);    
  }

  private getComponentType(hall: any) {
    return HallMappings.hall[hall];
  }

  private getRandomInt(min, max): number {
    return Math.floor(Math.random() * (max - min)) + min;
  }

  private zeroPad(num, places) {
    var zero = places - num.toString().length + 1;
    return Array(+(zero > 0 && zero)).join("0") + num;
  }

  private createRowContainerRow(placeId: number){
    let placeContainer = this.elRef.nativeElement.querySelector('#selected_places');

    let divPlace = this.createDivId(`place_${placeId}`);
    this.rd.addClass(divPlace, "light-grey-border");
    let divContainer = this.createDivClass('container');
    let divRowOuter = this.createDivClass('row');
    
    this.rd.appendChild(placeContainer, divPlace);
    this.rd.appendChild(divPlace, divRowOuter);
    this.rd.appendChild(divRowOuter, divContainer)
    
    return divContainer;
  }
  

  private createDivClass(className: string){
    let div = this.rd.createElement('div');
    this.rd.addClass(div, className);
    return div;
  }

  private createDivId(idName: string){
    let div = this.rd.createElement('div');
    this.rd.setAttribute(div, 'id', idName);
    return div;
  }

  private createSpanText(text: string){
    let span = this.rd.createElement('span');
    let _text = this.rd.createText(text);
    this.rd.appendChild(span, _text);
    return span;
  }

  private deleteObjectFromArray(id){
    for(let place of this.places){
      if(place.id == id)
        this.places.splice(this.places.indexOf(place),1);
    }
  }

  private enablePayButton(){
    if(this.places.length > 0)
          this.show = true;
  }

  private disablePayButton(){
    if(this.places.length == 0)
        this.show = false
  }

  private getBusiesPlaces(): Place[]{
    let ticketsWithSeance = this.tickets.filter( (element, index, array) =>{
        if(element.seance.id  == this.seance.id)
          return element.seance;
    });
    let places = ticketsWithSeance.map( ticket =>{
        return ticket.place;
    });
    return places;
  }

 

}