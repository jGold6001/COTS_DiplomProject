import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-employee-block',
  templateUrl: './employee-block.component.html',
  styleUrls: ['./employee-block.component.css']
})
export class EmployeeBlockComponent implements OnInit {

  enableList: boolean;
  typesOfShoes = ['Employee_1','Employee_2','Employee_3'];
  
  movieControl = new FormControl();
  filteredOptions: Observable<MovieExemple[]>;

  options = [
    new MovieExemple('Шпаков Борис'),
    new MovieExemple('Соколов Кузьма'),
    new MovieExemple('Ленин Владимир')
  ];

  
  constructor() { }

  ngOnInit() {
    this.enableList = false;
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