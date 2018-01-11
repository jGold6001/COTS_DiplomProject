import { Component, OnInit, Inject, Input, ElementRef, Renderer2, ViewChild, ViewContainerRef, ComponentRef, ComponentFactoryResolver} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Seance } from '../shared/models/seance.model';
import { DOCUMENT } from '@angular/common';
import { DomService } from '../shared/services/dom.service';
import { Hall1Component } from '../halls/kiev/mpx_skymall/hall-1/hall-1.component';

@Component({
  selector: 'app-hall-dialog',
  templateUrl: './hall-dialog.component.html',
  styleUrls: ['./hall-dialog.component.css']
})

export class HallDialogComponent implements OnInit {

  @ViewChild('container', { read: ViewContainerRef })
    container: ViewContainerRef;


  seance: Seance;

  type: string;
  context: any;
  
  private componentRef: ComponentRef<{}>;


  private mappings = {
    'hall_1': Hall1Component
};

  constructor(
    public dialogRef: MatDialogRef<HallDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private domService: DomService,
    private componentFactoryResolver: ComponentFactoryResolver
  )
    { }

  ngOnInit() {
    this.seance = this.data.seance;
    
    this.type = "hall_1";
    if (this.type) {
      let componentType = this.getComponentType(this.type);
      
      var dom_ = this.domService.createDom(componentType);

      // note: componentType must be declared within module.entryComponents
      let factory = this.componentFactoryResolver.resolveComponentFactory(componentType);
      this.componentRef = this.container.createComponent(factory);

  }

  }

  onNoClick(): void {
    this.dialogRef.close();
  }


  getComponentType(typeName: string) {
    let type = this.mappings[typeName];
    return type;
  }

}
