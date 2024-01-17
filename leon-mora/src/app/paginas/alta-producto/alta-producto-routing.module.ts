import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AltaProductoPage } from './alta-producto.component';

const routes: Routes = [
  {
    path: '',
    component: AltaProductoPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AltaProductoRoutingModule { }
