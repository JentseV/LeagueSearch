import { trigger } from '@angular/animations';
import { Component, Host } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Mastery } from 'src/app/models/mastery';
import { Match } from 'src/app/models/match';
import { Summoner } from 'src/app/models/summoner';
import { AuthService } from 'src/app/services/auth.service';
import { HttpserviceService } from 'src/app/services/httpservice.service';
import { SearchService } from 'src/app/services/search.service';
import {jwtDecode } from 'jwt-decode';

enum GameOutcome {
  Victory = 0,
  Defeat = 1,
  Undefined = 2
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  userName: string = "";
  summoner: Summoner;
  showMasteries: boolean = false;
  masteries: Mastery[];
  matches: Match[] = [];
  access_token = (this.auth.access_token);
  constructor(private auth:  AuthService , private searchService: SearchService, private router: ActivatedRoute, private httpService: HttpserviceService) {

  }

  ngOnInit() {
  
    this.userName = history.state['profileName'];
    this.getSummonerDataFromApi(this.userName, this.access_token);
    this.getMatches(this.userName, 10);
  }

  getSummonerDataFromApi(username: string, access_token : any) {
    this.httpService.getSummonerFromApi(username,this.access_token).subscribe(result => {
      this.summoner = new Summoner(result.id, result.accountId, result.puuid, result.name, result.profileIconId, result.revisionDate, result.summonerLevel);
    });
  }

  getMasteriesForSummoner(count: number) {
    this.showMasteries = !this.showMasteries;
    console.log(this.userName)
    this.httpService.getMasteriesForSummoner(count, this.userName,this.access_token).subscribe(result => {
      this.masteries = result.map(masteryData => new Mastery(
        masteryData.puuid,
        masteryData.championId,
        masteryData.championLevel,
        masteryData.championPoints,
        masteryData.lastPlayTime,
        masteryData.championPointsSinceLastLevel,
        masteryData.championPointsUntilNextLevel,
        masteryData.chestGranted,
        masteryData.tokensEarned,
        masteryData.summonerId,
      ))
    })
  }

  getMatches(username: string, count: number) {
      this.httpService.getMatchesForSummoner(username, count,this.access_token).subscribe(result => {
      this.matches = result;
    });
  }


  getPlayerDetailsForMatch(match: Match): any {
    const player = match.info.participants.find(participant => participant.summonerName.toLowerCase() == this.userName.toLocaleLowerCase());
    return player;
  }

  checkOutcome(match: Match): String {
    const participant = this.getPlayerDetailsForMatch(match);
    if (participant) {
      if (participant.win) {
        return GameOutcome[GameOutcome.Victory];
      } else {
        return GameOutcome[GameOutcome.Defeat];
      }
    } else {
      return GameOutcome[GameOutcome.Undefined];
    }
  }


  matchDetails : { player: any} = { player: null };

  showMatchDetails(match : Match) : void{
    let popup = document.getElementById("popup");
    if(popup != null || popup != undefined){
      popup.style.display = "block";
    }

    if (this.matchDetails) {
      this.matchDetails.player = match.info.participants.find(participant => participant.summonerName.toLowerCase() == this.userName.toLowerCase())?.summonerName;
      console.log(this.matchDetails.player)
    }
  }

  closeMatchDetails() : void{
    let popup = document.getElementById("popup");
    if(popup != null || popup != undefined){
      popup.style.display = "none";
    }
  }
}


