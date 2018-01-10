import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import {Cinema} from "../models/cinema.model";
import { environment } from "../../../environments/environment";

@Injectable()
export class CinemaService{
    constructor(private http: Http) { }

    getAllByCity(cityId: string): Observable<Cinema[]>{
        return this.http.get(environment.APIURL_CINEMAS_BYCITY  + cityId)
            .map(response => {  
                return this.convertJsonToArray(response.json());
            });
    }

    getOne(id: string): Observable<Cinema>{
        return this.http.get(environment.APIURL_CINEMA + id)
            .map(response =>{
                return this.convertJsonToObject(response.json());
            });
    }

    private convertJsonToArray(data): Cinema[]{
        let cinemas: Cinema[] = [];
        for (let i = 0; i < data.length; i++){
            let cinema: Cinema = new Cinema();
            cinema.init(data[i].Id, data[i].Name, data[i].Address, data[i].ImagePath, data[i].CityId);
            cinemas.push(cinema);
        }
        return cinemas;
    }

    private convertJsonToObject(data): Cinema{
        let cinema: Cinema = new Cinema();
        cinema.init(data.Id, data.Name, data.Address, data.ImagePath, data.CityId);
        return cinema;
    }
}