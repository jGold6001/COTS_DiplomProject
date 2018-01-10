import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { Seance } from '../shared/models/seance.model';
import { CinemaService } from '../shared/services/cinema.service';
import { MovieService } from '../shared/services/movie.service';
import { Movie } from '../shared/models/movie.model';
import { Cinema } from '../shared/models/cinema.model';
import { BehaviorSubject } from 'rxjs';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-seances-by-cinemas',
  templateUrl: './seances-by-cinemas.component.html',
  styleUrls: ['./seances-by-cinemas.component.css']
})
export class SeancesByCinemasComponent implements OnInit, OnChanges {

  @Input() seance: Seance;
  @Input() cinemaId: string;
  @Input() movieId: number;

  movie: Movie;
  cinema: Cinema;


  constructor(
    private cinemaService: CinemaService,
    private movieService: MovieService
  ) { }

  ngOnInit() {
    
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes['movieId']){
      this.loadMovie(this.movieId);
    }

    if(changes['cinemaId']){
      this.loadCinema(this.cinemaId);
    }
    
  }

  openModal(){
    
  }

  private loadMovie(movieId: number){
    this.movieService.getOne(movieId)
        .subscribe( data => {this.movie = data; console.log(this.movie);});
  }

  private loadCinema(cinemaId: string){
      this.cinemaService.getOne(cinemaId)
          .subscribe(data => {this.cinema = data; console.log(this.cinema);});
  }

}
