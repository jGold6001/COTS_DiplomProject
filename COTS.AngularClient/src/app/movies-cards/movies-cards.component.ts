import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../shared/models/movie.model';
import { City } from '../shared/models/city.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movies-cards',
  templateUrl: './movies-cards.component.html',
  styleUrls: ['./movies-cards.component.css']
})
export class MoviesCardsComponent implements OnInit {

  @Input() movie: Movie;
  @Input() city: City;

  constructor(private router: Router) { }

  ngOnInit() {
    
  }

  private fixExceptionCityId(): string{
    let cityId: string;
    try {
      cityId = this.city.id;
    } catch (ex) {}
    return cityId;
  }

  goToMovieUrl(){
    this.router.navigate([this.city.id, "movie", this.movie.id]);
  }

}
