import { Component, OnInit, Input} from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';
import { MatDialog } from '@angular/material';
import { Seance } from '../../../shared/models/seance.model';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { CinemaService } from '../../../shared/services/cinema.service';
import { MovieService } from '../../../shared/services/movie.service';
import { HallDialogComponent } from '../../hall-dialog.components/hall-dialog/hall-dialog.component';
import { Hall } from '../../../shared/models/hall.model';


@Component({
  selector: 'app-seances-by-cinemas',
  templateUrl: './seances-by-cinemas.component.html',
  styleUrls: ['./seances-by-cinemas.component.css']
})
export class SeancesByCinemasComponent implements OnInit {

  @Input() seance: Seance;
  
  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    //console.log(this.seance);
  }

  openDialog(){
    let dialogRef = this.dialog.open(HallDialogComponent, {
      width: '1000px',
      data: { seance: this.seance }
    });
  }

}
