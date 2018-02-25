import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-purchase-block',
  templateUrl: './purchase-block.component.html',
  styleUrls: ['./purchase-block.component.css']
})
export class PurchaseBlockComponent implements OnInit {

  clientControl = new FormControl();

  constructor() { }

  ngOnInit() {
  }

}
