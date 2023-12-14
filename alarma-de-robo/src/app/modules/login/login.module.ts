import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { LoginComponent } from './login.component';
import { PasswordComponent } from 'src/app/components/password/password.component';

@NgModule({
  declarations: [LoginComponent, PasswordComponent],
  imports: [CommonModule, LoginRoutingModule, FormsModule, IonicModule],
})
export class LoginModule {}
