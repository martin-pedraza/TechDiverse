import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrincipalRoutingModule } from './principal-routing.module';
import { IonicModule } from '@ionic/angular';
import { PrincipalComponent } from './principal.component';


@NgModule({
  declarations: [PrincipalComponent],
  imports: [
    CommonModule,
    PrincipalRoutingModule,
    IonicModule
  ]
})
export class PrincipalModule { }
