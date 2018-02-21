
export class User{
    
    init(login: string, password: string, cinemaId: string){
        this.login = login;
        this.password = password;
        this.cinemaId = cinemaId;
    }

    initFullModel(  id: number,login: string, password: string, cinemaId: string, userRole: number, firstName: string, lastName: string, position: string){
        this.id = id;
        this.login = login;
        this.password = password;
        this.cinemaId = cinemaId;
        this.userRole = userRole;
        this.firstName = firstName;
        this.lastName = lastName;
        this.position = position;
    }

    initShortModel( id: number,login: string, password: string, cinemaId: string, userRole: number){
        this.id = id;
        this.login = login;
        this.password = password;
        this.cinemaId = cinemaId;
        this.userRole = userRole;
    }

    id: number;
    login: string;
    password: string;
    cinemaId: string;
    userRole: number;
    firstName: string;
    lastName: string;
    position: string;

}