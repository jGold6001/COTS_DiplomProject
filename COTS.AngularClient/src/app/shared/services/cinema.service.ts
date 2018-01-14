import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import {Cinema} from "../models/cinema.model";
import { environment } from "../../../environments/environment";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class CinemaService{
    constructor(private http: Http) { }

    getAllByCity(cityId: string): Observable<Cinema[]>{
        return this.http.get(environment.APIURL_CINEMAS_BYCITY  + cityId)
            .map(response => {  
                return JsonConvertor.toCinemasArray(response.json());              
            });
    }

    getOne(id: string): Observable<Cinema>{
        return this.http.get(environment.APIURL_CINEMA + id)
            .map(response =>{
                return JsonConvertor.toCinema(response.json());
            });
    }

}