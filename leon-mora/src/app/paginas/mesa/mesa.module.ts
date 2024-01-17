import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MesaPageRoutingModule } from './mesa-routing.module';

import { MesaPage } from './mesa.page';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { NgxScannerQrcodeModule } from 'ngx-scanner-qrcode';

@NgModule({
  imports: [
    MesaPageRoutingModule,
    CommonModule,
    FormsModule,
    IonicModule,
    ZXingScannerModule,
    NgxScannerQrcodeModule
  ],
  declarations: [MesaPage]
})
export class MesaPageModule {}
