import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-seance-block',
  templateUrl: './seance-block.component.html',
  styleUrls: ['./seance-block.component.css']
})
export class SeanceBlockComponent implements OnInit {

  typesOfShoes = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
  enableList: boolean;

  constructor() { }

  ngOnInit() {
    this.enableList = false;
  }

}
