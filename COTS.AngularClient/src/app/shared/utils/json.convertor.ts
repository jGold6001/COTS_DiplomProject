import { Movie } from "../models/movie.model";
import { Cinema } from "../models/cinema.model";
import { Ticket } from "../models/ticket.model";
import { Purchase } from "../models/purchase.model";


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

    public static toTicketsArray(data): Ticket[]{
        let tickets: Ticket[] = [];
        for (let i = 0; i < data.length; i++) {
            let ticket: Ticket = new Ticket();
            let movie = JsonConvertor.toMovie(ticket.movie);
            let cinema = JsonConvertor.toCinema(ticket.cinema);
            ticket.init(
                data[i].Id,                
                movie, cinema, data[i].SeanceId, 
                data[i].Hall, data[i].Place,
                data[i].Row, data[i].Tariff, data[i].Price, 
                data[i].PurchaseId, data[i].State
            );   
            tickets.push(ticket);
        }
        return tickets;
    }

    public static toPurchase(data): Purchase{
        let purchase: Purchase= new Purchase();
        purchase.id = data.Id;
        purchase.tickets = JsonConvertor.toTicketsArray(data.TicketViewModels);
        return purchase;
    }

}