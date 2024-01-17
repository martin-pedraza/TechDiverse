import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { AltaUsuariosPageRoutingModule } from './alta-usuarios-routing.module';
import { AltaUsuariosPage } from './alta-usuarios.page';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { NgxScannerQrcodeModule, LOAD_WASM } from 'ngx-scanner-qrcode';

LOAD_WASM().subscribe((res: any) => console.log('LOAD_WASM', res));

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AltaUsuariosPageRoutingModule,
    ReactiveFormsModule,
    ZXingScannerModule,
    NgxScannerQrcodeModule
  ],
  declarations: [AltaUsuariosPage]
})
export class AltaUsuariosPageModule {}
