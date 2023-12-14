import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './modules/error/error.component';

const routes: Routes = [
  {
    path: 'inicio',
    loadChildren: () => import('./modules/home/home.module').then( m => m.HomePageModule)
  },
  {
    path: '',
    redirectTo: 'acceso',
    pathMatch: 'full'
  },
  {
    path: 'menu',
    loadChildren: () => import('./modules/menu/menu.module').then( m => m.MenuModule)
  },
  {
    path: 'acceso',
    loadChildren: () => import('./modules/login/login.module').then( m => m.LoginModule)
  },
  {
    path: '**',
    component: ErrorComponent,
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
