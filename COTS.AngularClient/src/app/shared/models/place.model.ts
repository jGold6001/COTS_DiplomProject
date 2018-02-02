export class Place{

    init(id: number, num: number, row: number, isBusy: boolean, hallId: number, sectorId: number){
        this.id = id;
        this.num = num;
        this.row = row;
        this.isBusy = isBusy;
        this.hallId = hallId;
        this.sectorId = sectorId;
    }

    constructor(){

    }

    id: number;
    num: number;
    row: number;
    isBusy: boolean;
    hallId: number;
    sectorId: number;
}