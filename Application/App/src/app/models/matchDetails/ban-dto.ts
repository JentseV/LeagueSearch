export class BanDto {
    championId : number = 0;
    pickTurn : number= 0;

    public constructor(data : Partial<BanDto>){
        Object.assign(this,data);
    }
}
