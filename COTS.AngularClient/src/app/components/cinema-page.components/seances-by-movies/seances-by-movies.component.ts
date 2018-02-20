import { Component, OnInit, Input } from '@angular/core';
import { Seance } from '../../../shared/models/seance.model';
import { Sector } from '../../../shared/models/sector.model';
import { MatDialog } from '@angular/material';
import { SectorService } from '../../../shared/services/sector.service';
import { HallDialogComponent } from '../../hall-dialog.components/hall-dialog/hall-dialog.component';

@Component({
  selector: 'app-seances-by-movies',
  templateUrl: './seances-by-movies.component.html',
  styleUrls: ['./seances-by-movies.component.css']
})
export class SeancesByMoviesComponent implements OnInit {

  @Input() seance: Seance;
  @Input() enterpriseId: string;
  sectors: Sector[] = [];

  constructor(
    public dialog: MatDialog,
    private sectorService: SectorService
  ) { }

  ngOnInit() {
    //console.log(this.enterpriseId);
    this.sectorService.getAllByEnterprise(this.enterpriseId).subscribe( res =>
      {
        this.sectors = res;
      }
    )
  }

  openDialog(){
    let dialogRef = this.dialog.open(HallDialogComponent, {
      width: '1200px',
      disableClose: true,
      data: { seanceId: this.seance.id, sectors:  this.sectors}
    });
  }

}
