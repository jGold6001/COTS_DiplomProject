import { Seance } from "./seance.model";
import { Place } from "./place.model";

export class Tariff{
    id: string;
    name: string;
    price: number;

    init(id: string, name: string, price: number){
        this.id = id;
        this.name = name;
        this.price = price;
    }
}