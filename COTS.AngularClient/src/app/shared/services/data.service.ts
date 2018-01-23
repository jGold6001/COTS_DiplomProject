import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';
import { Place } from '../models/place.model';

@Injectable()
export class DataService{
    
    private placesSelectedSource = new Subject<Place>();
    private placesCanceledSource = new Subject<Place>();
    
    placesSelected$ = this.placesSelectedSource.asObservable();  
    placesCanceles$ = this.placesCanceledSource.asObservable();

    selectPlace(place: Place){
        this.placesSelectedSource.next(place);
    }

    cancelPlace(place: Place){
        this.placesCanceledSource.next(place);
    }

}