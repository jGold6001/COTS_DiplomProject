import { Component, OnInit, Input,Output, ElementRef, NgZone, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import {  } from 'googlemaps';
import { MapsAPILoader} from '@agm/core';
import { google } from '@agm/core/services/google-maps-types';
import { AgmMap } from '@agm/core/directives/map';
import { GeocodingApiService } from '../shared/services/geocodingApi.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Cinema } from '../shared/models/cinema.model';
import { City } from    '../shared/models/city.model';
import { CityService } from '../shared/services/city.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cinemas-map',
  templateUrl: './cinemas-map.component.html',
  styleUrls: ['./cinemas-map.component.css']
})
export class CinemasMapComponent implements OnInit, OnChanges {

  @Input() city: City;
  @Input() cinemas: Cinema[]=[];

  lat: number;
  lng: number;
  zoom: number = 11;
  markers: marker[] =[];

  constructor(
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone,
    private geocodingAPIService: GeocodingApiService,
    private router: Router
  ) {}

  ngOnInit() {
    this.updateLatLngFromCity();
    this.createMarkers(); 
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['city']) {
        this.updateLatLngFromCity();
    }
    if(changes['cinemas']){
        this.createMarkers();
    } 
    
  }

  updateLatLngFromCity() {  
    this.geocodingAPIService
        .findFromCity(this.fixExceptionCityName())
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

  createMarkers(){
    for(let cinema of this.cinemas){
        if(cinema.cityId == this.city.id)
        this.geocodingAPIService
        .findFromAddress(cinema.address, this.fixExceptionCityName())
        .subscribe(response => {
            if (response.status == 'OK') {
                let _lat = response.results[0].geometry.location.lat;
                let _lng = response.results[0].geometry.location.lng;
                let _marker = {
                    lat: _lat,
                    lng: _lng,
                    label: cinema.name,
                    draggable: false,
                    cinemaId: cinema.id
                };
                this.markers.push(_marker);
                
            } else if (response.status == 'ZERO_RESULTS') {
                console.log('geocodingAPIService', 'ZERO_RESULTS', response.status);
            } else {
                console.log('geocodingAPIService', 'Other error', response.status);
            }
        });
    }
  }

  updateLatLngFromAdress(cinema: Cinema) {
    this.geocodingAPIService
        .findFromAddress(cinema.address, this.city.name)
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

  clickedMarker(cinemaId: string) {
    this.router.navigate([this.city.id, "cinema", cinemaId]);
  }

  private fixExceptionCityName(): string{
    let cityName: string;
    try {
        cityName = this.city.name;
    } catch (ex) {}
    return cityName;
  }

}

interface marker {
	lat: number;
	lng: number;
	label?: string;
    draggable: boolean;
    cinemaId: string;
}
