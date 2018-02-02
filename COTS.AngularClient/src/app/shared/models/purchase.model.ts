import { Ticket } from "./ticket.model";
import { Customer } from "./customer.model";

export class Purchase{
    id: string;
    tickets: Ticket[];
    customer: Customer;
    sum: number;   
}