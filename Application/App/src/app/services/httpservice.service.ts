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
    return this.httpClient.get<Summoner>(`https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/${username}?api_key=${API_KEY_RG}`);
  }

  getMasteriesForSummoner(username : string , count : number, summonerId : string) : Observable<Mastery[]>{
    return this.httpClient.get<Mastery[]>(`https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/${summonerId}/top?count=${count}&api_key=${API_KEY_RG}"`)
  }

  getMatchIdsForSummoner(puuid : string , count : number) : Observable<string[]>{
    return this.httpClient.get<string[]>(`https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?start=0&count=${count}&api_key=${API_KEY}`);
  }

  getMatchesForSummoner(matchIds: string[]): Observable<Match[]> {
    const observables = matchIds.map(matchID =>
      this.httpClient.get<Match>(`https://europe.api.riotgames.com/lol/match/v5/matches/${matchID}?api_key=${API_KEY}`)
    );
      return forkJoin(observables);
  }
  
}
