import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./paginas/splash/splash.module').then((m) => m.SplashPageModule),
  },
  {
    path: 'home',
    loadChildren: () =>
      import('./paginas/home/home.module').then((m) => m.HomePageModule),
  },
  {
    path: 'inicio-sesion',
    loadChildren: () =>
      import('./paginas/inicio-sesion/inicio-sesion.module').then(
        (m) => m.InicioSesionModule
      ),
  },
  {
    path: 'alta-usuarios',
    loadChildren: () =>
      import('./paginas/alta-usuarios/alta-usuarios.module').then(
        (m) => m.AltaUsuariosPageModule
      ),
  },
  {
    path: 'alta-empleados',
    loadChildren: () =>
      import('./paginas/alta-empleados/alta-empleados.module').then(
        (m) => m.AltaEmpleadosModule
      ),
  },
  {
    path: 'alta-clientes',
    loadChildren: () =>
      import('./paginas/alta-clientes/alta-clientes.module').then(
        (m) => m.AltaClientesPageModule
      ),
  },
  {
    path: 'alta-mesa',
    loadChildren: () =>
      import('./paginas/alta-mesa/alta-mesa.module').then(
        (m) => m.AltaMesaPageModule
      ),
  },
  {
    path: 'alta-producto',
    loadChildren: () =>
      import('./paginas/alta-producto/alta-producto.module').then(
        (m) => m.AltaProductoModule
      ),
  },
  {
    path: 'accesos-rapidos',
    loadChildren: () =>
      import('./paginas/accesos-rapidos/accesos-rapidos.module').then(
        (m) => m.AccesosRapidosPageModule
      ),
  },
  {
    path: 'duenio-panel',
    loadChildren: () =>
      import('./paginas/duenio-panel/duenio-panel.module').then(
        (m) => m.DuenioPanelPageModule
      ),
  },
  {
    path: 'sala-espera-metre',
    loadChildren: () =>
      import('./paginas/sala-espera-metre/sala-espera-metre.module').then(
        (m) => m.SalaEsperaMetrePage
      ),
  },
  {
    path: 'sala-espera-cliente',
    loadChildren: () =>
      import('./paginas/sala-espera-cliente/sala-espera-cliente.module').then(
        (m) => m.SalaEsperaClientePageModule
      ),
  },
  {
    path: 'mesa',
    loadChildren: () =>
      import('./paginas/mesa/mesa.module').then((m) => m.MesaPageModule),
  },
  {
    path: 'mozo-panel',
    loadChildren: () =>
      import('./paginas/mozo-panel/mozo-panel.module').then(
        (m) => m.MozoPanelPageModule
      ),
  },
  {
    path: 'sector',
    loadChildren: () =>
      import('./paginas/sector-pedido/sector-pedido.module').then(
        (m) => m.SectorPedidoModule
      ),
  },
  {
    path: 'pedir-cuenta',
    loadChildren: () => import('./paginas/pedir-cuenta/pedir-cuenta.module').then( m => m.PedirCuentaPageModule)
  },

  {
    path: 'encuesta',
    loadChildren: () => import('./paginas/hacer-encuesta/hacer-encuesta.module').then( m => m.HacerEncuestaPageModule)
  },

  
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
