import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from 'src/app/components/menu/menu.component';
import { EasyComponent } from 'src/app/components/options/easy/easy.component';
import { HardComponent } from 'src/app/components/options/hard/hard.component';
import { MediumComponent } from 'src/app/components/options/medium/medium.component';
import { ReportsComponent } from 'src/app/components/options/reports/reports.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'facil',
    pathMatch: 'full',
  },
  {
    path: '',
    component: MenuComponent,
    children: [
      {
        path: 'facil',
        component: EasyComponent,
      },
      {
        path: 'medio',
        component: MediumComponent,
      },
      {
        path: 'dificil',
        component: HardComponent,
      },
      {
        path: 'top',
        component: ReportsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule { }
