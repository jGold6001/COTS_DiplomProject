import { MpxProspectHall1Component } from "../../../halls-components/kiev/mpx_prospect/mpx-prospect-hall-1/mpx-prospect-hall-1.component";
import { MpxProspectHall2Component } from "../../../halls-components/kiev/mpx_prospect/mpx-prospect-hall-2/mpx-prospect-hall-2.component";
import { MpxProspectHall4Component } from "../../../halls-components/kiev/mpx_prospect/mpx-prospect-hall-4/mpx-prospect-hall-4.component";
import { MpxProspectHall5Component } from "../../../halls-components/kiev/mpx_prospect/mpx-prospect-hall-5/mpx-prospect-hall-5.component";


export class MpxProspectMappings{
    public static hall = {
        "1": MpxProspectHall1Component,
        "2": MpxProspectHall2Component,
        "4": MpxProspectHall4Component,
        "5": MpxProspectHall5Component,
    }
}