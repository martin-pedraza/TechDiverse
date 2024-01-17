import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AltaEmpleadosPage } from './alta-empleados.component';

const routes: Routes = [
  {
    path: '',
    component: AltaEmpleadosPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AltaEmpleadosRoutingModule {}
