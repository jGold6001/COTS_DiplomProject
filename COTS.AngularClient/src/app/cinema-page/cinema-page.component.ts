import { Component, OnInit } from '@angular/core';
import { CinemaService } from '../shared/services/cinema.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cinema } from '../shared/models/cinema.model';

@Component({
  selector: 'app-cinema-page',
  templateUrl: './cinema-page.component.html',
  styleUrls: ['./cinema-page.component.css']
})
export class CinemaPageComponent implements OnInit {

  id: string;
  cinema: Cinema;

  lat: number;
  lng: number;
  zoom: number = 11;
  
  constructor(
    private route: ActivatedRoute,
    private cinemaService: CinemaService,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.cinemaService.getOne(this.id)
    .subscribe(r =>{
      this.cinema = r;
    } , () => console.error("Ошибка при получении данных с сервера"));

    this.lat = 50.4244724;
    this.lng = 30.4856598;

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

  get _cinemaImage(): string{
    let value: string;
    try {
      value = this.cinema.imagePath;
    } catch (ex) {}
    return value;
  }
}
