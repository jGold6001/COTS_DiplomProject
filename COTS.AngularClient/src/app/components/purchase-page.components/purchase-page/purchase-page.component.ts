import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../../../shared/models/ticket.model';
import { Purchase } from '../../../shared/models/purchase.model';
import { Observable, Subscription } from 'rxjs';
import { Movie } from '../../../shared/models/movie.model';
import { Cinema } from '../../../shared/models/cinema.model';
import { Seance } from '../../../shared/models/seance.model';
import { ErrorStateMatcher, MatDialog } from '@angular/material';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { TicketsDialogComponent } from '../tickets-dialog/tickets-dialog.component';
import { PurchaseService } from '../../../shared/services/purchase.service';


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

  email: string;

  constructor(
   private route: ActivatedRoute,
   private purchaseService: PurchaseService,
   public dialog: MatDialog
  ) 
  {}

  ngOnInit() {
    
    this.purchaseService.getPurchase("test231243")
      .subscribe(data => {
        this.purchase = data;
        console.log(data);
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

  paymentOrder(){
    //save order in db
    this.savePurchase();

    //display tickets in dialog
    // let dialogRef = this.dialog.open(TicketsDialogComponent, {
    //   width: '1000px',
    //   data: { purchase: this.purchase }
    // });

  }

  cancelOrder(){
    //delete order in db
    //go to Main-page

  }

  savePurchase(){
    //console.log(this.email);
  }


}
