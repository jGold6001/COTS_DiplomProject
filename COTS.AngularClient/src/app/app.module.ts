//modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationRef, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
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
import { MainPageComponent } from './main-page/main-page.component';
import { MoviePageComponent } from './movie-page/movie-page.component';
import { CinemaPageComponent } from './cinema-page/cinema-page.component';
import { MoviesCardsComponent } from './movies-cards/movies-cards.component';
import { CinemasMapComponent } from './cinemas-map/cinemas-map.component';
import { CinemasCardsComponent } from './cinemas-cards/cinemas-cards.component';
import { SeancesByCinemasComponent } from './seances-by-cinemas/seances-by-cinemas.component';
import { CinemasListComponent } from './cinemas-list/cinemas-list.component';
import { HallDialogComponent } from './hall-dialog/hall-dialog.component';
import { MpxSkymallHall1Component } from './halls-components/kiev/mpx_skymall/mpx-skymall-hall-1/mpx-skymall-hall-1.component';
import { MpxSkymallHall2Component } from './halls-components/kiev/mpx_skymall/mpx-skymall-hall-2/mpx-skymall-hall-2.component';
import { MpxSkymallHall3Component } from './halls-components/kiev/mpx_skymall/mpx-skymall-hall-3/mpx-skymall-hall-3.component';
import { MpxSkymallHall4Component } from './halls-components/kiev/mpx_skymall/mpx-skymall-hall-4/mpx-skymall-hall-4.component';
import { MpxProspectHall1Component } from './halls-components/kiev/mpx_prospect/mpx-prospect-hall-1/mpx-prospect-hall-1.component';
import { MpxProspectHall2Component } from './halls-components/kiev/mpx_prospect/mpx-prospect-hall-2/mpx-prospect-hall-2.component';
import { MpxProspectHall4Component } from './halls-components/kiev/mpx_prospect/mpx-prospect-hall-4/mpx-prospect-hall-4.component';
import { MpxProspectHall5Component } from './halls-components/kiev/mpx_prospect/mpx-prospect-hall-5/mpx-prospect-hall-5.component';
import { FlorenceHallBigComponent } from './halls-components/kiev/florence/florence-hall-big/florence-hall-big.component';
import { FlorenceHallLittleComponent } from './halls-components/kiev/florence/florence-hall-little/florence-hall-little.component';
import { FlorenceHallRedComponent } from './halls-components/kiev/florence/florence-hall-red/florence-hall-red.component';
import { FlorenceHallBlueComponent } from './halls-components/kiev/florence/florence-hall-blue/florence-hall-blue.component';
import { MpxDafiHall2Component } from './halls-components/harkov/mpx_dafi/mpx-dafi-hall-2/mpx-dafi-hall-2.component';
import { MpxDafiHall3Component } from './halls-components/harkov/mpx_dafi/mpx-dafi-hall-3/mpx-dafi-hall-3.component';
import { MpxDafiHall4Component } from './halls-components/harkov/mpx_dafi/mpx-dafi-hall-4/mpx-dafi-hall-4.component';
import { MpxDafiHall6Component } from './halls-components/harkov/mpx_dafi/mpx-dafi-hall-6/mpx-dafi-hall-6.component';
import { MpxDafiHall7Component } from './halls-components/harkov/mpx_dafi/mpx-dafi-hall-7/mpx-dafi-hall-7.component';

//halls


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
    MpxSkymallHall1Component,
    MpxSkymallHall2Component,
    MpxSkymallHall3Component,
    MpxSkymallHall4Component,
    MpxProspectHall1Component,
    MpxProspectHall2Component,
    MpxProspectHall4Component,
    MpxProspectHall5Component,
    FlorenceHallBigComponent,
    FlorenceHallLittleComponent,
    FlorenceHallRedComponent,
    FlorenceHallBlueComponent,
    MpxDafiHall2Component,
    MpxDafiHall3Component,
    MpxDafiHall4Component,
    MpxDafiHall6Component,
    MpxDafiHall7Component
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
  entryComponents: [SeancesByCinemasComponent, HallDialogComponent,
    MpxSkymallHall1Component,
    MpxSkymallHall2Component,
    MpxSkymallHall3Component,
    MpxSkymallHall4Component,
    MpxProspectHall1Component,
    MpxProspectHall2Component,
    MpxProspectHall4Component,
    MpxProspectHall5Component,
    FlorenceHallBigComponent,
    FlorenceHallLittleComponent,
    FlorenceHallRedComponent,
    FlorenceHallBlueComponent,
    MpxDafiHall2Component,
    MpxDafiHall3Component,
    MpxDafiHall4Component,
    MpxDafiHall6Component,
    MpxDafiHall7Component
  ],
  providers: [GeocodingApiService,
    MovieService, 
    CityService, 
    CinemaService,
    SeanceService,
    DatePipe,
    DomService,
    { provide: LOCALE_ID, useValue: "ru" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
