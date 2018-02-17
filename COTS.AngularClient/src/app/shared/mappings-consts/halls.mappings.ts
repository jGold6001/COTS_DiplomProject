import { HallFirstComponent } from "../../components/hall-dialog.components/halls-components/hall-first/hall-first.component";
import { HallFourthComponent } from "../../components/hall-dialog.components/halls-components/hall-fourth/hall-fourth.component";
import { HallThirdComponent } from "../../components/hall-dialog.components/halls-components/hall-third/hall-third.component";
import { HallSecondComponent } from "../../components/hall-dialog.components/halls-components/hall-second/hall-second.component";



export class HallMappings{
    public static hall = {
        "Зеленый": HallFirstComponent,
        "Малый": HallSecondComponent,
        "Синий": HallThirdComponent,
        "Красный": HallFourthComponent,
        "1": HallFirstComponent,
        "2": HallSecondComponent,
        "3": HallThirdComponent,
        "4": HallFourthComponent
    }
}