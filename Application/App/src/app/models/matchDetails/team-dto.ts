import { BanDto } from "./ban-dto";
import { ObjectivesDto } from "./objectives-dto";

export class TeamDto {
    bans : BanDto[] = [];
    objectives : ObjectivesDto = new ObjectivesDto({});
    teamid : number = 0;
    win : boolean = true;

    public constructor(data : Partial<TeamDto>){
        Object.assign(this,data);
    }
}
