import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccesoService } from 'src/app/services/acceso.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-duenio-panel',
  templateUrl: './duenio-panel.page.html',
  styleUrls: ['./duenio-panel.page.scss'],
})
export class DuenioPanelPage implements OnInit {
  showSpinner = false;
  usuariosPendientes: any[] = [];

  constructor(
    private usuariosServ: UsuariosService,
    private accesoService: AccesoService,
    private router: Router
  ) {}

  ngOnInit() {
    this.obtenerClientesPendientes();
  }

  async obtenerClientesPendientes() {
    try {
      (
        await this.usuariosServ.obtenerClientesPendientes(
          'pendiente-confirmacion'
        )
      ).subscribe((usuarios) => {
        this.usuariosPendientes = usuarios;
      });
    } catch (error) {
      console.error('Error al obtener:', error);
    }
  }

  decidir(
    dni: string,
    nombre: string,
    apellido: string,
    estado: string,
    email: string
  ) {
    console.log('Decidir', dni, apellido, estado);
    this.showSpinner = true;
    setTimeout(() => {
      this.showSpinner = false;
      this.usuariosServ.cambiarEstadoUsuario(
        dni,
        nombre,
        apellido,
        estado,
        email
      );
      Swal.fire({
        title: 'Notificacion enviada!',
        icon: 'success',
        heightAuto: false,
      });
    }, 2000);
  }

  cerrarSesion() {
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }
}
