import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';
import { Place } from '../models/place.model';

@Injectable()
export class DataService{
    
    private placesSelectedSource = new Subject<Place>();
    private placesCanceledSource = new Subject<Place>();    
    private seanceIdSource  = new Subject<any>();
    private placesRemovedSource = new Subject<Place>();

    placesSelected$ = this.placesSelectedSource.asObservable();  
    placesCanceles$ = this.placesCanceledSource.asObservable();  
    placesRemoved$ = this.placesRemovedSource.asObservable();  
    seanceId$ = this.seanceIdSource.asObservable();

    selectPlace(place: Place){
        this.placesSelectedSource.next(place);
    }

    cancelPlace(place: Place){
        this.placesCanceledSource.next(place);
    }

    setSeanceId(seanceId: any){       
        this.seanceIdSource.next(seanceId);
    }

    removePlace(place: Place){
        this.placesRemovedSource.next(place);
    }

}