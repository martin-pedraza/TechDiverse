import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'acceso',
    pathMatch: 'full',
  },
  {
    path: 'acceso',
    loadChildren: () => import('./modules/login/login.module').then(mod=>mod.LoginModule),
  },
  {
    path: 'inicio',
    loadChildren: () => import('./modules/home/home.module').then(mod=>mod.HomeModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
