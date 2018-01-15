import { Movie } from "./movie.model";
import { Cinema } from "./cinema.model";

export class Seance{

    constructor(){
    
    }

    init( id: number, timeStr: string, dateStr: string, typeD: string, hall: string){
        this.id = id;
        this.dateStr = dateStr;
        this.timeStr = timeStr;
        this.typeD = typeD;
        this.hall = hall;
    }

    id: number;
    timeStr: string;
    dateStr: string
    typeD: string;
    hall: string;
    cinema: Cinema;
    movie: Movie;
}