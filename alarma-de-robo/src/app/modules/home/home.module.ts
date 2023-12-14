import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePage } from './home.page';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HomeRoutingModule } from './home-routing.module';
import { Flashlight } from '@ionic-native/flashlight/ngx';
import { Vibration } from '@awesome-cordova-plugins/vibration/ngx';


@NgModule({
  declarations: [HomePage],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    IonicModule,
  ],
  providers: [Flashlight, Vibration],
})
export class HomeModule { }
