import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HacerEncuestaPage } from './hacer-encuesta.page';

const routes: Routes = [
  {
    path: '',
    component: HacerEncuestaPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HacerEncuestaPageRoutingModule {}
