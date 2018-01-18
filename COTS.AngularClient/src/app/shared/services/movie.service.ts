import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";

import "rxjs/add/operator/map";
import { Movie } from "../models/movie.model";
import { environment } from "../../../environments/environment";
import { JsonConvertor } from "../utils/json.convertor";


@Injectable()
export class MovieService {
    constructor(private http: Http) { } 

    getAllPremeriesByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_PREMERIES_BYCITY + cityId)
            .map(response => {
                return JsonConvertor.toMoviesShortArray(response.json());
            });
    }

    getAllCommingSoonByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_COMINGSOON_BYCITY + cityId)
            .map(response => {
                return JsonConvertor.toMoviesShortArray(response.json());
            });
    }

    getTop10ByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_TOP10_BYCITY + cityId)
        .map(response => {
            return JsonConvertor.toMoviesShortArray(response.json());
        });
    }

    getOne(id: number) : Observable<Movie>{
        return this.http.get(environment.APIURL_MOVIE + id)
        .map(responce =>{
           return JsonConvertor.toMovieFull(responce.json());
        });
    }
}