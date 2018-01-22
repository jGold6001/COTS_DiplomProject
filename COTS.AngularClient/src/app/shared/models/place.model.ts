export class Place{

    init(id: number, num: number, row: number, tariff: string, price: number){
        this.id = id;
        this.num = num;
        this.row = row;
        this.tariff = tariff;
        this.price = price;
    }

    constructor(){

    }

    id: number;
    num: number;
    row: number;
    tariff: string;
    price: number;
}