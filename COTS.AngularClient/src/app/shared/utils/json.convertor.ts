import { Movie } from "../models/movie.model";
import { Cinema } from "../models/cinema.model";
import { Ticket } from "../models/ticket.model";
import { Purchase } from "../models/purchase.model";
import { Seance } from "../models/seance.model";


export class JsonConvertor{

    public static toMoviesArray(data): Movie[] {
        let movies: Movie[] = [];
        for (let i = 0; i < data.length; i++) {
            let movie: Movie = new Movie();
            movie.init(
                data[i].Id, data[i].Name, data[i].Genre, data[i].Destination,
                data[i].Year, data[i].Duration, data[i].AgeCategory, data[i].Country,
                data[i].Director, data[i].Actors, data[i].TrailerUrl, data[i].ImagePath, 
                data[i].RankSales, data[i].DateIssue
            );        
            movies.push(movie);
        }     
        return movies;
    }

    public static toMovie(data): Movie{
        let movie: Movie = new Movie();
        movie.init(
            data.Id, data.Name, data.Genre, data.Destination,
            data.Year, data.Duration, data.AgeCategory, data.Country,
            data.Director, data.Actors, data.TrailerUrl, data.ImagePath, 
            data.RankSales, data.DateIssue
        );
        return movie;
    }

    public static toCinemasArray(data): Cinema[]{
        let cinemas: Cinema[] = [];
        for (let i = 0; i < data.length; i++){
            let cinema: Cinema = new Cinema();
            cinema.init(data[i].Id, data[i].Name, data[i].Address, data[i].ImagePath, data[i].CityId);
            cinemas.push(cinema);
        }
        return cinemas;
    }

    public static toCinema(data): Cinema{
        let cinema: Cinema = new Cinema();
        cinema.init(data.Id, data.Name, data.Address, data.ImagePath, data.CityId);
        return cinema;
    }

    public static toSeanceArray(data): Seance[] {
        let seances: Seance[] = [];  
        for (let i = 0; i < data.length; i++) {
            let seance: Seance = new Seance();
            seance.init(
                data[i].Id, data[i].TimeBegin, data[i].DateSeance, data[i].TypeD, data[i].Hall
            );  
            seances.push(seance);
        }
        return seances;
    }

    public static toSeance(data, movie: Movie, cinema: Cinema): Seance{
        let seance: Seance = new Seance();
        seance.init(data.Id, data.TimeBegin, data.DateSeance, data.TypeD, data.Hall);
        seance.movie = movie;
        seance.cinema = cinema;
        return seance;
    }

    public static toTicketsArray(data, seance: Seance): Ticket[]{
        let tickets: Ticket[] = [];
        for (let i = 0; i < data.length; i++) {
            let ticket: Ticket = new Ticket();
            ticket.init(
                data[i].Id, data[i].Place,
                data[i].Row, data[i].Tariff, data[i].Price, 
                data[i].PurchaseId, data[i].State
            );
            ticket.seance = seance;   
            tickets.push(ticket);
        }
        return tickets;
    }

    public static toPurchase(data): Purchase{
        let purchase: Purchase= new Purchase();
        purchase.id = data.Id;     
        return purchase;
    }

}