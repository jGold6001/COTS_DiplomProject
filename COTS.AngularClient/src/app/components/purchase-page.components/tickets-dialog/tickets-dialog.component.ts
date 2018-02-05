import { Component, OnInit, Input, Inject } from '@angular/core';
import { Purchase } from '../../../shared/models/purchase.model';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Ticket } from '../../../shared/models/ticket.model';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Seance } from '../../../shared/models/seance.model';
import { Hall } from '../../../shared/models/hall.model';
import { Tariff } from '../../../shared/models/tariff.model';
import { Customer } from '../../../shared/models/customer.model';

@Component({
  selector: 'app-tickets-dialog',
  templateUrl: './tickets-dialog.component.html',
  styleUrls: ['./tickets-dialog.component.css']
})
export class TicketsDialogComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] = [];
  movie: Movie;
  cinema: Cinema;
  seance: Seance;
  hall: Hall;
  tariffs: any[] = [];
  

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.purchase = this.data.purchase;  
    this.tickets = this.purchase.tickets;
    this.tariffs = this.createSpesialTariffs();
    

    this.seance = this.tickets[0].seance;
    this.movie = this.seance.movie;
    this.hall =  this.seance.hall;
    this.cinema = this.hall.cinema;
    
  }

  private createSpesialTariffs(): any[]{
    let _tariffs: any[] = [];
    for(let item of this.tickets){
        let _tariff= {
          ticketId: item.id,
          name: item.tariff.name.split("_", 4)[2].toUpperCase(),
          price: item.tariff.price
        }
        _tariffs.push(_tariff);
    }
    return _tariffs;
  }

  getTariff(ticketId: string){
    return this.tariffs.find(t => t.ticketId == ticketId);
  }

  

}
