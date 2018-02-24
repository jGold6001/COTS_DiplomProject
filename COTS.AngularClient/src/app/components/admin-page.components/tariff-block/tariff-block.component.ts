import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tariff-block',
  templateUrl: './tariff-block.component.html',
  styleUrls: ['./tariff-block.component.css']
})
export class TariffBlockComponent implements OnInit {

  enableList: boolean;
  typesOfShoes = ['Tariff_1','Tariff_2','Tariff_3'];

  constructor() { }

  ngOnInit() {
  }

}
