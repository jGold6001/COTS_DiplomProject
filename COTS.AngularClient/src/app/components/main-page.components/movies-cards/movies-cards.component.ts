import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from '../../../shared/models/movie.model';
import { City } from '../../../shared/models/city.model';

@Component({
  selector: 'app-movies-cards',
  templateUrl: './movies-cards.component.html',
  styleUrls: ['./movies-cards.component.css']
})
export class MoviesCardsComponent implements OnInit {

  @Input() movie: Movie= new Movie();
  @Input() city: City = new City();

  constructor(private router: Router) { }

  ngOnInit() {
    
  }
  
  goToMovieUrl(){
    this.router.navigate([this.city.id, "movie", this.movie.id]);
  }

}
