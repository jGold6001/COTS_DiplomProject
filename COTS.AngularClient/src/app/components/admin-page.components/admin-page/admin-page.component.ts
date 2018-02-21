import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AuthenticationDialogComponent } from '../authentication-dialog/authentication-dialog.component';
import { User } from '../../../shared/models/user.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {


  isSingIn: boolean;
  user: User;

  constructor(
    private dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
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

    dialogRef.afterClosed().subscribe( user =>
    {
      this.user = user;
      console.log(this.user);
      //this.router.navigate(["admin", this.user.login]);
      this.isSingIn = true;
    });
  }

}
