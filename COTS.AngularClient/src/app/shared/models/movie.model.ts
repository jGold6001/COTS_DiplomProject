
export class Movie {
    initFullModel(id: number, name: string,  genre: string, description: string, year: number, duration: number, ageCategory: string,
        country: string,director: string,actors: string, trailerUrl: string,imagePath: string,rankSales: number, dateIssue: string){
        this.id = id;
        this.name = name;
        this.genre = genre;
        this.description = description;
        this.year = year;
        this.duration = duration;
        this.ageCategory = ageCategory;
        this.country = country;
        this.director = director;
        this.actors = actors;
        this.trailerUrl = trailerUrl;
        this.imagePath = imagePath;
        this.rankSales = rankSales;
        this.dateIssue = dateIssue;
    }

    initShortModel(id: number, name: string, imagePath: string,rankSales: number, dateIssue: string){
        this.id = id;
        this.name = name;
        this.imagePath = imagePath;
        this.rankSales = rankSales;
        this.dateIssue = dateIssue;
    }

    constructor(){

    }

    id: number;
    name: string;
    genre: string;
    description: string;
    year: number;
    duration: number;
    ageCategory: string;
    country: string;
    director: string;
    actors: string;
    trailerUrl: string;
    imagePath: string;
    rankSales: number;
    dateIssue: string;
}