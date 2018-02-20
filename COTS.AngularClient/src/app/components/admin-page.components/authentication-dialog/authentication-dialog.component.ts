import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authentication-dialog',
  templateUrl: './authentication-dialog.component.html',
  styleUrls: ['./authentication-dialog.component.css']
})
export class AuthenticationDialogComponent implements OnInit {

  hide: boolean = true;
  model: any={};
  user: User;

  constructor() { }

  ngOnInit() {
  }

  onTestDialog(){
    console.log(this.model);
  }

}

export class User{
    login: string;
    password: string;
}
