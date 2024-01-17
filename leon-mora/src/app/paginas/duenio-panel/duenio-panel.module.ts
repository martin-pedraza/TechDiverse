import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DuenioPanelPageRoutingModule } from './duenio-panel-routing.module';

import { DuenioPanelPage } from './duenio-panel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DuenioPanelPageRoutingModule
  ],
  declarations: [DuenioPanelPage]
})
export class DuenioPanelPageModule {}
