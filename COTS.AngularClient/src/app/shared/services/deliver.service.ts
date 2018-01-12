import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';

@Injectable()
export class DeliverService{
    
    private placesSelectedSource = new Subject<any>();

    placesSelected$ = this.placesSelectedSource.asObservable();
    
    selectPlaces(place: any){
        this.placesSelectedSource.next(place);
    }

}