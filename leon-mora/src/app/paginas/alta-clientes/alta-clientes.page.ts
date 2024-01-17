import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Usuarios } from 'src/app/models/usuarios';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { BarcodeFormat } from '@zxing/library';
import { ValidadoresService } from 'src/app/services/validadores.service';
import { Router } from '@angular/router';
import { AccesoService } from 'src/app/services/acceso.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import { Camera, CameraResultType, CameraSource } from '@capacitor/camera';
import { ActionSheetController } from '@ionic/angular';

@Component({
  selector: 'app-alta-clientes',
  templateUrl: './alta-clientes.page.html',
  styleUrls: ['./alta-clientes.page.scss'],
})
export class AltaClientesPage implements OnInit {
  allowedFormats = [
    BarcodeFormat.PDF_417,
    BarcodeFormat.QR_CODE,
    BarcodeFormat.EAN_13,
    BarcodeFormat.CODE_128,
    BarcodeFormat.DATA_MATRIX /*, ...*/,
  ];
  nombre: FormControl = new FormControl('', [
    Validators.required,
    ValidadoresService.soloLetrasYEspacios,
  ]);
  apellido: FormControl = new FormControl('', [
    Validators.required,
    ValidadoresService.soloLetrasYEspacios,
  ]);
  dni: FormControl = new FormControl('', [
    Validators.required,
    ValidadoresService.soloNumeros,
  ]);
  cuil: FormControl = new FormControl('', [
    Validators.required,
    ValidadoresService.soloNumeros,
  ]);
  mail: FormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  clave: FormControl = new FormControl('', [Validators.required]);
  foto: string = '';
  showSpinner: boolean = false;
  mostrarScanner: boolean = false;
  selectedFile: any;
  anonimo: boolean = false;

  tokenSupervisores: string[] = [];

  constructor(
    private usuarioServ: UsuariosService,
    private pushNotification: PushNotificationsService,
    private router: Router,
    private accesoServ: AccesoService,
    private actionSheetController: ActionSheetController
  ) {}

  ngOnInit() {
    this.usuarioServ.traerSupervisores().subscribe((supervisores: any) => {
      this.tokenSupervisores = [];
      supervisores.forEach((sup: any) => {
        if (sup.token != '') {
          this.tokenSupervisores.push(sup.token);
        }
      });
    });
  }

  async crearCliente() {
    try {
      let cliente: Usuarios;
      if (this.anonimo) {
        const downloadURL = await this.usuarioServ.uploadImage(
          this.selectedFile,
          `clientes_images/CL-${this.nombre.value?.toString()}-clienteAnonimo`
        );

        cliente = {
          nombre: this.nombre.value?.toString(),
          foto: downloadURL,
          tipo: 'cliente-anonimo',
          estado: 'activo',
          mesa: '',
          pedidoActualId: '',
          pedidoActualEstado: 'sin-pedido',
        };
        this.usuarioServ.agregarUsuario(cliente, 'Anonimo ingresado!');
        this.accesoServ.usuarioLogueado = cliente;

        this.showSpinner = true;
        setTimeout(() => {
          this.router.navigate(['sala-espera-cliente']);
          this.showSpinner = false;
        }, 2000);
      } else {
        const downloadURL = await this.usuarioServ.uploadImage(
          this.selectedFile,
          `clientes_images/CL-${this.dni.value?.toString()}-clienteRegistrado`
        );

        cliente = {
          nombre: this.nombre.value?.toString(),
          apellido: this.apellido.value?.toString(),
          dni: this.dni.value?.toString(),
          email: this.mail.value?.toString(),
          clave: this.clave.value?.toString(),
          foto: downloadURL,
          tipo: 'cliente',
          estado: 'pendiente-confirmacion',
          mesa: '',
          pedidoActualId: '',
          pedidoActualEstado: 'sin-pedido',
        };
        this.usuarioServ.agregarCliente(cliente, 'Cliente agregado con exito!');
        // Enviando push a Dueño
        this.sendPush(cliente);
        this.showSpinner = true;
        setTimeout(() => {
          this.formReset();
          this.router.navigate(['inicio-sesion']);
          this.showSpinner = false;
        }, 2000);
      }
    } catch (err) {
      console.log('Error al crear cliente: ', err);
    }
  }

  formReset() {
    this.nombre.reset();
    this.apellido.reset();
    this.dni.reset();
    this.foto = '';
    this.mail.reset();
    this.clave.reset();
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  public scanSuccessHandler($event: any) {
    this.mostrarScanner = false;
    try {
      this.nombre.setValue($event.split('@')[2]);
      this.apellido.setValue($event.split('@')[1]);
      this.dni.setValue($event.split('@')[4]);
    } catch (error) {
      console.error(error);
    }
  }

  public enableScanner() {
    this.mostrarScanner = !this.mostrarScanner;
  }

  cambiarAnonimo(estado: boolean) {
    this.anonimo = estado;

    if (this.anonimo) {
      this.apellido.setValue('');
      this.apellido.disable();
      this.dni.disable();
      this.dni.setValue('');
      this.mail.setValue('');
      this.mail.disable();
      this.clave.setValue('');
      this.clave.disable();
    } else {
      this.apellido.enable();
      this.dni.enable();
      this.mail.enable();
      this.clave.enable();
    }
    this.apellido.updateValueAndValidity();
    this.dni.updateValueAndValidity();
    this.mail.updateValueAndValidity();
    this.clave.updateValueAndValidity();
  }

  sendPush(cliente: any) {
    console.log(this.tokenSupervisores);
    // Enviar notificacion solamente a los dueños, sin hardcodear
    this.pushNotification
      .sendPushNotification({
        registration_ids: this.tokenSupervisores,
        notification: {
          image:
            'https://static.vecteezy.com/system/resources/previews/014/616/982/original/judge-hammer-use-knocks-to-decide-a-lawsuit-a-wooden-hammer-to-hit-the-auction-close-png.png',
          title: 'Hay clientes esperando tu aceptacion! ✅🆗',
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

  async presentActionSheet() {
    const actionSheet = await this.actionSheetController.create({
      header: 'Seleccionar fuente de imagen',
      buttons: [
        {
          text: 'Cámara',
          icon: 'camera',
          handler: () => {
            this.tomarFoto(CameraSource.Camera);
            actionSheet.dismiss();
          },
        },
        {
          text: 'Galería',
          icon: 'images',
          handler: () => {
            this.tomarFoto(CameraSource.Photos);
            actionSheet.dismiss();
          },
        },
        {
          text: 'Cancelar',
          icon: 'close',
          role: 'cancel',
        },
      ],
    });
    await actionSheet.present();
  }

  public async tomarFoto(source: CameraSource) {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Uri,
      source: source,
      quality: 100,
    });

    if (capturedPhoto.webPath) {
      const foto = capturedPhoto.webPath;

      this.foto = foto;
      this.selectedFile = await fetch(foto).then((response) => response.blob());
    }
  }
}
