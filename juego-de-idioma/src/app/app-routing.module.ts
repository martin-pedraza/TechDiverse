import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'acceso',
    loadChildren: () =>
      import('./modules/login/login.module').then((m) => m.LoginModule),
  },
  {
    path: '',
    redirectTo: 'splash',
    pathMatch: 'full',
  },
  {
    path: 'principal',
    loadChildren: () =>
      import('./modules/principal/principal.module').then(
        (m) => m.PrincipalModule
      ),
  },
  {
    path: 'splash',
    loadChildren: () =>
      import('./modules/splash/splash.module').then((m) => m.SplashModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
