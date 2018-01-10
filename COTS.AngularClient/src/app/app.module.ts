//modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationRef, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';

import { TabsModule } from 'ngx-bootstrap';

import { AgmCoreModule } from '@agm/core';

import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,
} from '@angular/material';

//my components
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-page.component';
import { MoviePageComponent } from './movie-page/movie-page.component';
import { CinemaPageComponent } from './cinema-page/cinema-page.component';
import { MoviesCardsComponent } from './movies-cards/movies-cards.component';
import { CinemasMapComponent } from './cinemas-map/cinemas-map.component';
import { CinemasCardsComponent } from './cinemas-cards/cinemas-cards.component';
import { GeocodingApiService } from './shared/services/geocodingApi.service';
import { MovieService } from './shared/services/movie.service';
import { CityService } from './shared/services/city.service';
import { CinemaService } from './shared/services/cinema.service';
import { SeancesByCinemasComponent } from './seances-by-cinemas/seances-by-cinemas.component';
import { CinemasListComponent } from './cinemas-list/cinemas-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    MoviePageComponent,
    CinemaPageComponent,
    MoviesCardsComponent,
    CinemasMapComponent,
    CinemasCardsComponent,
    SeancesByCinemasComponent,
    CinemasListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    CommonModule,

    TabsModule.forRoot(),

    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDSg-Iu6aNGRmrVX6MMltecTCslVEDUqPo',
      libraries: ["places"]
    }),

    //material imports
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatStepperModule,
  ],
  providers: [GeocodingApiService, 
    MovieService, 
    CityService, 
    CinemaService,
    { provide: LOCALE_ID, useValue: "ru" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
