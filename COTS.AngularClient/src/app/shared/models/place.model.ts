export class Place{

    init(id: number, num: number, row: number, isBusy: boolean, hallId: number){
        this.id = id;
        this.num = num;
        this.row = row;
        this.isBusy = isBusy;
        this.hallId = hallId;
    }

    constructor(){

    }

    id: number;
    num: number;
    row: number;
    isBusy: boolean;
    hallId: number;
}