import { Component, OnInit, Input } from '@angular/core';
import { Cinema } from '../shared/models/cinema.model';

@Component({
  selector: 'app-cinemas-list',
  templateUrl: './cinemas-list.component.html',
  styleUrls: ['./cinemas-list.component.css']
})
export class CinemasListComponent implements OnInit {

  @Input() cinema: Cinema;

  constructor(
    
  ) { }

  ngOnInit() {
    
  }

  get _cinemaName(): string{
    let value: string;
    try {
      value = this.cinema.name;
    } catch (ex) {}
    return value;
  }

  get _cinemaAddress(): string{
    let value: string;
    try {
      value = this.cinema.address;
    } catch (ex) {}
    return value;
  }


}
