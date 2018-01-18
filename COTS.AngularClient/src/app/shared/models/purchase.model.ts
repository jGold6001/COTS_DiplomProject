import { Ticket } from "./ticket.model";
import { Client } from "./client.model";

export class Purchase{
    id: string;
    tickets: Ticket[];
    client: Client;   
}