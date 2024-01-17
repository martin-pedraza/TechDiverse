import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AltaEmpleadosRoutingModule } from './alta-empleados-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { LOAD_WASM, NgxScannerQrcodeModule } from 'ngx-scanner-qrcode';
import { AltaEmpleadosPage } from './alta-empleados.component';

LOAD_WASM().subscribe((res: any) => console.log('LOAD_WASM', res));


@NgModule({
  declarations: [AltaEmpleadosPage],
  imports: [
    CommonModule,
    AltaEmpleadosRoutingModule,
    FormsModule,
    IonicModule,
    ReactiveFormsModule,
    ZXingScannerModule,
    NgxScannerQrcodeModule,
  ],
})
export class AltaEmpleadosModule {}
