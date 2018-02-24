import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rating-movies',
  templateUrl: './rating-movies.component.html',
  styleUrls: ['./rating-movies.component.css']
})
export class RatingMoviesComponent implements OnInit {

  //movies = ['Властилин Колец','',''];
  movies: any[] = [];

  constructor() { }

  ngOnInit() {
    let movie_1 = { name: 'Властилин Колец', rating: 1};
    let movie_2 = { name: 'Шматрица', rating: 7};
    let movie_3 = { name: 'Буря в стакане', rating: 5};
    let movie_4 = { name: 'Джуманджи', rating: 3};
    let movie_5 = { name: 'Мстители', rating: 2};
    this.movies.push(movie_1);
    this.movies.push(movie_2);
    this.movies.push(movie_3);
    this.movies.push(movie_4);
    this.movies.push(movie_5);

    this.movies.sort((m1,m2) => 
      {
        return m2.rating-m1.rating;
      });
    console.log(this.movies);
  }

}
