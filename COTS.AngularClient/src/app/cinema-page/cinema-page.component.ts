import { Component, OnInit} from '@angular/core';
import { CinemaService } from '../shared/services/cinema.service';
import { Router, ActivatedRoute, UrlTree, UrlSegmentGroup, UrlSegment, PRIMARY_OUTLET } from '@angular/router';
import { Cinema } from '../shared/models/cinema.model';
import { GeocodingApiService } from '../shared/services/geocodingApi.service';
import { City } from '../shared/models/city.model';

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
    private geocodingAPIService: GeocodingApiService,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.cinemaService.getOne(this.id)
    .subscribe(r =>{
      this.cinema = r;
      this.updateLatLngFromAdress();
    } , () => console.error("Ошибка при получении данных с сервера"));

  }

  private updateLatLngFromAdress(){
    this.geocodingAPIService
    .findFromAddress(this.cinema.address, this.cityId)
    .subscribe(response => {
        if (response.status == 'OK') {
            this.lat = response.results[0].geometry.location.lat;
            this.lng = response.results[0].geometry.location.lng;
        } else if (response.status == 'ZERO_RESULTS') {
            console.log('geocodingAPIService', 'ZERO_RESULTS', response.status);
        } else {
            console.log('geocodingAPIService', 'Other error', response.status);
        }
    });
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

  get cityId(): string{
    const tree: UrlTree = this.router.parseUrl( this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    return s[0].path;
  }
}
