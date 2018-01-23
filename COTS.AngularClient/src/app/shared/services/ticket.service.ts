import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { Purchase } from "../models/purchase.model";
import { HttpClient } from "@angular/common/http";
import { Ticket } from "../models/ticket.model";
import { Http } from "@angular/http";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class TicketService{

    constructor(
        private httpClient: HttpClient,
        private http: Http, 
    ){}

    getAll(){
        return this.http.get(environment.APIURL_TICKETS_GETALL)
            .map(response =>{
                return JsonConvertor.toTicketsArray(response.json());
            });
    }

}