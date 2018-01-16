import { Component, OnInit, Input, Inject } from '@angular/core';
import { Purchase } from '../../../shared/models/purchase.model';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-tickets-dialog',
  templateUrl: './tickets-dialog.component.html',
  styleUrls: ['./tickets-dialog.component.css']
})
export class TicketsDialogComponent implements OnInit {

  purchase: Purchase;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.purchase = this.data.purchase;
  }

}
