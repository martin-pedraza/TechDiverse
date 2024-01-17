import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AccesosRapidosPageRoutingModule } from './accesos-rapidos-routing.module';

import { AccesosRapidosPage } from './accesos-rapidos.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AccesosRapidosPageRoutingModule
  ],
  declarations: [AccesosRapidosPage]
})
export class AccesosRapidosPageModule {}
