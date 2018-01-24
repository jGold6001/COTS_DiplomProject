import {
    Injectable,
    Injector,
    ComponentFactoryResolver,
    EmbeddedViewRef,
    ApplicationRef,
    ComponentRef
} from '@angular/core';


@Injectable()
export class DomService {
  
  constructor(
      private componentFactoryResolver: ComponentFactoryResolver,
  ) { }
  
  createFactory(component: any) {
    return  this.componentFactoryResolver
      .resolveComponentFactory(component);
  }
    
}