import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DuenioPanelPage } from './duenio-panel.page';

const routes: Routes = [
  {
    path: '',
    component: DuenioPanelPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DuenioPanelPageRoutingModule {}
