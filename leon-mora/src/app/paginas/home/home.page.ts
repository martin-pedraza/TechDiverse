import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavController } from '@ionic/angular';
import { BarcodeFormat } from '@zxing/library';
import { Subscription } from 'rxjs';
import { AccesoService } from 'src/app/services/acceso.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit, OnDestroy {
  allowedFormats = [BarcodeFormat.QR_CODE];
  mostrarScanner: boolean = false;
  valorScanneado = '';
  showSpinner = false;
  tokenMetres: string[] = [];
  suscripcion: Subscription | undefined;

  constructor(
    private navCtrl: NavController,
    private accesoService: AccesoService,
    private pushNotification: PushNotificationsService,
    private usuarioService: UsuariosService,
    private router: Router
  ) {}
  ngOnDestroy(): void {
    this.suscripcion?.unsubscribe();
  }

  ngOnInit() {
    if (this.accesoService.usuarioLogueado.tipo == 'cliente') {
      if (
        this.accesoService.usuarioLogueado.estado == 'en-espera'
      ) {
        this.router.navigate(['sala-espera-cliente']);
      }
      if (this.accesoService.usuarioLogueado.estado == 'con mesa') {
        this.router.navigate(['mesa']);
      }
    }

    this.usuarioService.trarMetres().subscribe((metres: any) => {
      this.tokenMetres = [];
      metres.forEach((metre: any) => {
        if (metre.token != '') {
          this.tokenMetres.push(metre.token);
        }
      });
    });
  }

  scanSuccessHandler($event: any) {
    this.mostrarScanner = false;

    let usuarioLoggeado = this.accesoService.usuarioLogueado;

    if (typeof $event == 'string') {
      this.valorScanneado = $event;
      if (this.valorScanneado == 'ListaDeEspera') {
        if (
          usuarioLoggeado.estado == 'activo' &&
          usuarioLoggeado.tipo == 'cliente'
        ) {
          Swal.fire({
            title: 'Se te añadio a la lista de espera!',
            icon: 'success',
            heightAuto: false,
          });
          // this.usuarioService.cambiarEstadoUsuarioSimple(
          //   usuarioLoggeado.email,
          //   'en-espera'
          // );
          this.usuarioService.actualizarUsuario(usuarioLoggeado.id, {
            estado: 'en-espera',
            pedidoActualEstado: 'sin-pedido',
          });
          this.sendPushMetre(usuarioLoggeado);
        } else if (
          this.accesoService.usuarioLogueado.tipo == 'cliente-anonimo'
        ) {
          Swal.fire({
            title:
              'Como no estas registrado como cliente, solo vas a poder ver las encuentas!',
            icon: 'success',
            heightAuto: false,
          });
        }
        this.showSpinner = true;
        setTimeout(() => {
          this.showSpinner = false;
          this.navCtrl.navigateRoot(['/sala-espera-cliente']);
        }, 2000);
      } else {
        Swal.fire({
          title: 'Lamentablemente hoy no podemos acceder a esa funcionalidad!',
          icon: 'error',
          heightAuto: false,
        });
      }
    }
  }

  sendPushMetre(cliente: any) {
    console.log('------- \n  Por mandar notificacion al METRE -------');
    console.log('TOKEN METRES: ', this.tokenMetres);
    this.pushNotification
      .sendPushNotification({
        registration_ids: this.tokenMetres,
        notification: {
          image: 'https://cdn-icons-png.flaticon.com/512/4363/4363401.png',
          title: 'Hay clientes en la sala de ESPERA! ⌛⏰',
          body: 'Datos del cliente: ' + cliente.nombre + ' ' + cliente.apellido,
        },
        data: {
          id: 1,
          nombre: 'Test',
        },
      })
      .subscribe((data) => {
        console.log(data);
      });
  }

  cerrarSesion() {
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }
}
