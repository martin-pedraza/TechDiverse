import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MozoPanelPageRoutingModule } from './mozo-panel-routing.module';

import { MozoPanelPage } from './mozo-panel.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MozoPanelPageRoutingModule
  ],
  declarations: [MozoPanelPage]
})
export class MozoPanelPageModule {}
