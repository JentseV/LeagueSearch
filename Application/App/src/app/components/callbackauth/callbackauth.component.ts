import { Injectable } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { HttpserviceService } from 'src/app/services/httpservice.service';

@Component({
  selector: 'app-callbackauth',
  templateUrl: './callbackauth.component.html',
  styleUrls: ['./callbackauth.component.css']
})
export class CallbackauthComponent implements OnInit{

  code = "";
  constructor(private http : HttpserviceService,private route: ActivatedRoute,private router: Router, private HttpService : HttpserviceService, private auth : AuthService) { }

  async ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const code = params['code'];
      if (code) {
        this.HttpService.getAccessToken(code).subscribe(result => {
          this.auth.setAccessToken(result.access_token);
          this.auth.setIdToken(result.id_token);
          this.router.navigate(['/search']);
        });
      } else {
        console.error('No authorization code found in the URL');
      }
    }); 
    //this.router.navigate(['/search']);
  }
}