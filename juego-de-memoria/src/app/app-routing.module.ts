import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {
    path: 'acceso',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: 'acceso',
    pathMatch: 'full'
  },
  {
    path: 'inicio',
    loadChildren: () => import('./modules/menu/menu.module').then(mod => mod.MenuModule),
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
