import { Component, OnInit } from '@angular/core';
import { CityService } from '../../../shared/services/city.service';
import { CinemaService } from '../../../shared/services/cinema.service';
import { City } from '../../../shared/models/city.model';
import { Cinema } from '../../../shared/models/cinema.model';

@Component({
  selector: 'app-authentication-dialog',
  templateUrl: './authentication-dialog.component.html',
  styleUrls: ['./authentication-dialog.component.css']
})
export class AuthenticationDialogComponent implements OnInit {

  model: any={};
  cities: City[] =[];
  cinemas: Cinema[] = [];

  constructor(
    private cityService: CityService,
    private cinemaService: CinemaService
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
    console.log(this.model);
  }

  onSelectCity(cityName: string){
    let cityId = this.cities.find(c => c.name == cityName).id;
    this.cinemaService.getAllByCity(cityId).subscribe( data =>
      {
          this.cinemas = data.sort();
          this.model.cinema = this.cinemas[0].name;
      });
  }

}
