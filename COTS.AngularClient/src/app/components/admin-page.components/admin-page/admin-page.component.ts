import { Component, OnInit, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AuthenticationDialogComponent } from '../authentication-dialog/authentication-dialog.component';
import { User } from '../../../shared/models/user.model';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit, OnChanges {


  ngOnChanges(changes: SimpleChanges): void {
    console.log("changes");
  }

  isSingIn: boolean;
  user: User;

  constructor(
    private dialog: MatDialog,
    private cdRef:ChangeDetectorRef,
    private router: Router,
    private route: ActivatedRoute
  ) { }



  ngOnInit() {  
    if(sessionStorage.getItem('currentUser') == null){
      setTimeout(() => {
        this.isSingIn = false; 
        this.openDialog();
      }, 10); 
    }else{
      this.isSingIn = true; 
    } 
       
  }

  openDialog(){
    let dialogRef = this.dialog.open(AuthenticationDialogComponent, {
      width: '600px',
      disableClose: true,     
    });

    dialogRef.afterClosed().subscribe( user =>
    {
      this.user = user;
      sessionStorage.setItem('currentUser', this.user.login);
      this.isSingIn = true;
    });
  }

  onLogOut(){
    sessionStorage.removeItem('currentUser');
    window.location.reload();
  }


}
