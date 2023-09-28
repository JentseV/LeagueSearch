export class ObjectiveDto {
    first : boolean = true;
    kills : number = 0;

    public constructor(data : Partial<ObjectiveDto>){
        Object.assign(this,data);
    }
}
