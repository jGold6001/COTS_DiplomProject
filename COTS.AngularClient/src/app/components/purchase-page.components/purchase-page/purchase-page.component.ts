import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';


@Component({
  selector: 'app-purchase-page',
  templateUrl: './purchase-page.component.html',
  styleUrls: ['./purchase-page.component.css']
})
export class PurchasePageComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] =[];
 
  constructor(
   private route: ActivatedRoute
  ) 
  {}

  ngOnInit() {
    
  }

}
