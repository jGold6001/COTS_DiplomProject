import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-seance-dialog',
  templateUrl: './seance-dialog.component.html',
  styleUrls: ['./seance-dialog.component.css']
})
export class SeanceDialogComponent implements OnInit {

  dialogDestiny: string;

  constructor(
    public dialogRef: MatDialogRef<SeanceDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit() {
    this.setDestiny();
  }

  clickAdd(){
    this.dialogRef.close();
  }


  setDestiny(){
    if(this.data.destiny == 'add')
      this.dialogDestiny = 'Добавить';
    else
      this.dialogDestiny = 'Изменить';
  }
}
