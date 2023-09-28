import { PerkStyleSelectionDto } from "./perk-style-selection-dto";

export class PerkStyleDto {
    description : string = "";
    selections : PerkStyleSelectionDto[] = [];
    style : number = 0;


    public constructor(data : Partial<PerkStyleDto>){
        Object.assign(this,data);
    }
}
