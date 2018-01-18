import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { Purchase } from "../models/purchase.model";
import { HttpClient } from "@angular/common/http";
import { Ticket } from "../models/ticket.model";
import { Http, RequestOptions } from "@angular/http";
import { JsonConvertor } from "../utils/json.convertor";
import { City } from "../models/city.model";
import { Response } from "@angular/http/src/static_response";

@Injectable()
export class PurchaseService{

    constructor(
        private httpClient: HttpClient,
        private http: Http, 
    ){}

    saveInDb(purchase: Purchase){
        this.httpClient.post(environment.APIURL_PURCHASE_SAVE_IN_DB, purchase) 
            .subscribe(null,err => console.log("Error occured"));
    }
    
    getPurchase(purchaseId: string){
        return this.http.get(environment.APIURL_PURCHASE + purchaseId)
            .map(responce => {                          
                return JsonConvertor.toPurchase(responce.json());
            });
    }


    payment(){

    }

    removePurchase(){

    }

}