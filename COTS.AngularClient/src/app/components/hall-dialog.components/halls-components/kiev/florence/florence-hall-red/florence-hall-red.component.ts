import { Component, OnInit, ElementRef, Renderer2, Renderer } from '@angular/core';
import { ViewChild } from '@angular/core';
import { COMPONENT_VARIABLE } from '@angular/platform-browser/src/dom/dom_renderer';
import { Place } from '../../../../../../shared/models/place.model';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-florence-hall-red',
  templateUrl: './florence-hall-red.component.html',
  styleUrls: ['./florence-hall-red.component.css']
})
export class FlorenceHallRedComponent implements OnInit {

  canvas: any;
  
  width: number = 640;
  height: number = 320;

  widthSeat: number = 20;
  heightSeat: number = 20;

  padding: number = 50;
  intervalX: number = 10;
  intervalY: number = 10;

  seats: any[] = [];
  places: Place[] = [];

  constructor( 
    private elRef: ElementRef, 
    private rd: Renderer2
  ) { }

  ngOnInit() {
      this.canvas = this.elRef.nativeElement.querySelector("#myCanvas"); 
      this.canvas.width = this.width;
      this.canvas.height = this.height;
      this.canvas.addEventListener('mousedown', (evt) => {this.clickOnSeat(evt);}, false);

      this.createSeats();
  }

  createCtx(color: string, x: number, y: number) : any{
      let ctx = this.canvas.getContext("2d");
      ctx.fillStyle = color;
      ctx.fillRect(x,y, this.widthSeat, this.heightSeat);
      return ctx;
  }

  clickOnSeat(evt){
     if(evt.offsetX > 100 && evt.offsetX < 100 + this.widthSeat && evt.offsetY > 100 && evt.offsetY < 100 + this.heightSeat)
        console.log("green");
      else if(evt.offsetX > 140 && evt.offsetX < 140 + this.widthSeat && evt.offsetY > 100 && evt.offsetY < 100 + this.heightSeat)
        console.log("red");
  }

  createSeats(){
    let x, y, color="green";
    let countPlaces = this.getPlaces().length; 
    for(let i=0; i<countPlaces; i++){
      if(i == 0){
          x = this.padding;
          y = this.padding;        
      }else{
        x = this.widthSeat + this.intervalX;
        y = this.heightSeat + this.intervalY;
      }
      this.createCtx(color, x, y);
    }
  }

  getPlaces(): Place[]{
    for(let i= 0; i<5; i++){
      let place = new Place();
      let index = i+1;
      place.init(index, index, 1, false,1, 1);
      this.places.push(place);
    }
    return this.places;
  }



}
