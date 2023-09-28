import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { SearchService } from 'src/app/services/search.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  

  constructor(private searchService : SearchService, private router : Router) {
    
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
