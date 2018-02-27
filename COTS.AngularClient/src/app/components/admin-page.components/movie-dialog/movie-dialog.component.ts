import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-movie-dialog',
  templateUrl: './movie-dialog.component.html',
  styleUrls: ['./movie-dialog.component.css']
})
export class MovieDialogComponent implements OnInit {

  dialogDestiny: string ='add';
  isReadOnly: boolean;

  genreControl = new FormControl();
  genreList = ['ДРАМА', 'ФАНТАСТИКА', 'ПРИКЛЮЧЕНИЕ', 'ФЕНТЕЗИ', 'КОМЕДИЯ', 'ТРИЛЛЕР'];

  constructor(
    public dialogRef: MatDialogRef<MovieDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit() {
    this.dialogDestiny= 'add';
    this.isReadOnly = false;
    this.setDestiny();
  }

  setDestiny(){
    if(this.data.destiny == 'add'){
      this.dialogDestiny = 'Добавить';
      this.isReadOnly = false;
    }     
    else if(this.data.destiny == 'edit'){
      this.dialogDestiny = 'Изменить';
      this.isReadOnly = false;
    }
    else{
      this.dialogDestiny = 'Полная информация';
      this.isReadOnly = true;
    }     
  }

  clickAdd(){
    this.dialogRef.close();
  }

}
