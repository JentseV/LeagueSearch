import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,forkJoin } from 'rxjs';
import { Summoner } from '../models/summoner';
import { Mastery } from '../models/mastery';
import { Match } from '../models/match';

// Access the API key
const API_KEY_RG = process.env["RIOT_API_KEY"];


@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  constructor(private httpClient : HttpClient) { }

  getSummonerFromApi(username : string) : Observable<Summoner>{
    return this.httpClient.get<Summoner>(`https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/${username}?api_key=${API_KEY_RG}`);
  }

  getMasteriesForSummoner(count : number, puuid : string) : Observable<Mastery[]>{
    return this.httpClient.get<Mastery[]>(`https://euw1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/${puuid}/top?count=${count}&api_key=${API_KEY_RG}`)
  }

  getMatchIdsForSummoner(puuid : string , count : number) : Observable<string[]>{
    return this.httpClient.get<string[]>(`https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?start=0&count=${count}&api_key=${API_KEY_RG}`);
  }

  getMatchesForSummoner(matchIds: string[]): Observable<Match[]> {
    const observables = matchIds.map(matchID =>
      this.httpClient.get<Match>(`https://europe.api.riotgames.com/lol/match/v5/matches/${matchID}?api_key=${API_KEY_RG}`)
    );
      return forkJoin(observables);
  }
  
}
