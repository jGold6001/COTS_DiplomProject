import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../../../../../shared/services/data.service';
import { Place } from '../../../../../../shared/models/place.model';
import {ElementRef,Renderer2} from '@angular/core';
import { forEach } from '@angular/router/src/utils/collection';
import { PlaceService } from '../../../../../../shared/services/place.service';
import { last } from 'rxjs/operator/last';
import { loadavg } from 'os';

@Component({
  selector: 'app-mpx-skymall-hall-1',
  templateUrl: './mpx-skymall-hall-1.component.html',
  styleUrls: ['./mpx-skymall-hall-1.component.css']
})
export class MpxSkymallHall1Component implements OnInit {

  buttons: any = [];
  places: Place[] = [];
  placesSelected: Place[] = [];

  constructor(
    private dataService: DataService,
    private rd: Renderer2,
    private elRef:ElementRef,
    private placeService: PlaceService
  ) { }


  ngOnInit() {
    this.placeService.getDataFromJsonFile('kiev', 'mpx-skymall', '1')
      .subscribe( res =>{
        this.places = res;
        this.setIdPlaces();
      }, err => console.log("File not reading!!!"));
  }

  ngAfterViewInit() {
    this.createButtons(); 
    this.clickEvents(); 
  }

  
   clickEvents(){      
      for(let item in this.buttons){
        let button = this.elRef.nativeElement.querySelector(`#btn_${item}`);
        if(button){
            this.rd.listen(button, 'click', (event)=>{            
              this.changeColor(button);
              let place: Place = this.getPlace(button); 
              this.passToHallDialog(place);
            });
        }        
      }
   }



   createButtons(){
    this.buttons = this.elRef.nativeElement.getElementsByTagName("button");
    
    for(let i=0; i<this.buttons.length; i++){
      this.rd.addClass(this.buttons[i], "btn");
      this.rd.addClass(this.buttons[i], "btn-primary");
      this.rd.setAttribute(this.buttons[i], 'id', `btn_${i}`);
    }
  }


   changeColor(button){
    if(button.classList.contains('btn-primary')){
      button.classList.remove('btn-primary');
      button.classList.add('btn-warning');
    }else{
      button.classList.remove('btn-warning');
      button.classList.add('btn-primary');                
    }
   }

   setIdPlaces(){   
     for(let i=0; i<this.places.length; i++){      
       this.places[i].id = i;
     }    
   }

   getPlace(button): Place {
      let placeId = button.id.split("_",2)[1];
      return this.places.find(p => p.id == placeId);
   }

   passToHallDialog(_place: Place){
     
      if(!this.placesSelected.includes(_place)){
        this.placesSelected.push(_place);
        this.dataService.selectPlace(_place);
      }else{        
        this.dataService.cancelPlace(_place.id);
        //this.placesSelected[_place.id];
      }
       
   }

}
