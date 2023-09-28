import { ParticipantDto } from "./participant-dto"
import { TeamDto } from "./team-dto"

export class InfoDto {
    gameCreation: number = 0;
    gameDuration: number = 0;
    gameEndTimestamp: number = 0;
    gameId: number = 0;
    gameMode: string = "";
    gameName: string = "";
    gameStartTimestamp: number = 0;
    gameType: string = "";
    gameVersion: string = "";
    mapId: number = 0;
    participants: ParticipantDto[] = [];
    platformId: string = "";
    queueId: number = 0;
    teams: TeamDto[] = [];
    tournamentCode: string = "";

    public constructor(data : Partial<InfoDto>){
      Object.assign(this,data);
    }
}
