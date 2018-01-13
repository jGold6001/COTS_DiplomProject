import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';
import { Place } from '../models/place.model';

@Injectable()
export class DataService{
    
    private placesSelectedSource = new Subject<Place>();
    
    placesSelected$ = this.placesSelectedSource.asObservable();
   
    selectPlaces(place: Place){
        this.placesSelectedSource.next(place);
    }

}