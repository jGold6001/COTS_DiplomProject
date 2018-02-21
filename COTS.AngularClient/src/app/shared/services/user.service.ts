import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Http } from "@angular/http";
import { JsonConvertor } from "../utils/json.convertor";
import { User } from "../models/user.model";


@Injectable()
export class UserService{

    constructor(
        private httpClient: HttpClient,
        private http: Http, 
    ){ }


    isExist(user: User){
        return this.http.post(environment.APIURL_USER_IS_EXIST, user)
            .map( response => {
                return  response.status;
            });          
    }

}