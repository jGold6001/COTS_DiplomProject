import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MainPageComponent } from "./components/main-page.components/main-page/main-page.component";
import { CinemaPageComponent } from "./components/cinema-page.components/cinema-page/cinema-page.component";
import { MoviePageComponent } from "./components/movie-page.components/movie-page/movie-page.component";
import { PurchasePageComponent } from "./components/purchase-page.components/purchase-page/purchase-page.component";
import { HallDialogComponent } from "./components/hall-dialog.components/hall-dialog/hall-dialog.component";
import { HallFourthComponent } from "./components/hall-dialog.components/halls-components/hall-fourth/hall-fourth.component";



const routes: Routes = [
  { path: "", component: MainPageComponent }, 
  { path: "hall", component: HallFourthComponent },
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
