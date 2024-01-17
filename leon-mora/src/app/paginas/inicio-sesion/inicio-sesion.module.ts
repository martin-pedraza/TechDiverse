import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InicioSesionRoutingModule } from './inicio-sesion-routing.module';
import { InicioSesionPage } from './inicio-sesion.component';
import { ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

@NgModule({
  declarations: [InicioSesionPage],
  imports: [CommonModule, InicioSesionRoutingModule, ReactiveFormsModule, IonicModule],
})
export class InicioSesionModule {}
