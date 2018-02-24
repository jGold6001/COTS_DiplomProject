import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { Movie } from '../../../shared/models/movie.model';

@Component({
  selector: 'app-movie-block',
  templateUrl: './movie-block.component.html',
  styleUrls: ['./movie-block.component.css']
})
export class MovieBlockComponent implements OnInit {

  typesOfShoes = ['Властилин Колец','Шматрица','Буря в стакане'];

  categories =['Все', 'Премьеры', 'Скоро будет'];
  selectedCategory: string;

  enableList: boolean;

  movieControl = new FormControl();

  options = [
    new MovieExemple('Властилин Колец'),
    new MovieExemple('Шматрица'),
    new MovieExemple('Буря в стакане')
  ];

  filteredOptions: Observable<MovieExemple[]>;

  constructor() { }

  ngOnInit() {
    this.enableList = false;
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

  displayFn(MovieExemple?: MovieExemple): string | undefined {
    return MovieExemple ? MovieExemple.name : undefined;
  }

}

export class MovieExemple {
  constructor(public name: string) { }
}