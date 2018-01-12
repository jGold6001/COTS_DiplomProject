import { Component, OnInit, Inject, Input, ElementRef, Renderer2, ViewChild, ViewContainerRef, ComponentRef, ComponentFactoryResolver} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Seance } from '../shared/models/seance.model';
import { DomService } from '../shared/services/dom.service';
import { CitiesMappings } from '../mappings-consts/cities/cities.mappings';



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


  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService
  )
  { }

  ngOnInit() {
    this.seance = this.data.seance;

    let typeInfo = {
      city:                  this.seance.cinema.cityId,
      cinema:        this.seance.cinema.id,
      hall:                     this.seance.hall
    };

    let componentType = this.getComponentType(typeInfo);
    let factory = this.domService.createFactory(componentType);
    this.componentRef = this.container.createComponent(factory);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  getComponentType(typeInfo: any) {
    return CitiesMappings.city[typeInfo.city].cinema[typeInfo.cinema].hall[typeInfo.hall];
  }

}
