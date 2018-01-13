import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { Purchase } from "../models/purchase.model";
import { HttpClient } from "@angular/common/http";
import { Ticket } from "../models/ticket.model";

@Injectable()
export class TicketService{

    constructor(private http: HttpClient){}

    saveInDb(purchase: Purchase){
        this.http.post(environment.APIURL_TICKETS_SAVE_IN_DB,
            {
                Id: purchase.id,
                TicketViewModels: purchase.tickets
            }
        ) .subscribe(null,err => console.log("Error occured"));
    }

    getAllByPurchase(purchaseId: string) : Observable<Ticket[]>{
        return this.http.get<Ticket[]>(environment.APIURL_TICKETS_BY_PURCHASE + purchaseId);
    }

    getPurchase(purchaseId: string){
        return this.http.get<Purchase>(environment.APIURL_TICKETS_GET_PURCHASE + purchaseId);
    }


    getAllBookingTickets(){

    }

    payment(){

    }

    removePurchase(){

    }

    // convertJsonToArray(data): Ticket[] {
    //     let tickets: Ticket[] = [];
        
    //     for (let i = 0; i < data.length; i++) {
    //         let ticket: Ticket = new Ticket();
    //         ticket.init(
    //             data[i].Id, data[i].Movie, data[i].Cinema, data[i].SeanceId, 
    //             data[i].Hall, data[i].Place,
    //             data[i].Row, data[i].Tariff, data[i].Price, 
    //             data[i].PurchaseId, data[i].State
    //         );   
    //         tickets.push(ticket);
    //     }
    //     return tickets;
    // }

}