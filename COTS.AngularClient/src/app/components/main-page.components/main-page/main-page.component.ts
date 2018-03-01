import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl} from '@angular/forms';
import { Observable} from 'rxjs/Observable';
import { startWith} from 'rxjs/operators/startWith';
import { map} from 'rxjs/operators/map';
import "rxjs/add/operator/map";
import { City } from '../../../shared/models/city.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Movie } from '../../../shared/models/movie.model';
import { MovieService } from '../../../shared/services/movie.service';
import { CinemaService } from '../../../shared/services/cinema.service';
import { CityService } from '../../../shared/services/city.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit{

  cityCtrl: FormControl = new FormControl();
  filteredCities: Observable<any[]>;

  rerender = false;
  isLoad= false;

  cities: City[] = [];
  cinemas: Cinema[] = [];
  moviesPremeries: Movie[] = [];
  moviesComingSoon: Movie[] = [];
  moviesTop10: Movie[] = [];

  currentCity: City;
  
  constructor(
    private router: Router, 
    private cdRef:ChangeDetectorRef,
    private movieService: MovieService,
    private cinemaService: CinemaService,
    private cityService: CityService
  ) { }

  ngOnInit() {  

    this.loading();
    
    this.cityService.getAll()
      .subscribe(r =>{
          this.cities = r;
          this.initCityInput();
        }, () => console.error("Ошибка при получении данных с сервера"));
  }
  

  loading(){
    setTimeout(() => {
      this.isLoad= true;
    }, 2000)
  }

  onCitySelect(city: City){
    this.router.navigate([city.id]);
    this.setInputFild(city.id);
    
    this.doRerender();
  }

  private setInputFild(cityId: string){
    this.currentCity = this.cities.find(c => c.id == cityId);;
    this.initMoviesArrays(cityId); 
    this.initCinemaArray(cityId);  

    this.cityCtrl.setValue(this.currentCity.name);
    this.filteredCities = this.cityCtrl.valueChanges
      .pipe(
        startWith(''),
        map(city => city ? this.filterCities(city) : this.cities.slice())
    ); 
  }

  private initCityInput(){
    let cityId = this.router.url.substring(1);
    if(cityId != "")
        this.setInputFild(cityId);
    else
       this.setInputFild('kiev');      
  }

  private initMoviesArrays(cityId: string){
    this.movieService.getAllPremeriesByCity(cityId)
      .subscribe(r => this.moviesPremeries = r, () => console.error("Ошибка при получении данных с сервера"));

      this.movieService.getAllCommingSoonByCity(cityId)
      .subscribe(r => this.moviesComingSoon = r, () => console.error("Ошибка при получении данных с сервера"));

      this.movieService.getTop10ByCity(cityId)
      .subscribe(r => this.moviesTop10 = r, () => console.error("Ошибка при получении данных с сервера"));

  }

  private initCinemaArray(cityId: string){
    this.cinemaService.getAllByCity(cityId)
      .subscribe(r => this.cinemas = r,  () => console.error("Ошибка при получении данных с сервера"));
  }

 

  private filterCities(name) {
    return this.cities.filter(city =>
      city.name.toLowerCase().indexOf(name.toLowerCase()) === 0);
  }

  
  private doRerender() {
    this.loading();
    this.rerender = true;
    this.cdRef.detectChanges();
    this.rerender = false;    
  }

}
