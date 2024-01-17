import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioSesionPage } from './inicio-sesion.component';

const routes: Routes = [
  {
    path: '',
    component: InicioSesionPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InicioSesionRoutingModule {}
