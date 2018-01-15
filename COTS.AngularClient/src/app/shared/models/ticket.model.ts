import { stagger } from "@angular/animations/src/animation_metadata";
import { Seance } from "./seance.model";


export class Ticket{

    init(
        id: string, place: number, row: number, tariff: string, 
        price: number, purchaseId: string, state: number
    ){
        this.id = id;
        this.place = place;
        this.row = row;
        this.tariff = tariff;
        this.price = price;
        this.purchaseId = purchaseId;
        this.state = state;
    }

    constructor(){

    }

    id: string;
    seanceId: number;
    seance: Seance;
    place: number;
    row: number;
    tariff: string;
    price: number;
    purchaseId: string;
    state: number;
}