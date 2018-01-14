import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { Purchase } from "../models/purchase.model";
import { HttpClient } from "@angular/common/http";
import { Ticket } from "../models/ticket.model";
import { Http } from "@angular/http";

@Injectable()
export class TicketService{

    constructor(
        private httpClient: HttpClient,
        private http: Http){}

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
                return this.convertJsonToArray(responce.json());
            });
    }


    getAllBookingTickets(){

    }

    payment(){

    }

    removePurchase(){

    }

    convertJsonToArray(data): Purchase {
        let purchase: Purchase= new Purchase();
        let tickets: Ticket[] = [];

        purchase.id = data.Id;
        let ticketsArray = data.TicketViewModels;
        for (let i = 0; i < ticketsArray.length; i++) {
            let ticket: Ticket = new Ticket();
            ticket.init(
                ticketsArray[i].Id, ticketsArray[i].Movie, ticketsArray[i].Cinema, ticketsArray[i].SeanceId, 
                ticketsArray[i].Hall, ticketsArray[i].Place,
                ticketsArray[i].Row, ticketsArray[i].Tariff, ticketsArray[i].Price, 
                ticketsArray[i].PurchaseId, ticketsArray[i].State
            );   
            tickets.push(ticket);
        }
        purchase.tickets = tickets;
        return purchase;
    }

}