import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Http } from "@angular/http";
import { JsonConvertor } from "../utils/json.convertor";


@Injectable()
export class UserService{

    constructor(
        private httpClient: HttpClient,
        private http: Http, 
    ){ }


    isExist(user: any){
        return this.httpClient.post(environment.APIURL_USER_IS_EXIST, user)
            .subscribe(null,err => console.log("Error occured"));
    }

}