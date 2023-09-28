import { PerkStatsDto } from "./perk-stats-dto";
import { PerkStyleDto } from "./perk-style-dto";

export class PerksDto {
    statPerks : PerkStatsDto = new PerkStatsDto({});
    styles : PerkStyleDto[] = [];

    public constructor(data: Partial<PerksDto>){
        Object.assign(this,data);
    }
}
