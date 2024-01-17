import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AltaProductoRoutingModule } from './alta-producto-routing.module';
import { AltaProductoPage } from './alta-producto.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AltaProductoPage],
  imports: [
    CommonModule,
    AltaProductoRoutingModule,
    IonicModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AltaProductoModule { }
