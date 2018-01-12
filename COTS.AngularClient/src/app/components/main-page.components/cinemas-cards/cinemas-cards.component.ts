import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Cinema } from '../../../shared/models/cinema.model';
import { City } from '../../../shared/models/city.model';

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
