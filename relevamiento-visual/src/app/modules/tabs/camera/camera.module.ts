import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CameraRoutingModule } from './camera-routing.module';
import { CameraComponent } from './camera.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [CameraComponent],
  imports: [
    CommonModule,
    CameraRoutingModule,
    IonicModule,
    FormsModule,
  ]
})
export class CameraModule { }
