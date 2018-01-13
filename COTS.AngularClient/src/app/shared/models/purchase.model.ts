import { Ticket } from "./ticket.model";

export class Purchase{
    id: string;
    tickets: Ticket[];
    clientName: string;
    clientEmail: string;
}