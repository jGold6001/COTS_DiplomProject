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
export class PurchaseService{

    constructor(
        private httpClient: HttpClient,
        private http: Http, 
    ){}

    saveInDb(purchase: Purchase){
        this.httpClient.post(environment.APIURL_PURCHASE_SAVE_IN_DB,
            {
                Id: purchase.id,
                TicketViewModels: purchase.tickets
            }
        ) .subscribe(null,err => console.log("Error occured"));
    }


    getPurchase(purchaseId: string){
        return this.http.get(environment.APIURL_PURCHASE + purchaseId)
            .map(responce => {
                let data = responce.json();
                let purchase = JsonConvertor.toPurchase(data);
                let movie = JsonConvertor.toMovieShort(data.TicketViewModels[0].SeanceViewModel.MovieShortViewModel);
                let cinema = JsonConvertor.toCinema(data.TicketViewModels[0].SeanceViewModel.CinemaViewModel);
                let seance = JsonConvertor.toSeance(data.TicketViewModels[0].SeanceViewModel, movie, cinema);
                let tickets = JsonConvertor.toTicketsArray(data.TicketViewModels, seance);
                purchase.tickets = tickets;                              
                return purchase;
            });
    }


    payment(){

    }

    removePurchase(){

    }

}