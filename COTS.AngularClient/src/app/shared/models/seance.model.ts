import { Movie } from "./movie.model";
import { Cinema } from "./cinema.model";
import { Hall } from "./hall.model";

export class Seance{

    constructor(){
    
    }

    init( id: number, timeStr: string, dateStr: string, typeD: string){
        this.id = id;
        this.dateStr = dateStr;
        this.timeStr = timeStr;
        this.typeD = typeD;
    }

    id: number;
    timeStr: string;
    dateStr: string
    typeD: string;
    hall: Hall;
    movie: Movie;
}