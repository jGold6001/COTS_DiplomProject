import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../../../../../shared/services/data.service';
import { Place } from '../../../../../../shared/models/place.model';
import {ElementRef,Renderer2} from '@angular/core';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-mpx-skymall-hall-1',
  templateUrl: './mpx-skymall-hall-1.component.html',
  styleUrls: ['./mpx-skymall-hall-1.component.css']
})
export class MpxSkymallHall1Component implements OnInit {

  buttons: any = [];

  constructor(
    private dataService: DataService,
    private rd: Renderer2,
    private elRef:ElementRef
  ) { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.createButtonsId(); 
    this.clickEvents(); 
  }

  createButtonsId(){
    this.buttons = this.elRef.nativeElement.getElementsByClassName("btn");
    for(let i=0; i<this.buttons.length; i++){
      this.rd.setAttribute(this.buttons[i], 'div', `btn_${i}`);
    }
  }

   clickEvents(){
      for(let item in this.buttons){
        let button = this.elRef.nativeElement.querySelector(`#btn_${item}`);
        this.rd.listen(button, 'click', (event)=>{
          console.log("event");
        });
      }
   }

}
