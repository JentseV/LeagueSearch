import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Summoner } from '../models/summoner';
import { Mastery } from '../models/mastery';
import { Match } from '../models/match';

@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  constructor(private httpClient : HttpClient) { }

  getSummonerFromApi(username : string) : Observable<Summoner>{
    return this.httpClient.get<Summoner>(`https://localhost:7080/api/Summoners/${username}`);
  }

  getMasteriesForSummoner(username : string , count : number) : Observable<Mastery[]>{
    return this.httpClient.get<Mastery[]>(`https://localhost:7080/api/Summoners/masteries/${count}?name=${username}`)
  }

  getMatchesForSummoner(username : string, count : number){
    return this.httpClient.get<Match[]>(`https://localhost:7080/api/Summoners/matches?name=${username}&count=${count}`);
  }
}
