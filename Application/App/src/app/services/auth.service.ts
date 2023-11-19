import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  access_token : any = "";
  id_token : any = "";
  constructor() { }


  setAccessToken(token : any) : void {
    this.access_token = token;
  }

  setIdToken(token : any) : void {
    this.id_token = token;
  }
}
