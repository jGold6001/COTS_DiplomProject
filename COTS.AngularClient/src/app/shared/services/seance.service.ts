import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";

import { catchError, map, tap } from 'rxjs/operators';
import { environment } from "../../../environments/environment";
import { Seance } from "../models/seance.model";
import { DatePipe } from "@angular/common";
import { Cinema } from "../models/cinema.model";
import { Movie } from "../models/movie.model";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class SeanceService{
    
    constructor(private http: Http, 
        public datepipe: DatePipe
    ) { } 

    getAllByCinemaMovieDate(cinemaId: string, movieId: number, date: Date) :  Observable<Seance[]>{
        
        let dateFormated =this.datepipe.transform(date, 'yyyy-MM-dd');
        return this.http.get(environment.APIURL_SEANCES_BY_CINEMA_MOVIE_DATE + cinemaId +"/"+ movieId + "/" + dateFormated) 
            .map(response => { 
                return JsonConvertor.toSeanceArray(response.json());
            });     
    }

    //go to 
    getOne(id: number){
        return this.http.get(environment.APIURL_SEANCE + id)
            .map(response => {
                return JsonConvertor.toSeance(response.json());
            });
    }

}