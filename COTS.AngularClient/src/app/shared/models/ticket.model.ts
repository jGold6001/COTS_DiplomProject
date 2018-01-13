import { stagger } from "@angular/animations/src/animation_metadata";


export class Ticket{

    init(
        id: string, movie: string, cinema: string, seanceId: number, hall: string, place: number, 
        row: number, tariff: string, price: number, purchaseId: string, state: number
    ){
        this.id = id;
        this.movie = movie;
        this.cinema = cinema;
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
    movie: string;
    cinema: string;
    seanceId: number;
    hall: string;
    place: number;
    row: number;
    tariff: string;
    price: number;
    purchaseId: string;
    state: number;
}