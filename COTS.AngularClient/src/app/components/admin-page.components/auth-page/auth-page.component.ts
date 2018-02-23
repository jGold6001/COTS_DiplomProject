import { Component, OnInit } from '@angular/core';
import { User } from '../../../shared/models/user.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { City } from '../../../shared/models/city.model';
import { CityService } from '../../../shared/services/city.service';
import { CinemaService } from '../../../shared/services/cinema.service';
import { UserService } from '../../../shared/services/user.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent implements OnInit {

  model: any={};
  user: User;
  cities: City[] =[];
  cityId: string;
  cinemas: Cinema[] = [];
  wrongLogin: boolean = false;
  routeData: any;
  isLogin: boolean;

  constructor(
    private cityService: CityService,
    private cinemaService: CinemaService,
    private userService: UserService,
    private router: Router,
  ) { }

  ngOnInit() {

    if(sessionStorage.getItem("sessionId") != null ){
      this.isLogin = true;
    }else{
      this.isLogin = false;
      this.cityService.getAll().subscribe( data =>
        {
            this.cities = data;
            this.model.city = this.cities.find(c => c.id == 'kiev').name;
            let cityId = this.cities.find(c => c.id == 'kiev').id;
    
            this.cinemaService.getAllByCity(cityId).subscribe( data =>
            {
                this.cinemas = data.sort();
                this.model.cinema = this.cinemas[0].name;
            });
        });
    }
  }

  
  onEnterToAdmin(){
    this.user = this.convertToUser(this.model);   
    this.userService.isExist(this.user).subscribe(user =>
      {
         let cinema = user.cinemaId == null ? 'admin' : user.cinemaId;
         let quid = this.uuidv4();
         sessionStorage.setItem("sessionId", quid);          
         this.router.navigate([quid, cinema, user.id]);      
      },err =>{
        this.wrongLogin = true;
        console.error("wrong login or password"); 
      } );
  }

  onWindowReload(){
    window.location.reload();
  }

  onSelectCity(cityName: string){
    this.cityId = this.cities.find(c => c.name == cityName).id;   
    this.cinemaService.getAllByCity(this.cityId).subscribe( data =>
      {
          this.cinemas = data.sort();
          this.model.cinema = this.cinemas[0].name;         
      });
  }

  convertToUser(model: any): User{
    this.user = new User();
    let cinemaId = this.cinemas.find(c => c.name == model.cinema).id;
    this.user.init(model.login, model.password, cinemaId);
    return  this.user;
  }

  private uuidv4(): any{
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

}
