import { Movie } from "./movie.model";
import { Cinema } from "./cinema.model";
import { Hall } from "./hall.model";
import { Tariff } from "./tariff.model";

export class Seance{

    constructor(){
    
    }

    init( id: number, timeStr: string, dateStr: string, technologyId: string){
        this.id = id;
        this.dateStr = dateStr;
        this.timeStr = timeStr;
        this.technologyId = technologyId;
    }

    id: number;
    timeStr: string;
    dateStr: string
    technologyId: string;
    hall: Hall;
    movie: Movie;
    tariffs: Tariff[];
}