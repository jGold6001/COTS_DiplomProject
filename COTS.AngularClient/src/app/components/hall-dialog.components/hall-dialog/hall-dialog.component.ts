import { Component, OnInit, Inject, Input, ElementRef, Renderer2, ViewChild, ViewContainerRef, ComponentRef, ComponentFactoryResolver} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Seance } from '../../../shared/models/seance.model';
import { DomService } from '../../../shared/services/dom.service';
import { CitiesMappings } from '../../../shared/mappings-consts/cities/cities.mappings';
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
import { loadavg } from 'os';
import { element } from 'protractor';
import { Tariff } from '../../../shared/models/tariff.model';
import { Movie } from '../../../shared/models/movie.model';
import { Hall } from '../../../shared/models/hall.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { FlorenceHallBlueComponent } from '../halls-components/kiev/florence/florence-hall-blue/florence-hall-blue.component';


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


  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService,
    private dataService: DataService,
    private purchaseService: PurchaseService,
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

        
        let typeInfo = {
          city:     "kiev",              //this.seance.cinema.cityId,
          cinema:   "florence",      //this.seance.hall.cinema.id,
          hall:     "Синий"                //this.seance.hall
        };
      
        let componentType = this.getComponentType(typeInfo);
        let factory = this.domService.createFactory(componentType);    
        let componentRef = this.container.createComponent(factory);        
        (componentRef.instance).seanceId = this.seance.id;  
        this.tariffs = this.seance.tariffs; 
        
        this.createSectorTariffs();
        
        this.dataService.placesSelected$.subscribe( place =>
          {                              
              let tariff = this.tariffs.filter(t=>{ return t.sectorId == place.sectorId })[0];
              this.places.push(place);
              this.addPlaceRow(place, tariff);  
              this.enablePayButton();
              this.sum += tariff.price;           
          }
        );

        this.dataService.placesCanceles$.subscribe(place =>
          {          
            let tariff = this.tariffs.filter(t=>{ return t.sectorId == place.sectorId })[0];
            this.removePlaceRow(place.id);
            this.deleteObjectFromArray(place.id);
            this.disablePayButton();
            this.sum -=tariff.price;
          }
        );
       
      }
    );
     
  }

  setSectorColor(sectorId: number): string {
    switch(sectorId){
      case 1: return "green-sector";
      case 2: return "red-sector";
    }
  }

  createSectorTariffs(){
    let root = this.elRef.nativeElement.querySelector(`#sectors_tariffs`);
    let outerContainer = this.createDivClass("container");
    let outerRow = this.createDivClass("row");

    this.rd.appendChild(root, outerContainer);
    this.rd.appendChild(outerContainer, outerRow);

    for(let item of this.tariffs){
        let outerCol = this.rd.createElement('div');       
        this.rd.addClass(outerCol, "col-lg-2");
        this.rd.addClass(outerCol, "col-md-4");
        this.rd.addClass(outerCol, "col-6");        
        //let colLgSix = this.createDivClass("col-lg-6");
        let innerContainer = this.createDivClass("container");
        let innerRow = this.createDivClass("row");

        let innerColColor =  this.rd.createElement('div');
        this.rd.addClass(innerColColor, "col-lg-4");
        this.rd.addClass(innerColColor, "col-md-2");
        this.rd.addClass(innerColColor, "col-4");    
        //let colLgFour = this.createDivClass("col-lg-4");

        let innerColPrice = this.rd.createElement('div');        
        this.rd.addClass(innerColPrice, "col-lg-8");
        this.rd.addClass(innerColPrice, "col-md-10");
        this.rd.addClass(innerColPrice, "col-8");    
        
        //let colLgEight = this.createDivClass("col-lg-8");
        let spanText = this.createSpanText(`${item.price} грн.`);

        this.rd.appendChild(outerRow, outerCol);

        this.rd.appendChild(outerCol, innerContainer);
        this.rd.appendChild(innerContainer, innerRow);

        this.rd.appendChild(innerRow, innerColColor);
        this.rd.addClass(innerColColor, "sector_squre_style");
        this.rd.addClass(innerColColor, this.setSectorColor(item.sectorId));

        this.rd.appendChild(innerRow, innerColPrice);
        this.rd.appendChild(innerColPrice, spanText);
    }
  }


  goToPayment(){
    //create purchase
    let _idPurchase: string = this.zeroPad(this.getRandomInt(1,10000),5);  
    let purchase = {
      Id: _idPurchase,
      TicketViewModels: []
    };
   
    //create tickets
    for(let place of this.places){ 
       //let tariff = this.tariffs.find(t => t.sector == place.sector);
      let TicketViewModel = {
        Id: this.zeroPad(this.getRandomInt(1,100000),6),
        PurchaseId: _idPurchase,
        State: 1,
        SeanceId: this.seance.id,
        PlaceId: place.id, 
        //TariffId:  tariff.id;   
      };     
      purchase.TicketViewModels.push(TicketViewModel);
      //purchase.sum = this.sum;
    } 
    
    //post to server
    this.purchaseService.saveInDb(purchase);

    //go to purchase
    setTimeout(() => {
      this.router.navigate(["purchase", _idPurchase]);
      this.dialogRef.close();
    }, 2000)
  
  }


  onNoClick(): void {
    this.dialogRef.close();
  }

  private addPlaceRow(place: Place, tariff: Tariff){  
    let container = this.createRowContainerRow(place.id);
    this.setText(container,`Ряд: ${place.row}`);
    this.setText(container,`Место: ${place.num}`);   
    this.setText(container,`Цена: ${tariff.price}`); 
  }

  private removePlaceRow(placeId : number){
    let placeContainer = this.elRef.nativeElement.querySelector('#selected_places');
    let placeIdDiv = this.elRef.nativeElement.querySelector(`#place_${placeId}`);
    this.rd.removeChild(placeContainer, placeIdDiv);
    
  }

  private getComponentType(typeInfo: any) {
    return CitiesMappings.city[typeInfo.city].cinema[typeInfo.cinema].hall[typeInfo.hall];
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
    let divContainer = this.createDivClass('container');
    let divRowOuter = this.createDivClass('row');
    let divRowInner = this.createDivClass('row');
    this.rd.appendChild(divContainer, divRowInner);
    this.rd.appendChild(divRowOuter, divContainer)
    this.rd.appendChild(divPlace, divRowOuter);
    this.rd.appendChild(placeContainer, divPlace);
    return divRowInner;
  }

  private setText(divContainer, text: string){
    let divCol = this.createDivClass('col-4');
    let span = this.createSpanText(text);
    this.rd.appendChild(divCol, span);
    this.rd.appendChild(divContainer, divCol)
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