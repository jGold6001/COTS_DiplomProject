export class Cinema{
    constructor(id: string, name: string, address: string, imagePath: string, cityId: string){
        this.id = id;
        this.name = name;
        this.address = address;
        this.imagePath = imagePath;
        this.cityId = cityId;
    }

    id: string;
    name: string;
    address: string;
    imagePath: string;
    cityId: string;
}