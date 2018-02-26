import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Ticket } from '../../../shared/models/ticket.model';

@Component({
  selector: 'app-purchase-block',
  templateUrl: './purchase-block.component.html',
  styleUrls: ['./purchase-block.component.css']
})
export class PurchaseBlockComponent implements OnInit {

  clientControl = new FormControl();
  enableList: boolean;

  tickets: any[] = [];

  constructor() { }

  ngOnInit() {
    this.enableList = false;

    let t_1: any = {
      num: "0001",
      row: 1,
      seat:2,
      price: 100,
      sector: "Good"
    };
    this.tickets.push(t_1);

    let t_2: any = {
      num: "0002",
      row: 1,
      seat:3,
      price: 100,
      sector: "Good"
    };
    this.tickets.push(t_2);

  }

}
