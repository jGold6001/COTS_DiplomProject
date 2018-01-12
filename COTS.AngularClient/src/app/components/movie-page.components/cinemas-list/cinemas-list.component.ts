import { Component, OnInit, Input, SimpleChanges,} from '@angular/core';
import { DatePipe } from '@angular/common'
import { UrlTree, UrlSegmentGroup, UrlSegment, Router, PRIMARY_OUTLET } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { Cinema } from '../../../shared/models/cinema.model';
import { Seance } from '../../../shared/models/seance.model';
import { SeanceService } from '../../../shared/services/seance.service';

@Component({
  selector: 'app-cinemas-list',
  templateUrl: './cinemas-list.component.html',
  styleUrls: ['./cinemas-list.component.css']
})
export class CinemasListComponent implements OnInit {

  @Input() cinema: Cinema;
  @Input() date: Date;

  seances: Seance[] =[];

  constructor( 
    private seanceService: SeanceService,
    private router: Router
  ) { }

  ngOnInit() {
    this.seanceService.getAllByCinemaMovieDate(this.cinema.id, this.movieId, this.date)
        .subscribe(r =>{
            this.seances = r; 
        } , () => console.error("Ошибка при получении данных с сервера"));

  }

  ngOnChanges(changes: SimpleChanges) {
   
  }

  get movieId(): number{
    const tree: UrlTree = this.router.parseUrl( this.router.url);
    const g: UrlSegmentGroup = tree.root.children[PRIMARY_OUTLET];
    const s: UrlSegment[] = g.segments;
    return +s[2].path;
  }

}
