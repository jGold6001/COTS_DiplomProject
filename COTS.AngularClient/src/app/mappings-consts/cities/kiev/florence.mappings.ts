import { FlorenceHallBigComponent } from "../../../halls-components/kiev/florence/florence-hall-big/florence-hall-big.component";
import { FlorenceHallLittleComponent } from "../../../halls-components/kiev/florence/florence-hall-little/florence-hall-little.component";
import { FlorenceHallRedComponent } from "../../../halls-components/kiev/florence/florence-hall-red/florence-hall-red.component";
import { FlorenceHallBlueComponent } from "../../../halls-components/kiev/florence/florence-hall-blue/florence-hall-blue.component";



export class FlorenceMappings{
    public static hall = {
        "Большой": FlorenceHallBigComponent,
        "Малый": FlorenceHallLittleComponent,
        "Крастный": FlorenceHallRedComponent,
        "Синий": FlorenceHallBlueComponent,
    }
}