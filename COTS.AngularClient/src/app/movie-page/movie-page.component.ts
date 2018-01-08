import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Movie } from '../shared/models/movie.model';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { MovieService } from '../shared/services/movie.service';

@Component({
  selector: 'app-movie-page',
  templateUrl: './movie-page.component.html',
  styleUrls: ['./movie-page.component.css']
})
export class MoviePageComponent implements OnInit {
  
  id: number;
  movie: Movie;

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    });

    this.movieService.getOne(this.id)
    .subscribe(r =>{
      this.movie = r;
    } , () => console.error("Ошибка при получении данных с сервера"));

  }

  get _movieName(): string{
    let value: string;
    try {
      value = this.movie.name;
    } catch (ex) {}
    return value;
  }

  get _movieDescription(): string{
    let value: string;
    try {
      value = this.movie.destination;
    } catch (ex) {}
    return value;
  }

  get _movieGenre(): string{
    let value: string;
    try {
      value = this.movie.genre;
    } catch (ex) {}
    return value;
  }

  get _movieAgeCategory(): string{
    let value: string;
    try {
      value = this.movie.ageCategory;
    } catch (ex) {}
    return value;
  }

  get _movieDirector(): string{
    let value: string;
    try {
      value = this.movie.director;
    } catch (ex) {}
    return value;
  }

  get _movieCountry(): string{
    let value: string;
    try {
      value = this.movie.country;
    } catch (ex) {}
    return value;
  }

  get _movieActors(): string{
    let value: string;
    try {
      value = this.movie.actors;
    } catch (ex) {}
    return value;
  }

  get _movieDuration(): number{
    let value: number;
    try {
      value = this.movie.duration;
    } catch (ex) {}
    return value;
  }

  get _movieImage(): string{
    let value: string;
    try {
      value = this.movie.imagePath;
    } catch (ex) {}
    return value;
  }

  get _movieTrailer(): string{
    let value: string;
    try {
      value = this.movie.trailerUrl;
    } catch (ex) {}
    return value;
  }
}
