import { stagger } from "@angular/animations/src/animation_metadata";
import { Seance } from "./seance.model";
import { Place } from "./place.model";


export class Ticket{

    init(
        id: string, purchaseId: string, state: number
    ){
        this.id = id;    
        this.purchaseId = purchaseId;
        this.state = state;
    }

    constructor(){

    }

    id: string;
    seanceId: number;
    seance: Seance;
    place: Place;
    purchaseId: string;
    state: number;
}