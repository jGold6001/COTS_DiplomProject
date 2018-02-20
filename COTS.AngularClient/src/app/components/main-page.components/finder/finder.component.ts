import { Component, OnInit, Input, SimpleChanges,} from '@angular/core';
import { FormControl } from '@angular/forms';


import {Observable} from 'rxjs/Observable';
import {startWith} from 'rxjs/operators/startWith';
import {map} from 'rxjs/operators/map';
import { Cinema } from '../../../shared/models/cinema.model';
import { Movie } from '../../../shared/models/movie.model';
import { CinemaService } from '../../../shared/services/cinema.service';
import { MovieService } from '../../../shared/services/movie.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-finder',
  templateUrl: './finder.component.html',
  styleUrls: ['./finder.component.css']
})
export class FinderComponent implements OnInit {

  finderCtrl: FormControl= new FormControl();
  filteredData: Observable<any[]>;
  
  movies: Movie[];
  cinemas: Cinema[];
  cityId: string;

  objects: any[] = [];

  constructor( 
    private router: Router,
    private route: ActivatedRoute, 
    private movieService: MovieService,
    private cinemaService: CinemaService
  ) {}

  ngOnInit() {   
    this.route.params.subscribe(params => {
      this.cityId = params['cityId'];
    });
    
    this.cityId = this.cityId == null ? 'kiev' : this.cityId;
    
    this.cinemaService.getAllByCity(this.cityId)
      .subscribe(r =>{
        this.cinemas = r;
        this.movieService.getTop10ByCity(this.cityId)
        .subscribe(r =>{
          this.movies = r;
          this.selection();
        });
      } ,);

  }

  selection(){
    this.createArray();
    
    this.filteredData = this.finderCtrl.valueChanges
      .pipe(
        startWith(''),
        map(object => object ? this.filterData(object) : this.objects.slice())
      ); 
  }

  createArray(){ 
    for(let cinema of this.cinemas){    
      let _object = {
        name: cinema.name,
        id: cinema.id,
        type: "cinema", 
        img: 'https://d30y9cdsu7xlg0.cloudfront.net/png/128002-200.png' 
      }        
      this.objects.push(_object);
    }

    for(let movie of this.movies){
      let _object = {
        name: movie.name,
        id: movie.id,
        type: "movie",
        img: 'http://www.clker.com/cliparts/c/b/6/c/13663719191300658152cinema.svg.hi.png' 
      }
      this.objects.push(_object);
    } 
  
    this.objects.sort((a,b) => {return (a.name > b.name) ? 1 : ((b.name > a.name) ? -1 : 0);});
  }

  filterData(name: string) {
    return this.objects.filter((object, i , a) =>
      object.name.toLowerCase().indexOf(name.toLowerCase()) === 0);  
  }


  onDataSelect(object: any){
    
    if(object.type == "movie")
        this.router.navigate([this.cityId, object.type, object.id]);
    else
        this.router.navigate([this.cityId, object.type, object.id]);
  }


}
