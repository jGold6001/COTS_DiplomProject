//modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationRef, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule, JsonpModule} from "@angular/http";
import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { CommonModule, DatePipe } from '@angular/common';

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

//services
import { GeocodingApiService } from './shared/services/geocodingApi.service';
import { MovieService } from './shared/services/movie.service';
import { CityService } from './shared/services/city.service';
import { CinemaService } from './shared/services/cinema.service';
import { SeanceService } from './shared/services/seance.service';
import { DomService } from './shared/services/dom.service';

//my components
import { AppComponent } from './app.component';
import { MainPageComponent } from './components/main-page.components/main-page/main-page.component';
import { MoviePageComponent } from './components/movie-page.components/movie-page/movie-page.component';
import { CinemaPageComponent } from './components/cinema-page.components/cinema-page/cinema-page.component';
import { MoviesCardsComponent } from './components/main-page.components/movies-cards/movies-cards.component';
import { CinemasMapComponent } from './components/main-page.components/cinemas-map/cinemas-map.component';
import { CinemasCardsComponent } from './components/main-page.components/cinemas-cards/cinemas-cards.component';
import { SeancesByCinemasComponent } from './components/movie-page.components/seances-by-cinemas/seances-by-cinemas.component';
import { CinemasListComponent } from './components/movie-page.components/cinemas-list/cinemas-list.component';
import { HallDialogComponent } from './components/hall-dialog.components/hall-dialog/hall-dialog.component';
import { DataService } from './shared/services/data.service';
import { PurchasePageComponent } from './components/purchase-page.components/purchase-page/purchase-page.component';
import { TicketService } from './shared/services/ticket.service';
import { HttpClientModule } from '@angular/common/http';
import { TicketsDialogComponent } from './components/purchase-page.components/tickets-dialog/tickets-dialog.component';
import { PurchaseService } from './shared/services/purchase.service';
import { PlaceService } from './shared/services/place.service';
import { SectorService } from './shared/services/sector.service';


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
    CinemasListComponent,
    HallDialogComponent,
    PurchasePageComponent,
    TicketsDialogComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule,
    JsonpModule,
    HttpClientModule,
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
    MatStepperModule
  ],
  entryComponents: [
    SeancesByCinemasComponent, 
    HallDialogComponent,
    TicketsDialogComponent
  ],
  providers: [
    GeocodingApiService,
    MovieService, 
    SectorService,
    CityService, 
    CinemaService,
    SeanceService,
    DatePipe,
    DomService,
    DataService,
    TicketService,
    PlaceService,
    PurchaseService,
    { provide: LOCALE_ID, useValue: "ru" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
