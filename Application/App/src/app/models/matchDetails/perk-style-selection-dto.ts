export class PerkStyleSelectionDto {
    perk : number = 0;
    var1 : number = 0;
    var2 : number = 0;
    var3 : number = 0;

    public constructor(data : Partial<PerkStyleSelectionDto>){
        Object.assign(this,data);
    }
}
