import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { SeanceDialogComponent } from '../seance-dialog/seance-dialog.component';

@Component({
  selector: 'app-seance-block',
  templateUrl: './seance-block.component.html',
  styleUrls: ['./seance-block.component.css']
})
export class SeanceBlockComponent implements OnInit {

  enable: boolean;
  displayedColumns = ['position', 'date', 'time', 'movie', 'technology', 'hall', 'edit', 'delete'];

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.enable = false;
  }

 
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  @ViewChild(MatSort) sort: MatSort;

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  clickEdit(seanceId: number){
    console.info(`edit ${seanceId}`);
  }

  clickDelete(seanceId: number){
    console.info(`delete ${seanceId}`);
  }

  clickAdd(){
    let dialogRef = this.dialog.open(SeanceDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { destiny: 'add'}    
    });

    dialogRef.afterClosed().subscribe(() => {
      
    });

  }
}

export interface Element {
  id: number;
  position: number;
  date: string;
  time: string;
  movie: string;
  technology: string;
  hall: string;
}


const ELEMENT_DATA: Element[] = [
  {position: 1, id: 23, date:'01-04-2018', time: '11:00', movie:'Movie_1', technology:'2d', hall: 'Синий' },
  {position: 2, id: 26, date:'01-03-2018', time: '12:00', movie:'Movie_2', technology:'2d', hall: 'Красный' },
  {position: 3, id: 28, date:'01-02-2018', time: '10:00', movie:'Movie_3', technology:'3d', hall: 'Синий' },
  {position: 4, id: 29, date:'01-01-2018', time: '11:00', movie:'Movie_4', technology:'3d', hall: 'Зеленый' }
];