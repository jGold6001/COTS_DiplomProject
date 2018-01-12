import { MpxSkymallMappings } from "./mpx_skymall.mappings";
import { MpxProspectMappings } from "./mpx_prospect.mappings";
import { FlorenceMappings } from "./florence.mappings";


export class KievMappings{

    public static cinema = {
        "mpx_skymall" : MpxSkymallMappings,
        "mpx_prospect": MpxProspectMappings,
        "florence":     FlorenceMappings
    }
}