import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";

import { catchError, map, tap } from 'rxjs/operators';
import { environment } from "../../../environments/environment";
import { Seance } from "../models/seance.model";
import { DatePipe } from "@angular/common";
import { Cinema } from "../models/cinema.model";
import { Movie } from "../models/movie.model";

@Injectable()
export class SeanceService{
    
    constructor(private http: Http, 
        public datepipe: DatePipe
    ) { } 

    getAllByCinemaMovieDate(cinemaId: string, movieId: number, date: Date) :  Observable<Seance[]>{
        
        let dateFormated =this.datepipe.transform(date, 'yyyy-MM-dd');
        return this.http.get(environment.APIURL_SEANCES_BY_CINEMA_MOVIE_DATE + cinemaId +"/"+ movieId + "/" + dateFormated) 
            .map(response => {
                    return this.convertJsonToArray(response.json(), cinemaId, movieId);
            });     
    }

    convertJsonToArray(data, cinemaId: string, movieId: number): Seance[] {
        let seances: Seance[] = [];
        
        for (let i = 0; i < data.length; i++) {
            let seance: Seance = new Seance(
                data[i].Id, data[i].TimeBegin, data[i].DateSeance, data[i].TypeD, data[i].Hall
            );   
            seances.push(seance);
        }
        return seances;
    }

}