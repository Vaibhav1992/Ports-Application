import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPortComponent } from './add-port/add-port.component';
import { MapComponent } from './map/map.component';
import { PortComponent } from './port/port.component';

const routes: Routes = [
  { path: '', component: PortComponent },
  { path: 'dashboard', component: PortComponent },
  { path: 'map', component: MapComponent },
  { path: 'add', component: AddPortComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
