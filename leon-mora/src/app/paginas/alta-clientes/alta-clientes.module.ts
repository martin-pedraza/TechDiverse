import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AltaClientesPageRoutingModule } from './alta-clientes-routing.module';

import { AltaClientesPage } from './alta-clientes.page';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { LOAD_WASM, NgxScannerQrcodeModule } from 'ngx-scanner-qrcode';

LOAD_WASM().subscribe((res: any) => console.log('LOAD_WASM', res));


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AltaClientesPageRoutingModule,
    ReactiveFormsModule,
    ZXingScannerModule,
    NgxScannerQrcodeModule
  ],
  declarations: [AltaClientesPage]
})
export class AltaClientesPageModule {}
