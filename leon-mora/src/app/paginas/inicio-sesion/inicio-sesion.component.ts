import { Component, OnInit } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccesoService } from 'src/app/services/acceso.service';
import { MesaService } from 'src/app/services/mesa.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-inicio-sesion',
  templateUrl: './inicio-sesion.component.html',
  styleUrls: ['./inicio-sesion.component.scss'],
})
export class InicioSesionPage implements OnInit {
  form!: FormGroup;
  showSpinner: boolean = false;

  constructor(
    private accesoService: AccesoService,
    private pushNotif: PushNotificationsService,
    private router: Router,
    // private auth: AngularFireAuth
  ) {}

  ngOnInit() {
    this.asignarFormulario();
  }

  asignarFormulario() {
    this.form = new FormGroup({
      mail: new FormControl('', [Validators.email, Validators.required]),
      clave: new FormControl('', [Validators.required]),
    });
  }

  get mail() {
    return this.form.get('mail');
  }

  get clave() {
    return this.form.get('clave');
  }

  autocompletarFormulario(tipo: string) {
    let mail: string = '';
    let clave: string = '';

    switch (tipo) {
      case 'duenio':
        mail = 'duenio@leonmora.com';
        clave = '123456';
        break;
      case 'recepcionista':
        mail = 'recepcionista@leonmora.com';
        clave = '123456';
        break;
      case 'mozo':
        mail = 'mozo@leonmora.com';
        clave = '123456';
        break;
      case 'cocinero':
        mail = 'cocinero@leonmora.com';
        clave = '123456';
        break;
      case 'bartender':
        mail = 'bartender@leonmora.com';
        clave = '123456';
        break;
      case 'clientes':
        mail = 'clientes@leonmora.com';
        clave = '123456';
        break;
    }
    this.form.setValue({
      mail: mail,
      clave: clave,
    });
  }

  async acceder() {
    this.showSpinner = true;
    let acceso: boolean; 
    await this.accesoService.acceder(this.form.value).then((value)=>{
      acceso = value;
    });
    setTimeout(() => {
      this.showSpinner = false;
      if (acceso) {
        const usuario = this.accesoService.usuarioLogueado;
        switch (usuario['tipo']) {
          case 'cliente':
            this.accederComoCliente();
            break;
          case 'duenio':
            this.pushNotif.inicializar();
            this.router.navigateByUrl('/duenio-panel');
            break;
          case 'metre':
            this.pushNotif.inicializar();
            this.router.navigateByUrl('/sala-espera-metre');
            break;
          case 'mozo':
            this.pushNotif.inicializar();
            this.router.navigateByUrl('/mozo-panel');
            break;
          case 'bartender':
          case 'cocinero':
            this.pushNotif.inicializar();
            this.router.navigateByUrl('/sector');
            break;
        }
        this.form.setValue({
          mail: '',
          clave: '',
        });
        return;
      }

      Swal.fire({
        title: 'Las credenciales no son correctas',
        icon: 'warning',
        heightAuto: false,
      });
    }, 3000);
  }

  accederComoCliente() {
    const usuario = this.accesoService.usuarioLogueado;
    switch (usuario['estado']) {
      case 'pendiente-confirmacion':
        Swal.fire({
          title: 'Su cuenta está pendiente de confirmación',
          icon: 'info',
          heightAuto: false,
        });
        break;
      case 'rechazado':
        Swal.fire({
          title: 'Su cuenta ha sido rechazada',
          icon: 'error',
          heightAuto: false,
        });
        break;
      default:
        // this.auth.signInWithEmailAndPassword(
        //   usuario['email'],
        //   usuario['clave']
        // );
        this.router.navigateByUrl('/home');
        break;
    }
  }
}
