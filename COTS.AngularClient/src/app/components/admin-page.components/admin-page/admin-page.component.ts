import { Component, OnInit, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material';
import { User } from '../../../shared/models/user.model';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Cinema } from '../../../shared/models/cinema.model';
import { UserService } from '../../../shared/services/user.service';
import { CinemaService } from '../../../shared/services/cinema.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {
 
  user: User;
  cinema: Cinema;
  showPlaceOfWork: boolean = true;
  routeData: any;
  isAdmin: boolean;
  isSingIn: boolean;
  selectedPointMenu: number = 1;
  quota:number;


  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private cinemaService: CinemaService,
    private userService: UserService
  ) { }



  ngOnInit() {  
    this.route.params.subscribe( params => this.routeData = { cinemaId: params['cinemaId'], userId: params['userId'], quid: params['sessionId']});
    if(sessionStorage.getItem('sessionId') == this.routeData.quid){
        this.isSingIn = true;
        this.userService.getOne(this.routeData.userId).subscribe(user =>
          {
            this.user = user;
            this.quota = user.userRole;
            this.isAdmin = this.isAdminAccount();   
            if(!this.isAdmin){
              this.cinemaService.getOne(this.routeData.cinemaId).subscribe( cinema =>this.cinema = cinema );
            }    
          }
        );    
    }else{
      this.isSingIn = false;
    }
  }

  onLogOut(){
   sessionStorage.clear();
   this.router.navigate(["login"]);
  }

  private isAdminAccount(): boolean{
    if(this.user.login == 'admin'){
      this.showPlaceOfWork = false;
      return true;
    }
    return false;
  }

}
