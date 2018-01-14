import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { TicketService } from '../../../shared/services/ticket.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-purchase-page',
  templateUrl: './purchase-page.component.html',
  styleUrls: ['./purchase-page.component.css']
})
export class PurchasePageComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] =[];
 
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
