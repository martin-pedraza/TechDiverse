import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AccesosRapidosPage } from './accesos-rapidos.page';

const routes: Routes = [
  {
    path: '',
    component: AccesosRapidosPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccesosRapidosPageRoutingModule {}
