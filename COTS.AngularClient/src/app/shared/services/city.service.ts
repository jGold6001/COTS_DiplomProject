import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import {City} from "../models/city.model";
import { environment } from "../../../environments/environment";
import { Movie } from "../models/movie.model";



@Injectable()
export class CityService{


    constructor(
        private http: Http   
    ) {}

    
    getAll(): Observable<City[]>{
        return this.http.get(environment.APIURL_CITIES)
            .map(response => {
                return this.convertJsonToArray(response.json());
            });
    }

    private convertJsonToArray(data): City[]{
        let cities: City[] = [];
        for (let i = 0; i < data.length; i++){
            let city: City= new City(); 
            city.id = data[i].Id; 
            city.name = data[i].Name
            cities.push(city);
        }
        return cities;
    }

}