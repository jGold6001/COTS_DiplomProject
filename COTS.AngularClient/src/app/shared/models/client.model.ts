
export class Client{
    init( email: string, fullName: string, phone: number){
        this.email = email;
        this.fullName = fullName;
        this.phone = phone;
    };

    constructor(){

    }
    
    email: string;
    fullName: string;
    phone: number;
}
