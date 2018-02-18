import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../../../shared/models/movie.model';
import { Seance } from '../../../shared/models/seance.model';
import {ActivatedRoute } from '@angular/router';
import { SeanceService } from '../../../shared/services/seance.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {

  @Input() movie: Movie;
  @Input() enterpriseId: string;
  @Input() date: Date;
  cinemaId: string;

  seances: Seance[] =[];

  constructor( 
    private seanceService: SeanceService,
    private route: ActivatedRoute) { }

  ngOnInit() {
   
    this.route.params.subscribe(params => {
      this.cinemaId = params['id'];
    });

    this.seanceService.getAllByCinemaMovieDate(this.cinemaId, this.movie.id, this.date)
    .subscribe(r =>{
        this.seances = r; 
    } , () => console.error("Ошибка при получении данных с сервера"));
  }



}
