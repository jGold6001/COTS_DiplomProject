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

    saveInDb(purchase: Purchase){
        this.httpClient.post(environment.APIURL_TICKETS_SAVE_IN_DB,
            {
                Id: purchase.id,
                TicketViewModels: purchase.tickets
            }
        ) .subscribe(null,err => console.log("Error occured"));
    }


    getPurchase(purchaseId: string){
        return this.http.get(environment.APIURL_TICKETS_GET_PURCHASE + purchaseId)
            .map(responce => {
                let data = responce.json();

                let purchase = JsonConvertor.toPurchase(data);
                let movie = JsonConvertor.toMovie(data.TicketViewModels[0].MovieViewModel);
                let cinema = JsonConvertor.toCinema(data.TicketViewModels[0].CinemaViewModel);
                let tickets = JsonConvertor.toTicketsArray(data.TicketViewModels, movie, cinema);
                purchase.tickets = tickets;               
                // console.log(tickets);
                // console.log(movie);
                // console.log(cinema);
                return purchase;
            });
    }


    getAllBookingTickets(){

    }

    payment(){

    }

    removePurchase(){

    }

}