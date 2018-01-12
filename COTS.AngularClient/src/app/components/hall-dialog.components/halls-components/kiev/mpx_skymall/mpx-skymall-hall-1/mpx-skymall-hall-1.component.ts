import { Component, OnInit } from '@angular/core';
import { DeliverService } from '../../../../../../shared/services/deliver.service';

@Component({
  selector: 'app-mpx-skymall-hall-1',
  templateUrl: './mpx-skymall-hall-1.component.html',
  styleUrls: ['./mpx-skymall-hall-1.component.css']
})
export class MpxSkymallHall1Component implements OnInit {

  info: any;

  constructor(
    private deliverService: DeliverService
  ) { }

  ngOnInit() {
  }

  myEvent_1(){
    let place = {
      num:1, row:1
    }

    this.deliverService.selectPlaces(place);
  }

  myEvent_2(){
    let place = {
      num:2, row:2
    }

    this.deliverService.selectPlaces(place);
  }

  myEvent_3(){
    let place = {
      num:3, row:3
    }

    this.deliverService.selectPlaces(place);
  }

}
