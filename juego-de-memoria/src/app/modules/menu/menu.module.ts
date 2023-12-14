import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuRoutingModule } from './menu-routing.module';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { MenuComponent } from 'src/app/components/menu/menu.component';
import { EasyComponent } from 'src/app/components/options/easy/easy.component';
import { MediumComponent } from 'src/app/components/options/medium/medium.component';
import { HardComponent } from 'src/app/components/options/hard/hard.component';
import { ReportsComponent } from 'src/app/components/options/reports/reports.component';

@NgModule({
  declarations: [
    MenuComponent,
    EasyComponent,
    MediumComponent,
    HardComponent,
    ReportsComponent,
  ],
  imports: [CommonModule, MenuRoutingModule, FormsModule, IonicModule],
})
export class MenuModule {}
