import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";

import { Observable } from "rxjs/Observable";

import "rxjs/add/operator/map";
import { Movie } from "../models/movie.model";
import { environment } from "../../../environments/environment";


@Injectable()
export class MovieService {
    constructor(private http: Http) { } 

    getAllPremeriesByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_PREMERIES_BYCITY + cityId)
            .map(response => {
                return  this.convertJsonToArray(response.json());
            });
    }

    getAllCommingSoonByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_COMINGSOON_BYCITY + cityId)
            .map(response => {
                return  this.convertJsonToArray(response.json());
            });
    }

    getTop10ByCity(cityId: string) : Observable<Movie[]>{
        return this.http.get(environment.APIURL_MOVIES_TOP10_BYCITY + cityId)
        .map(response => {
            return  this.convertJsonToArray(response.json());
        });
    }

    getOne(id: number) : Observable<Movie>{
        return this.http.get(environment.APIURL_MOVIE + id)
        .map(responce =>{
           return this.convertJsonToObject(responce.json()); 
        });
    }

    convertJsonToArray(data): Movie[]{
        let movies: Movie[] = [];
        for (let i = 0; i < data.length; i++) {
            let movie: Movie = new Movie();
            movie.init(
                data[i].Id, data[i].Name, data[i].Genre, data[i].Destination,
                data[i].Year, data[i].Duration, data[i].AgeCategory, data[i].Country,
                data[i].Director, data[i].Actors, data[i].TrailerUrl, data[i].ImagePath, 
                data[i].RankSales, data[i].DateIssue
            );        
            movies.push(movie);
        }     
        return movies;
    }

    convertJsonToObject(data): Movie{  
        let movie: Movie = new Movie();
        movie.init(
            data.Id, data.Name, data.Genre, data.Destination,
            data.Year, data.Duration, data.AgeCategory, data.Country,
            data.Director, data.Actors, data.TrailerUrl, data.ImagePath, 
            data.RankSales, data.DateIssue
        );
        return movie;
    }

}