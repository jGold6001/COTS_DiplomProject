import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../../../../shared/services/data.service';
import { Place } from '../../../../../../shared/models/place.model';


@Component({
  selector: 'app-mpx-skymall-hall-1',
  templateUrl: './mpx-skymall-hall-1.component.html',
  styleUrls: ['./mpx-skymall-hall-1.component.css']
})
export class MpxSkymallHall1Component implements OnInit {

  place: Place;

  tariff = "simple";
  price = 100;

  constructor(
    private dataService: DataService
  ) { }

  ngOnInit() {
  }

  myEvent_1(){
    
    this.place = new Place()
    this.place.init(1, 1,this.tariff, this.price);
    this.dataService.selectPlaces(this.place);
  }

  myEvent_2(){
    this.place = new Place()
    this.place.init(2, 2,this.tariff, this.price);
    this.dataService.selectPlaces(this.place);
  }

  myEvent_3(){
    this.place = new Place()
    this.place.init(3, 3,this.tariff, this.price);
    this.dataService.selectPlaces(this.place);
  }

}
