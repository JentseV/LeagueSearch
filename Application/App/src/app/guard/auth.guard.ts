import { CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import {  Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor( private router: Router) {}

  async canActivate(): Promise<any> {
    
  }
}