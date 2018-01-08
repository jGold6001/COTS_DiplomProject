
export class Movie {
    constructor(id: number, name: string,  genre: string, destination: string, year: number, duration: number, ageCategory: string,
        country: string,director: string,actors: string, trailerUrl: string,imagePath: string,rankSales: number){
        this.id = id;
        this.name = name;
        this.genre = genre;
        this.destination = destination;
        this.year = year;
        this.duration = duration;
        this.ageCategory = ageCategory;
        this.country = country;
        this.director = director;
        this.actors = actors;
        this.trailerUrl = trailerUrl;
        this.imagePath = imagePath;
        this.rankSales = rankSales;
    }

    id: number;
    name: string;
    genre: string;
    destination: string;
    year: number;
    duration: number;
    ageCategory: string;
    country: string;
    director: string;
    actors: string;
    trailerUrl: string;
    imagePath: string;
    rankSales: number;
}