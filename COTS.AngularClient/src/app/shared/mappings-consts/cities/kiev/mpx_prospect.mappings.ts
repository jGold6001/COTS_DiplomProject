import { MpxProspectHall1Component } from "../../../../components/hall-dialog.components/halls-components/kiev/mpx_prospect/mpx-prospect-hall-1/mpx-prospect-hall-1.component";
import { MpxProspectHall2Component } from "../../../../components/hall-dialog.components/halls-components/kiev/mpx_prospect/mpx-prospect-hall-2/mpx-prospect-hall-2.component";
import { MpxProspectHall5Component } from "../../../../components/hall-dialog.components/halls-components/kiev/mpx_prospect/mpx-prospect-hall-5/mpx-prospect-hall-5.component";
import { MpxProspectHall4Component } from "../../../../components/hall-dialog.components/halls-components/kiev/mpx_prospect/mpx-prospect-hall-4/mpx-prospect-hall-4.component";



export class MpxProspectMappings{
    public static hall = {
        "1": MpxProspectHall1Component,
        "2": MpxProspectHall2Component,
        "4": MpxProspectHall4Component,
        "5": MpxProspectHall5Component,
    }
}