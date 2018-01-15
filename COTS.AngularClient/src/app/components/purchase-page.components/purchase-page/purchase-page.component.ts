import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { TicketService } from '../../../shared/services/ticket.service';
import { Observable } from 'rxjs';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Seance } from '../../../shared/models/seance.model';


@Component({
  selector: 'app-purchase-page',
  templateUrl: './purchase-page.component.html',
  styleUrls: ['./purchase-page.component.css']
})
export class PurchasePageComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] =[];

  seance: Seance = new Seance();
  movie: Movie = new Movie();
  cinema: Cinema= new Cinema();

  constructor(
   private route: ActivatedRoute,
   private ticketService: TicketService
  ) 
  {}

  ngOnInit() {
   
    this.ticketService.getPurchase("test231243")
      .subscribe(data => {
        this.purchase = data;
        this.tickets = this.purchase.tickets;

        let ticketObj = this.tickets[0];
        this.movie = ticketObj.movie;
        this.cinema = ticketObj.cinema;
        
        //this.seance.init(ticketObj .seanceId, ticketObj.);
        
      }, () => console.error("Ошибка при получении данных с сервера"));
  }

  get purchaseId(): string{ 
    let id;
    this.route.params.subscribe(params => {
      id =  params['id'];  
    });
    return id;
  }

}
