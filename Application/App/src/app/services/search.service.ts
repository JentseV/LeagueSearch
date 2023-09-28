import { Injectable } from '@angular/core';
import { Observable,Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {


  private userNameSubject : Subject<string> = new Subject<string>();
  userNameSubject$ = this.userNameSubject.asObservable();

  constructor() { }

  setUserName( name : string) : void{
    this.userNameSubject.next(name);
  }

}
