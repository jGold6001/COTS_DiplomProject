import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class GeocodingApiService {
    API_KEY: string;
    API_URL: string;

    constructor(private http: Http) {
        this.API_KEY = 'AIzaSyDSg-Iu6aNGRmrVX6MMltecTCslVEDUqPo';
        this.API_URL = `https://maps.googleapis.com/maps/api/geocode/json?key=${this.API_KEY}&address=`;
    }

    findFromAddress(address: string, place?: string): Observable<any> {
        let compositeAddress = [address];

        if (place) compositeAddress.push(place);
    
        let url = `${this.API_URL}${compositeAddress.join(',')}`;

        return this.http.get(url).map(response => <any> response.json());
    }

    findFromCity(city: string) : Observable<any>{
        let url = `${this.API_URL}${city}`;
        return this.http.get(url).map(response => <any> response.json());;
    }
}