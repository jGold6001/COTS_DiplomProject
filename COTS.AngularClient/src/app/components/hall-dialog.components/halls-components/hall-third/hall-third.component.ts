import { Component, OnInit, Renderer2, ElementRef, OnDestroy } from '@angular/core';
import { Place } from '../../../../shared/models/place.model';
import { DataService } from '../../../../shared/services/data.service';
import { PlaceService } from '../../../../shared/services/place.service';
import { ISubscription } from 'rxjs/Subscription';


@Component({
  selector: 'app-hall-third',
  templateUrl: './hall-third.component.html',
  styleUrls: ['./hall-third.component.css']
})
export class HallThirdComponent implements OnInit, OnDestroy {

 
  buttons: any = [];
  places: Place[] = [];
  placesSelected: Place[] = [];
  data: any;
  subscription: ISubscription;
 

  constructor(
    private dataService: DataService,
    private rd: Renderer2,
    private elRef:ElementRef,
    private placeService: PlaceService,
  ) {}


  ngOnInit() {
    this.placeService.getPlacesByCityCinemaHallAndSeance(this.data.city, this.data.cinema, this.data.hall, this.data.seance)
      .subscribe( res =>{            
        this.places = res;     
        
        this.createButtons(); 
        this.clickEvents(); 
      }, err => console.error("File not reading!!!")); 

      this.subscription = this.dataService.placesRemoved$.subscribe( place =>
      {
        let button = this.elRef.nativeElement.querySelector(`#btn_${place.id}`);
        this.changeColor(button, place.sectorId);
        if(!this.placesSelected.includes(place)){
          this.placesSelected.push(place);
        }else{        
          this.deleteObjectFromArray(place.id);
        }
      });
  }

  createButtons(){
    this.buttons = this.elRef.nativeElement.getElementsByClassName("seats_third");

    if(this.buttons.length == this.places.length){
      
      for(let i=0; i<this.places.length; i++){     
        if(this.places[i].isBusy){
           this.rd.setAttribute(this.buttons[i], "disabled", 'true');
        }else{
           this.rd.addClass(this.buttons[i], this.setSectorColor(this.places[i].sectorId));
        }               
        this.rd.setAttribute(this.buttons[i], 'id', `btn_${this.places[i].id}`);  
      }
    }else{
        console.error(`Arrays of Buttons: ${this.buttons.length} and Places: ${this.places.length} not equal`);
    }
    
  }


  clickEvents(){      
    for(let item of this.buttons){          
      let button = this.elRef.nativeElement.querySelector(`#${item.id}`);
        if(button){
              this.rd.listen(button, 'click', (event)=>{   
              let place: Place = this.getPlace(button);   
              this.changeColor(button, place.sectorId);               
              this.passToHallDialog(place);
            });
        }        
      }
   }

  setSectorColor(sectorId: number): string {
    switch(sectorId){
      case 1: return "green-sector";
      case 2: return "red-sector";
      case 3: return "cyan-sector";
      case 4: return "blue-sector";
      case 5: return "good-sector";
      case 6: return "super_lux-sector";
    }
  }

   changeColor(button, sectorId){
    if(button.classList.contains(this.setSectorColor(sectorId))){
      button.classList.remove(this.setSectorColor(sectorId));
      button.classList.add('selected-seat');
    }else{
      button.classList.remove('selected-seat');
      button.classList.add(this.setSectorColor(sectorId));                
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

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
}
