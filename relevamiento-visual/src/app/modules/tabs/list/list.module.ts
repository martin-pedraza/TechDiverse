import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { ListComponent } from './list.component'

import { ListRoutingModule } from './list-routing.module';


@NgModule({
  declarations: [ListComponent],
  imports: [
    CommonModule,
    ListRoutingModule,
    IonicModule,
    FormsModule
  ]
})
export class ListModule { }
