import { trigger } from '@angular/animations';
import { Component, Host } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Mastery } from 'src/app/models/mastery';
import { Match } from 'src/app/models/match';
import { InfoDto } from 'src/app/models/matchDetails/info-dto';
import { MetadataDto } from 'src/app/models/matchDetails/metadata-dto';
import { Summoner } from 'src/app/models/summoner';
import { HttpserviceService } from 'src/app/services/httpservice.service';
import { SearchService } from 'src/app/services/search.service';

enum GameOutcome{
  Victory = 0,
  Defeat = 1 ,
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
  matches: Match[];
  


  constructor(private searchService: SearchService, private router: ActivatedRoute, private httpService: HttpserviceService) {

  }

  ngOnInit() {
    this.userName = history.state['profileName'];
    this.getSummonerDataFromApi(this.userName);
    this.getMatches(this.userName,2);
    console.log(this.matches);
  }

  getSummonerDataFromApi(username: string) {
    this.httpService.getSummonerFromApi(username).subscribe(result => {
      this.summoner = new Summoner(result.id, result.accountId, result.puuid, result.name, result.profileIconId, result.revisionDate, result.summonerLevel);
    });
  }

  getMasteriesForSummoner(username: string, count: number) {
    this.showMasteries = !this.showMasteries;
    this.httpService.getMasteriesForSummoner(username, count).subscribe(result => {
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

  justSomeTesting() {
    const testMetaData: MetadataDto = {
      dataVersion: "2",
      matchId: '1',
      participants: ["x", "y"]
    }

    alert(testMetaData.dataVersion + testMetaData.matchId);
    const testInfoDto: InfoDto = new InfoDto({});
  }

  getMatches(username: string, count: number) {

      this.httpService.getMatchesForSummoner(username, count).subscribe(result => {
        this.matches = result;
        console.log(this.matches[0]);
      });
      console.log(this.matches[0]);
  }


  getPlayerDetailsForMatch(match: Match ) : any{
    const player =  match.info.participants.find(participant => participant.summonerName === this.userName);
    return player;
   
  }

  checkOutcome(match: Match): String {
    const participant = match.info.participants.find(participant => participant.summonerName === this.userName);
    
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
}


