import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SplashRoutingModule } from './splash-routing.module';
import { IonicModule } from '@ionic/angular';
import { SplashComponent } from './splash.component';


@NgModule({
  declarations: [SplashComponent],
  imports: [
    CommonModule,
    SplashRoutingModule,
    IonicModule
  ]
})
export class SplashModule { }
