import { Component, OnInit, Input, OnChanges, ChangeDetectionStrategy  } from '@angular/core';
import { ActivatedRoute, ParamMap, Router, UrlTree, UrlSegmentGroup, UrlSegment, PRIMARY_OUTLET } from '@angular/router';
import { Data } from '@agm/core/services/google-maps-types';
import { element } from 'protractor';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { MovieService } from '../../../shared/services/movie.service';
import { CinemaService } from '../../../shared/services/cinema.service';

@Component({
  selector: 'app-movie-page',
  templateUrl: './movie-page.component.html',
  styleUrls: ['./movie-page.component.css']
})
export class MoviePageComponent implements OnInit {
  
  id: number;
  movie: Movie;
  cinemas: Cinema[] = [];

  dates: Date[]=[];

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    private cinemaService: CinemaService,
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


    this.cinemaService.getAllByCity(this.cityId)
    .subscribe(r => {
      this.cinemas = r;
    },  () => console.error("Ошибка при получении данных с сервера"));

    this.setDates();
  }

  get cityId(): string{
    const tree: UrlTree = this.router.parseUrl( this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    return s[0].path;
  }

  private setDates(){
    for (let index = 0; index < 9; index++) {
      var date: Date = new Date();
      date.setDate(date.getDate()+index);
      this.dates.push(date); 
    }
  }

  //fixExceptionProperties
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

  get _movieDateIssue(): string{
    let value: string;
    try {
      value = this.movie.dateIssue;
    } catch (ex) {}
    return value;
  }
}
