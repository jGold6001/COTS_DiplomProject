import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from "../../../environments/environment";
import { JsonConvertor } from "../utils/json.convertor";

@Injectable()
export class SectorService{

    constructor(private http: Http
    ) { } 

    getAllByEnterprise(enterpriseId: string){
        return this.http.get(environment.APIURL_SECTORS_BY_ENTERTAIMENT + enterpriseId)
            .map(response =>
            {
                return JsonConvertor.toSectorArray(response.json());
            });
    }
}