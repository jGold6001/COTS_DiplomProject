import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { TicketService } from '../../../shared/services/ticket.service';
import { Observable } from 'rxjs';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';


@Component({
  selector: 'app-purchase-page',
  templateUrl: './purchase-page.component.html',
  styleUrls: ['./purchase-page.component.css']
})
export class PurchasePageComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] =[];
  movie: Movie = new Movie();
  cinema: Cinema;
 
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
        this.movie = this.tickets[0].movie;
        this.cinema = this.tickets[0].cinema;
      });
  }

  get purchaseId(): string{ 
    let id;
    this.route.params.subscribe(params => {
      id =  params['id'];  
    });
    return id;
  }

}
