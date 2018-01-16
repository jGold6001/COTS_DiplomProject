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
import { TicketService } from '../../../shared/services/ticket.service';
import { setTimeout } from 'timers';




@Component({
  selector: 'app-hall-dialog',
  templateUrl: './hall-dialog.component.html',
  styleUrls: ['./hall-dialog.component.css']
})

export class HallDialogComponent implements OnInit {

  @ViewChild('container', { read: ViewContainerRef })
    
  container: ViewContainerRef;
  componentRef: ComponentRef<{}>;

  seance: Seance;
  places: Place[] = [];
  tickets: Ticket[] =[];
  purchase: Purchase;
  show: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService,
    private dataService: DataService,
    private ticketService: TicketService,
    private router: Router
  )
  { }

  ngOnInit() {
    this.seance = this.data.seance;

    let typeInfo = {
      city:    "kiev",              //this.seance.cinema.cityId,
      cinema:   "mpx_skymall",      //this.seance.cinema.id,
      hall:     "1"                //this.seance.hall
    };

    let componentType = this.getComponentType(typeInfo);
    let factory = this.domService.createFactory(componentType);
    this.componentRef = this.container.createComponent(factory);


    this.dataService.placesSelected$.subscribe( place =>
      {
        this.places.push(place);
        this.show = true;
      }
    );
  }


  goToPayment(){

    //create purchase
    this.purchase = new Purchase();
    let _idPurchase: string = this.zeroPad(this.getRandomInt(1,10000),5);  
    this.purchase.id = _idPurchase;

    //create tickets
    for(let place of this.places){ 

      let bokingState: number = 1;
      let _idTicket: string = this.zeroPad(this.getRandomInt(1,100000),6); 

      let ticket: Ticket = new Ticket();
      ticket.init(_idTicket, 
        place.num,
        place.row,
        place.tariff,
        place.price, 
        _idPurchase,
        bokingState);
      this.tickets.push(ticket);
      ticket.seanceId = this.seance.id;
    } 
    this.purchase.tickets = this.tickets;
    
    //post to server
    //this.ticketService.saveInDb(this.purchase);

    //go to purchase
    setTimeout(() => {
      this.router.navigate(["purchase", _idPurchase]);
      this.dialogRef.close();
    }, 2000)
  
  }

 

  onNoClick(): void {
    this.dialogRef.close();
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


}