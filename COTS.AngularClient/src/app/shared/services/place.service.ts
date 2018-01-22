import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Http, Response,Headers } from "@angular/http";
import { Place } from "../models/place.model";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class PlaceService{

    constructor(private http: Http){

    }

    getDataFromJsonFile(cityId, cinemaId, hall) : Observable<Place[]>{
        let path = `./assets/Halls/${cityId}/${cinemaId}/hall-${hall}.json`;
        return this.http.get(path)
            .map(res =>{
                return JsonConvertor.toPlaces(res.json());
            });
    }
}