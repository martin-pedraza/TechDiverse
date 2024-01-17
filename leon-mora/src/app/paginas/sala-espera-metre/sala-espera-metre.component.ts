import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccesoService } from 'src/app/services/acceso.service';
import { MesaService } from 'src/app/services/mesa.service';
import { UsuariosService } from 'src/app/services/usuarios.service';

@Component({
  selector: 'app-sala-espera-metre',
  templateUrl: './sala-espera-metre.component.html',
  styleUrls: ['./sala-espera-metre.component.scss'],
})
export class SalaEsperaMetreComponent implements OnInit, OnDestroy {
  listaMesaActivo: any[] = [];
  listaMesaAsignada: any[] = [];
  mesaSuscripcion: Subscription | null;
  titulo: string = 'En espera';
  showSpinner: boolean = false;
  listaClientes: any[] = [];
  clienteSuscripcion: Subscription | null;
  modoAsignar: boolean = false;
  cliente: string = '';
  idCliente: string = '';

  constructor(
    private mesaService: MesaService,
    private usuariosService: UsuariosService,
    private accesoService: AccesoService,
    private router: Router
  ) {}

  ngOnInit() {
    this.mesaSuscripcion = this.mesaService.traerMesas().subscribe((lista) => {
      this.listaMesaActivo = [];
      this.listaMesaAsignada = [];
      for (let index = 0; index < lista.length; index++) {
        const element: any = lista[index];
        if (element['estado'] == 'activo') {
          this.listaMesaActivo.push(element);
        } else {
          this.listaMesaAsignada.push(element);
        }
      }
    });

    this.clienteSuscripcion = this.usuariosService
      .traerUsuarios()
      .subscribe((lista) => {
        this.listaClientes = [];
        for (let index = 0; index < lista.length; index++) {
          const element: any = lista[index];
          if (
            element['estado'] == 'en-espera' &&
            element['tipo'] == 'cliente'
          ) {
            this.listaClientes.push(element);
          }
        }
      });
  }

  ngOnDestroy() {
    this.mesaSuscripcion?.unsubscribe();
    this.clienteSuscripcion?.unsubscribe();
  }

  cambiarTitulo(titulo: string) {
    this.titulo = titulo;
  }

  asignarMesa(idCliente: string, nombreCliente: string) {
    this.cliente = nombreCliente;
    this.idCliente = idCliente;
    this.modoAsignar = true;
    this.titulo = 'Mesas libres';
  }

  reservarMesa(idMesa: string, numeroMesa: string) {
    if (this.cliente) {
      this.mesaService.actualizarMesa(idMesa, {
        cliente: this.cliente,
        estado: 'asignado',
      });
      this.usuariosService.actualizarUsuario(this.idCliente, {
        estado: 'con mesa',
        mesa: numeroMesa,
      });
      this.titulo = 'Mesas asignadas';
      this.modoAsignar = false;
      this.cliente = '';
      this.idCliente = '';
    }
  }

  rechazarCliente() {
    this.usuariosService.actualizarUsuario(this.idCliente, {
      estado: 'activo',
    });
    this.modoAsignar = false;
    this.titulo = 'En espera';
  }

  cerrarSesion() {
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }
}
