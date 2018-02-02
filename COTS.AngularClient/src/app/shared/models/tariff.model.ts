import { Seance } from "./seance.model";
import { Place } from "./place.model";

export class Tariff{
    id: string;
    name: string;
    price: number;
    technologyId: string;
    sectorId: number;

    init(id: string, name: string, price: number, sectorId: number, technologyId: string){
        this.id = id;
        this.name = name;
        this.price = price;
        this.sectorId = sectorId;
        this.technologyId = technologyId;
    }
}