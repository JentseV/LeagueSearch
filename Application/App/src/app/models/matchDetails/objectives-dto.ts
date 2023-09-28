import { ObjectiveDto } from "./objective-dto"

export class ObjectivesDto {
    baron: ObjectiveDto = new ObjectiveDto({});
    champion: ObjectiveDto = new ObjectiveDto({});
    dragon: ObjectiveDto = new ObjectiveDto({});
    inhibitor: ObjectiveDto = new ObjectiveDto({});
    riftHerald: ObjectiveDto = new ObjectiveDto({});
    tower: ObjectiveDto = new ObjectiveDto({});

    public constructor(data : Partial<ObjectivesDto>){
        Object.assign(this,data);
    }
}
