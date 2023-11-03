import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,forkJoin } from 'rxjs';
import { Summoner } from '../models/summoner';
import { Mastery } from '../models/mastery';
import { Match } from '../models/match';


@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  constructor(private httpClient : HttpClient) { }

  getSummonerFromApi(username : string) : Observable<Summoner>{
    return this.httpClient.get<Summoner>(`http://localhost:8081/api/Summoners/${username}`);
  }

  getMasteriesForSummoner(count : number, username : string) : Observable<Mastery[]>{
    return this.httpClient.get<Mastery[]>(`http://localhost:8081/api/Summoners/masteries/${count}?name=${username}`)
  }

  getMatchesForSummoner(username : string , count : number) : Observable<Match[]>{
    return this.httpClient.get<Match[]>(`http://localhost:8081/api/Summoners/matches?name=${username}&count=${count}`);
  }

  
}


