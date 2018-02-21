import { Component, OnInit } from '@angular/core';
import { CityService } from '../../../shared/services/city.service';
import { CinemaService } from '../../../shared/services/cinema.service';
import { City } from '../../../shared/models/city.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { UserService } from '../../../shared/services/user.service';
import { User } from '../../../shared/models/user.model';
import { request } from 'http';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-authentication-dialog',
  templateUrl: './authentication-dialog.component.html',
  styleUrls: ['./authentication-dialog.component.css']
})
export class AuthenticationDialogComponent implements OnInit {

  model: any={};
  user: User;
  cities: City[] =[];
  cinemas: Cinema[] = [];

  constructor(
    public dialogRef: MatDialogRef<AuthenticationDialogComponent>,
    private cityService: CityService,
    private cinemaService: CinemaService,
    private userService: UserService
  ) { }

  ngOnInit() {
   
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

  onTestDialog(){
    this.user = this.convertToUser(this.model);   
    this.userService.isExist(this.user).subscribe(result =>
      {          
        this.dialogRef.close(); 
      },err => console.error("wrong login or password") );
  }

  onSelectCity(cityName: string){
    let cityId = this.cities.find(c => c.name == cityName).id;
    this.cinemaService.getAllByCity(cityId).subscribe( data =>
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

}


