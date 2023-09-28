export class MetadataDto {

    dataVersion : string;
    matchId : string;
    participants : string[];

    public constructor(data : Partial<MetadataDto>){
        this.dataVersion = data.dataVersion || "";
        this.matchId = data.matchId || "";
        this.participants = data.participants || [];
    }
}
