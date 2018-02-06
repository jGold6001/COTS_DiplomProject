
import { FlorenceHallLittleComponent } from "../../../../components/hall-dialog.components/halls-components/kiev/florence/florence-hall-little/florence-hall-little.component";
import { FlorenceHallRedComponent } from "../../../../components/hall-dialog.components/halls-components/kiev/florence/florence-hall-red/florence-hall-red.component";
import { FlorenceHallBlueComponent } from "../../../../components/hall-dialog.components/halls-components/kiev/florence/florence-hall-blue/florence-hall-blue.component";



export class FlorenceMappings{
    public static hall = {
        "Малый": FlorenceHallLittleComponent,
        "Крастный": FlorenceHallRedComponent,
        "Синий": FlorenceHallBlueComponent,
    }
}