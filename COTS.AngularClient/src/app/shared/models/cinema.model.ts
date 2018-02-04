export class Cinema{
    init(id: string, name: string, address: string, imagePath: string, cityId: string, enterpriseId: string){
        this.id = id;
        this.name = name;
        this.address = address;
        this.imagePath = imagePath;
        this.cityId = cityId;
        this.enterpriseId = enterpriseId;
    }

    constructor(){
        
    }

    id: string;
    name: string;
    address: string;
    imagePath: string;
    cityId: string;
    enterpriseId: string;
}