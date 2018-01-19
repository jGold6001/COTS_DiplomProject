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
import { Client } from '../../../shared/models/client.model';


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
  client: Client = new Client();

  email: string;
  name: string;
  phone: string;


  emailFormControl = new FormControl('', [
    Validators.email,
  ]);

  nameFormControl = new FormControl('', [
    Validators.required,
    Validators.maxLength(40)
  ]);

  matcher = new MyErrorStateMatcher();

  constructor(
   private route: ActivatedRoute,
   private purchaseService: PurchaseService,
   public dialog: MatDialog
  ) 
  {}

  ngOnInit() {
    this.purchaseService.getPurchase(this.purchaseId)
      .subscribe(data => {
        this.purchase = data;
        this.tickets = this.purchase.tickets;    
        this.seance = this.tickets[0].seance;
        this.movie = this.seance.movie;
        this.cinema = this.seance.cinema;    
      }, () => console.error("Ошибка при получении данных с сервера"));

  }

  private get purchaseId(): string{ 
    let id;
    this.route.params.subscribe(params => {
      id =  params['id'];  
    });
    return id;
  }

  paymentOrder(){
    this.updatePurchase();
    this.purchase.client = this.client;
    
    console.log(this.purchase);

    // let dialogRef = this.dialog.open(TicketsDialogComponent, {
    //   width: '1000px',
    //   data: { purchase: this.purchase }
    // });

  }

  cancelOrder(){
    console.log(this.phone);
  }

  private updatePurchase(){
    if(this.client.fullName != null)
      this.purchaseService.updateInDb(this.createClientViewModel); 
  }

  private get createClientViewModel(): any{
    let _client ={
      Id: this.purchaseId,
      Email: this.client.email,
      FullName: this.client.fullName,
      Phone:  this.client.phone
    }
    return _client;
}

  private removePurchase(){
    this.purchaseService.removePurchase(this.purchaseId);
  } 
}
