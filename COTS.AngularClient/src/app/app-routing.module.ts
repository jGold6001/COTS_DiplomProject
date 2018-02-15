import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MainPageComponent } from "./components/main-page.components/main-page/main-page.component";
import { CinemaPageComponent } from "./components/cinema-page.components/cinema-page/cinema-page.component";
import { MoviePageComponent } from "./components/movie-page.components/movie-page/movie-page.component";
import { PurchasePageComponent } from "./components/purchase-page.components/purchase-page/purchase-page.component";
import { HallDialogComponent } from "./components/hall-dialog.components/hall-dialog/hall-dialog.component";
import { HallFourthComponent } from "./components/hall-dialog.components/halls-components/hall-fourth/hall-fourth.component";
import { HallThirdComponent } from "./components/hall-dialog.components/halls-components/hall-third/hall-third.component";
import { HallSecondComponent } from "./components/hall-dialog.components/halls-components/hall-second/hall-second.component";
import { HallFirstComponent } from "./components/hall-dialog.components/halls-components/hall-first/hall-first.component";



const routes: Routes = [
  { path: "", component: MainPageComponent }, 
  { path: "hall_4", component: HallFourthComponent },
  { path: "hall_3", component: HallThirdComponent },
  { path: "hall_2", component: HallSecondComponent },
  { path: "hall_1", component: HallFirstComponent },
  { path: "purchase/:id", component: PurchasePageComponent},
  { path: ":cityId", component: MainPageComponent },
  { path: ":cityId/movie/:id", component: MoviePageComponent},
  { path: ":cityId/cinema/:id", component: CinemaPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
