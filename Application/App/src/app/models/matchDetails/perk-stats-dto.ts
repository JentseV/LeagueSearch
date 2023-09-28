export class PerkStatsDto {
    defense : number = 0;
    flex :  number = 0;
    offense : number = 0;

    public constructor(data : Partial<PerkStatsDto>){
        Object.assign(this,data);
    }
}
