import { Component, OnInit, Input } from '@angular/core';
import { City } from '../shared/models/city.model';
import { Cinema } from '../shared/models/cinema.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cinemas-cards',
  templateUrl: './cinemas-cards.component.html',
  styleUrls: ['./cinemas-cards.component.css']
})
export class CinemasCardsComponent implements OnInit {

  @Input() cinema: Cinema;
  @Input() city: City;

  constructor(private router: Router) { }

  ngOnInit() {

  }

  private fixExceptionCityId(): string{
    let cityId: string;
    try {
      cityId = this.city.id;
    } catch (ex) {}
    return cityId;
  }

  goToCinemaUrl(){
    this.router.navigate([this.city.id, "cinema", this.cinema.id]);
  }
}
