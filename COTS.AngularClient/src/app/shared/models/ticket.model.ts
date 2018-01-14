import { stagger } from "@angular/animations/src/animation_metadata";
import { Cinema } from "./cinema.model";
import { Movie } from "./movie.model";


export class Ticket{

    init(
        id: string, seanceId: number, hall: string, place: number, 
        row: number, tariff: string, price: number, purchaseId: string, state: number
    ){
        this.id = id;
        this.seanceId = seanceId;
        this.hall = hall;
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
    movie: Movie;
    cinema: Cinema;
    seanceId: number;
    hall: string;
    place: number;
    row: number;
    tariff: string;
    price: number;
    purchaseId: string;
    state: number;
}