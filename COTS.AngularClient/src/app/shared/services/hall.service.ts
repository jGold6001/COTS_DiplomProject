import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Http, Response,Headers } from "@angular/http";
import { Place } from "../models/place.model";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class HallService{
    constructor(private http: Http){

    }

}