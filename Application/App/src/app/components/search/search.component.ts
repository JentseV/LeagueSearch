import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { InitialNavigation, NavigationExtras, Router } from '@angular/router';
import { User } from 'oidc-client-ts';
import { AuthService } from 'src/app/services/auth.service';
import { SearchService } from 'src/app/services/search.service';
import {jwtDecode} from 'jwt-decode';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  

  constructor(private authService: AuthService, private searchService : SearchService, private router : Router) {
  }

  currentUser : any;
  decodedToken = jwtDecode<any>(this.authService.id_token);
  ngOnInit(): void {
  }

  searchForm =  new FormGroup({
    userName : new FormControl('')
  });


  searchSummoner() : void {
    if(this.searchForm.value['userName']){
      this.searchService.setUserName(this.searchForm.value['userName'].toString());

      const NavigationExtras : NavigationExtras = {
        queryParams : {
          profileName : JSON.stringify(this.searchForm.value['userName'])
        }
      }

      this.router.navigateByUrl('/profile', { state : { profileName: this.searchForm.value['userName']} } );
    } 
  }

}
