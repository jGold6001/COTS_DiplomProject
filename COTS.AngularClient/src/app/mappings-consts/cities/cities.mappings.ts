import { KievMappings } from "./kiev/kiev.mappings";
import { HarkovMappings } from "./harkov/harkov.mappings";

export class CitiesMappings{
    
    public static city = {
        "kiev": KievMappings,
        "harkov": HarkovMappings
    }
}