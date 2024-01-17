import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalaEsperaMetreRoutingModule } from './sala-espera-metre-routing.module';
import { IonicModule } from '@ionic/angular';
import { SalaEsperaMetreComponent } from './sala-espera-metre.component';

@NgModule({
  declarations: [SalaEsperaMetreComponent],
  imports: [CommonModule, SalaEsperaMetreRoutingModule, IonicModule],
})
export class SalaEsperaMetrePage {}
