import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HacerEncuestaPageRoutingModule } from './hacer-encuesta-routing.module';

import { HacerEncuestaPage } from './hacer-encuesta.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HacerEncuestaPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [HacerEncuestaPage]
})
export class HacerEncuestaPageModule {}
