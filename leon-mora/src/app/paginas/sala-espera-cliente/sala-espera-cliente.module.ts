import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SalaEsperaClientePageRoutingModule } from './sala-espera-cliente-routing.module';

import { SalaEsperaClientePage } from './sala-espera-cliente.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SalaEsperaClientePageRoutingModule
  ],
  declarations: [SalaEsperaClientePage]
})
export class SalaEsperaClientePageModule {}
