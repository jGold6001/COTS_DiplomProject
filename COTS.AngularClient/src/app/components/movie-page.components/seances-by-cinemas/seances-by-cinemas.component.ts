import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';
import { MatDialog } from '@angular/material';
import { Seance } from '../../../shared/models/seance.model';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { CinemaService } from '../../../shared/services/cinema.service';
import { MovieService } from '../../../shared/services/movie.service';
import { HallDialogComponent } from '../../hall-dialog.components/hall-dialog/hall-dialog.component';


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
    private movieService: MovieService,

    public dialog: MatDialog
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

  openDialog(){
    let dialogRef = this.dialog.open(HallDialogComponent, {
      width: '1000px',
      data: { seance: this.seance }
    });

    dialogRef.afterClosed().subscribe(result => {
      //go to if dialog close
    });
  }


  private loadMovie(movieId: number){
    this.movieService.getOne(movieId)
        .subscribe( data => {this.movie = data;
          this.seance.movie = this.movie;
        });
  }

  private loadCinema(cinemaId: string){
      this.cinemaService.getOne(cinemaId)
          .subscribe(data => {this.cinema = data;
            this.seance.cinema = this.cinema;
          });
  }

}
