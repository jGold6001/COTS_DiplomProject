import { Cinema } from "./cinema.model";

export class Hall {
    id: number;
    name: string;
    cinema: Cinema;

    init(id: number, name: string){
        this.id = id;
        this.name = name;
    }
}