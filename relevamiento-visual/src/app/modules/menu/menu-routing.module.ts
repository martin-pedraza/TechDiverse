import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "camara",
    pathMatch: 'full',
  },
  {
    path: "",
    component: MenuComponent,
    children: [
      {
        path: "camara",
        loadChildren: () => import('../tabs/camera/camera.module')
          .then(mod => mod.CameraModule),
      },
      {
        path: "listado",
        loadChildren: () => import('../tabs/list/list.module')
          .then(mod => mod.ListModule),
      },
      {
        path: "informes",
        loadChildren: () => import('../tabs/reports/reports.module')
          .then(mod => mod.ReportsModule),
      },
      {
        path: "volver",
        redirectTo: "/inicio",
        pathMatch: "full",
      },
      {
        path: "cerrar",
        redirectTo: "/acceso",
        pathMatch: "full",
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule { }
