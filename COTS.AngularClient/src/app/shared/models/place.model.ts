export class Place{

    init(num: number, row: number, tariff: string, price: number){
        this.num = num;
        this.row = row;
        this.tariff = tariff;
        this.price = price;
    }

    constructor(){

    }

    num: number;
    row: number;
    tariff: string;
    price: number;
}