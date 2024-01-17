import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SalaEsperaClientePage } from './sala-espera-cliente.page';

const routes: Routes = [
  {
    path: '',
    component: SalaEsperaClientePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SalaEsperaClientePageRoutingModule {}
