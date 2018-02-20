import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AuthenticationDialogComponent } from '../authentication-dialog/authentication-dialog.component';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {

  isSingIn: boolean;

  constructor(
    private dialog: MatDialog,
  ) { }


  ngOnInit() {
    setTimeout(() => {
      this.isSingIn = false;
      this.openDialog();
    }, 10);
  }

  openDialog(){
    let dialogRef = this.dialog.open(AuthenticationDialogComponent, {
      width: '600px',
      disableClose: true,     
    });

    dialogRef.afterClosed().subscribe(() =>
    {
      this.isSingIn = true;
    });
  }

}
