import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { TicketService } from '../../../shared/services/ticket.service';
import { Observable } from 'rxjs';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Seance } from '../../../shared/models/seance.model';
import { ErrorStateMatcher } from '@angular/material';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-purchase-page',
  templateUrl: './purchase-page.component.html',
  styleUrls: ['./purchase-page.component.css']
})
export class PurchasePageComponent implements OnInit {

  purchase: Purchase;
  tickets: Ticket[] =[];

  seance: Seance = new Seance();
  movie: Movie = new Movie();
  cinema: Cinema= new Cinema();

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  nameFormControl = new FormControl('', [
    Validators.required,
    Validators.maxLength(40)
  ]);

  phoneFormControl = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();


  constructor(
   private route: ActivatedRoute,
   private ticketService: TicketService
  ) 
  {}

  ngOnInit() {

    this.ticketService.getPurchase("test231243")
      .subscribe(data => {
        this.purchase = data;
        this.tickets = this.purchase.tickets;
        this.seance = this.tickets[0].seance;
        this.movie = this.seance.movie;
        this.cinema = this.seance.cinema;    
      }, () => console.error("Ошибка при получении данных с сервера"));
  }

  get purchaseId(): string{ 
    let id;
    this.route.params.subscribe(params => {
      id =  params['id'];  
    });
    return id;
  }

}
