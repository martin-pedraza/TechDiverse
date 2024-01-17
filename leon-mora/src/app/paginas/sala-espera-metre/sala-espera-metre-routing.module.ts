import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalaEsperaMetreComponent } from './sala-espera-metre.component';

const routes: Routes = [
  {
    path: '',
    component: SalaEsperaMetreComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SalaEsperaMetreRoutingModule {}
