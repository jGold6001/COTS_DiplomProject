import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { Movie } from '../../../shared/models/movie.model';
import { MatTableDataSource, MatDialog, MatSort } from '@angular/material';
import { MovieDialogComponent } from '../movie-dialog/movie-dialog.component';

@Component({
  selector: 'app-movie-block',
  templateUrl: './movie-block.component.html',
  styleUrls: ['./movie-block.component.css']
})
export class MovieBlockComponent implements OnInit {

  typesOfShoes = ['Властилин Колец','Шматрица','Буря в стакане'];
  displayedColumns = ['position', 'name', 'genre', 'full_info', 'edit', 'delete'];
  categories =['Все', 'Премьеры', 'Скоро будет'];
  selectedCategory: string;

  enable: boolean;

  movieControl = new FormControl();

  options = [
    new MovieExemple('Властилин Колец'),
    new MovieExemple('Шматрица'),
    new MovieExemple('Буря в стакане')
  ];

  filteredOptions: Observable<MovieExemple[]>;
  dataSource = new MatTableDataSource(ELEMENT_DATA);
  @ViewChild(MatSort) sort: MatSort;
  
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.enable = false;
    this.selectedCategory = this.categories[0];
    
    this.filteredOptions = this.movieControl.valueChanges
    .pipe(
      startWith<string | MovieExemple>(''),
      map(value => typeof value === 'string' ? value : value.name),
      map(name => name ? this.filter(name) : this.options.slice())
    );
  }

  filter(name: string): MovieExemple[] {
    return this.options.filter(option =>
      option.name.toLowerCase().indexOf(name.toLowerCase()) === 0);
  }

  displayFn(MovieView?: MovieView): string | undefined {
    return MovieView ? MovieView.name : undefined;
  }

  clickEdit(id: number){
    console.info(`edit ${id}`);
  }

  clickDelete(id: number){
    console.info(`delete ${id}`);
  }

  clickFullInfo(id: number){
    console.info(`fullInfo ${id}`);
  }

  clickAdd(){
    let dialogRef = this.dialog.open(MovieDialogComponent, {
      width: '800px',
      disableClose: true,
      data: { destiny: 'add'}    
    });

    dialogRef.afterClosed().subscribe(() => {
      
    });

  }
}

export class MovieExemple {
  constructor(public name: string) { }
}

export interface MovieView {
  id: number;
  position: number;
  name: string;
  genre: string;
}


const ELEMENT_DATA: MovieView[] = [
  {position: 1, id: 23, name: "Салют-7", genre: "Драма"  },
  {position: 2, id: 26, name: "Буря в стакане", genre: "Комедия" },
  {position: 3, id: 28, name: "Рокки Бальбоа", genre: "Спорт Драма"},
  {position: 4, id: 29, name: "Джуманджи", genre: "Фантастика" }
];