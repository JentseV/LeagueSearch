import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, forkJoin, of } from 'rxjs';
import { Summoner } from '../models/summoner';
import { Mastery } from '../models/mastery';
import { Match } from '../models/match';


@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  constructor( private httpClient: HttpClient) { }

  getSummonerFromApi(username: string, access_token : any): Observable<Summoner> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${access_token} `
    });

    return this.httpClient.get<Summoner>(`http://localhost:8081/api/Summoners/${username}`, { headers });
  }

  getMasteriesForSummoner(count: number, username: string, access_token : any): Observable<Mastery[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${access_token} `
    });

    return this.httpClient.get<Mastery[]>(`http://localhost:8081/api/Summoners/masteries/${count}?name=${username}`, { headers })
  }

  getMatchesForSummoner(username: string, count: number, access_token : any): Observable<Match[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${access_token} `
    });
    
    return this.httpClient.get<Match[]>(`http://localhost:8081/matches?name=${username}&count=${count}`, { headers });
  }

  getAccessToken(authorizationCode: string): Observable<any> {
    const body = new URLSearchParams();
    body.set('grant_type', 'authorization_code');
    body.set('client_id', 'Xc769hFQpJshcDvxv7Iw3X5Y6O3YUWwy');
    body.set('client_secret', 'cSeyq0I4QBbz4EY44VCoBwXZ0gFXLZtc_aSmd5WsAMl3ivVt2gSUJXQznPinYsS5');
    body.set('code', authorizationCode);
    body.set('redirect_uri', "http://localhost:4200/callbackauth");
    body.set('state','mystate123');
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/x-www-form-urlencoded');

    return this.httpClient.post("https://dev-qoa8c8pxfm0stq6b.us.auth0.com/oauth/token/", body.toString(), { headers: headers });
  }

  login(): Observable<any> {
    const params = new URLSearchParams();
    params.set('response_type', 'code');
    params.set('client_id', 'Xc769hFQpJshcDvxv7Iw3X5Y6O3YUWwy');
    params.set('redirect_uri', 'http://localhost:4200/callbackauth');
    params.set('scope', 'openid profile email');
    params.set('audience', 'https://leaguesearch/myapi');
    params.set('state', 'mystate123');
  
    const authorizationUrl = `https://dev-qoa8c8pxfm0stq6b.us.auth0.com/authorize?${params.toString()}`;
    
    window.location.href = authorizationUrl;
    return of(null); 
  }
  
}

  //https://dev-qoa8c8pxfm0stq6b.us.auth0.com/authorize?response_type=code&client_id=zuckaPkAlzCtl27o2kySB5TFKqpAS5V9&redirect_uri=http://localhost:4200/callbackauth&audience=https://leaguesearch/myapi&scope=openid%20profile%20email&state=mystateABC123



