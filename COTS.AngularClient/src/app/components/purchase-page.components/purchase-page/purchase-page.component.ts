import { Component, OnInit} from '@angular/core';
import { DataService } from '../../../shared/services/data.service';
import { ActivatedRoute, Router } from '@angular/router';
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
import { Customer } from '../../../shared/models/customer.model';
import { Hall } from '../../../shared/models/hall.model';



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
  hall: Hall = new Hall();
  customer: Customer = new Customer();
  technology: string;

  constructor(
   private route: ActivatedRoute,
   private purchaseService: PurchaseService,
   public dialog: MatDialog,
   private router: Router
  ) 
  {}

  ngOnInit() {
    this.purchaseService.getPurchase(this.purchaseId)
      .subscribe(data => {
        this.purchase = data;
        this.tickets = this.purchase.tickets;    
        this.seance = this.tickets[0].seance;
        this.movie = this.seance.movie;
        this.cinema = this.seance.hall.cinema;
        this.hall = this.seance.hall;  
        this.technology = this.seance.technologyId.toUpperCase();
      }, () => console.error("Ошибка при получении данных с сервера"));

      this.startTimer(420);
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
    this.purchase.customer = this.customer; 

    let dialogRef = this.dialog.open(TicketsDialogComponent, {
      width: '900px',
      height: '600px',
      data: { purchase: this.purchase }
    });

    dialogRef.afterClosed().subscribe(() => {
      this.goToMain();
    });

  }

  cancelOrder(){
    this.removePurchase();
    this.goToMain();
  }

  private updatePurchase(){
    if(this.customer.fullName != null){
      this.purchaseService.updateInDb(this.createCustomerViewModel); 
    }else{
      alert("Введите пожалуйста ваше имя");
    }
      
  }

  private get createCustomerViewModel(): any{
    let _customer ={
      Id: this.purchaseId,
      Email: this.customer.email,
      FullName: this.customer.fullName,
      Phone:  this.customer.phone
    }
    return _customer;
}

  private removePurchase(){
    this.purchaseService.removePurchase(this.purchaseId);
  } 

  private goToMain(){
    this.router.navigate([""]);
  }

  ticks = 0;
    
  minutesDisplay: number = 0;
  secondsDisplay: number = 0;
  sub: Subscription;

  private startTimer(counter) {

    let timer = Observable.timer(1, 1000)
      .take(counter)
      .map(() => --counter);
    this.sub = timer.subscribe(
        t => {
            this.ticks = t; 
            if(this.ticks == 0){
              this.removePurchase();
              this.goToMain();
            }    
            this.secondsDisplay = this.getSeconds(this.ticks);
            this.minutesDisplay = this.getMinutes(this.ticks);
        }
    );
  }

  private getSeconds(ticks: number) {
      return this.pad(ticks % 60);
  }

  private getMinutes(ticks: number) {
      return this.pad((Math.floor(ticks / 60)) % 60);
  }

  private pad(digit: any) { 
      return digit <= 9 ? '0' + digit : digit;
  }

}
