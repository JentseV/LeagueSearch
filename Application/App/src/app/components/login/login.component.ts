import { Component } from '@angular/core';

import { HttpserviceService } from 'src/app/services/httpservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  constructor(private http : HttpserviceService) {}

  login() {
    this.http.login();
  }

}