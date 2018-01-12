import { Component, OnInit, Inject, Input, ElementRef, Renderer2, ViewChild, ViewContainerRef, ComponentRef, ComponentFactoryResolver} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Seance } from '../../../shared/models/seance.model';
import { DomService } from '../../../shared/services/dom.service';
import { CitiesMappings } from '../../../shared/mappings-consts/cities/cities.mappings';
import { DeliverService } from '../../../shared/services/deliver.service';
import { Router } from '@angular/router';




@Component({
  selector: 'app-hall-dialog',
  templateUrl: './hall-dialog.component.html',
  styleUrls: ['./hall-dialog.component.css']
})

export class HallDialogComponent implements OnInit {

  @ViewChild('container', { read: ViewContainerRef })
    
  container: ViewContainerRef;
  type: string;
  context: any;
  componentRef: ComponentRef<{}>;

  seance: Seance;
  typeInfo: any;

  places: any[] = [];
  show: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService,
    private deliverService: DeliverService,
    private router: Router
  )
  { }

  ngOnInit() {
    this.seance = this.data.seance;

    let typeInfo = {
      city:    "kiev",              //this.seance.cinema.cityId,
      cinema:   "mpx_skymall",      //this.seance.cinema.id,
      hall:     "1"                //this.seance.hall
    };

    let componentType = this.getComponentType(typeInfo);
    let factory = this.domService.createFactory(componentType);
    this.componentRef = this.container.createComponent(factory);


    this.deliverService.placesSelected$.subscribe( place =>
      {
        this.places.push(place);
        this.show = true;
      }
    );

  }

  buy(){
       
    let tickets: any[] = [];
    for(let place of this.places){
      let ticket = {
        movie: this.seance.movie.name,
        cinema: this.seance.cinema.name,
        hall: this.seance.hall,
        place: place
      }
      tickets.push(ticket);
    }
    
    this.router.navigate(["purchase"]);
    this.dialogRef.close();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  getComponentType(typeInfo: any) {
    return CitiesMappings.city[typeInfo.city].cinema[typeInfo.cinema].hall[typeInfo.hall];
  }

}
