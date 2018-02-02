import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Http, Response,Headers } from "@angular/http";
import { Place } from "../models/place.model";
import { JsonConvertor } from "../utils/json.convertor";
import { environment } from "../../../environments/environment";

@Injectable()
export class PlaceService{

    constructor(private http: Http){

    }

    getPlacesByCityCinemaHallAndSeance(cityId, cinemaId, hallName, seanceId) : Observable<Place[]>{        
        return this.http.get(`${environment.APIURL_PLACES_BY_CITY_CINEMA_HALL_SEANCE}/${cityId}/${cinemaId}/${hallName}/${seanceId}`)
            .map(res =>{
                return JsonConvertor.toPlaces(res.json());
            });
    }
}