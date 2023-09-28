import { InfoDto } from "./matchDetails/info-dto";
import { MetadataDto } from "./matchDetails/metadata-dto";

export class Match {
    metaData : MetadataDto;
    info : InfoDto;

    public constructor( metaDataIn: MetadataDto, infoIn : InfoDto){
        this.metaData = metaDataIn;
        this.info = infoIn;
    }
}
