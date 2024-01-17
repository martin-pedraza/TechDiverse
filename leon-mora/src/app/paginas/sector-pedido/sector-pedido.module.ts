import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SectorPedidoRoutingModule } from './sector-pedido-routing.module';
import { SectorPedidoComponent } from './sector-pedido.component';
import { IonicModule } from '@ionic/angular';

@NgModule({
  declarations: [SectorPedidoComponent],
  imports: [CommonModule, SectorPedidoRoutingModule, IonicModule],
})
export class SectorPedidoModule {}
