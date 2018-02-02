import { stagger } from "@angular/animations/src/animation_metadata";
import { Seance } from "./seance.model";
import { Place } from "./place.model";
import { Tariff } from "./tariff.model";


export class Ticket{

    init(
        id: string, purchaseId: string, placeId: number, state: number, tariffId: number
    ){
        this.id = id;    
        this.purchaseId = purchaseId;
        this.placeId = placeId;
        this.state = state;
        this.tariffId = tariffId;
    }

    constructor(){

    }

    id: string;
    seanceId: number;
    seance: Seance;
    place: Place;
    placeId: number;
    purchaseId: string;
    tariffId: number;
    state: number;
    tariff: Tariff;
}