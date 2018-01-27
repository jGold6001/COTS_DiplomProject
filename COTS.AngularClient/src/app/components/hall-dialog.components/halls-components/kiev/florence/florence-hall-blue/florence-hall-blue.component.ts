import { Component, OnInit, Input, Renderer2, ElementRef } from '@angular/core';
import { Place } from '../../../../../../shared/models/place.model';
import { DataService } from '../../../../../../shared/services/data.service';
import { PlaceService } from '../../../../../../shared/services/place.service';

@Component({
  selector: 'app-florence-hall-blue',
  templateUrl: './florence-hall-blue.component.html',
  styleUrls: ['./florence-hall-blue.component.css']
})
export class FlorenceHallBlueComponent implements OnInit {

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
    this.placeService.getDataFromJsonFile('kiev', 'florence', 'Синий')
      .subscribe( res =>{
        this.places = res;      
        this.createButtons(); 
        this.clickEvents(); 
      }, err => console.log("File not reading!!!"));
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

    if(this.buttons.length == this.places.length){
      
      for(let i=0; i<this.places.length; i++){
        this.rd.addClass(this.buttons[i], "btn");  
  
        if(this.places[i].isBusy){
           this.rd.setAttribute(this.buttons[i], "disabled", 'true');
        }else{
           this.rd.addClass(this.buttons[i], "btn-primary");
        }               
        this.rd.setAttribute(this.buttons[i], 'id', `btn_${this.places[i].id}`);  
      }
    }else{
        console.error(`Arrays of Buttons: ${this.buttons.length} and Places: ${this.places.length} not equal`);
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

   getPlace(button): Place {
      let placeId = button.id.split("_",2)[1];
      return this.places.find(p => p.id == placeId);
   }

   passToHallDialog(_place: Place){
     
      if(!this.placesSelected.includes(_place)){
        this.placesSelected.push(_place);
        this.dataService.selectPlace(_place);
      }else{        
        this.dataService.cancelPlace(_place);
        this.deleteObjectFromArray(_place.id);
      }
       
   }

   private deleteObjectFromArray(id){
    for(let place of this.placesSelected){
      if(place.id == id)
        this.placesSelected.splice(this.placesSelected.indexOf(place),1);
    }
  }

}