export class Sector{
    id: number;
    name: string;
    enterpriseId: string;

    init(id: number, name : string, enterpriseId: string){
        this.id = id;
        this.name = name;
        this.enterpriseId = enterpriseId;
    }
}