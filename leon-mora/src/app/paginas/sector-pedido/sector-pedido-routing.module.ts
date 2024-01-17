import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SectorPedidoComponent } from './sector-pedido.component';

const routes: Routes = [
  {
    path: '',
    component: SectorPedidoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SectorPedidoRoutingModule {}
