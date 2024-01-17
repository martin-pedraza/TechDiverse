import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { Usuarios } from 'src/app/models/usuarios';
import Swal from 'sweetalert2';
import { BarcodeFormat } from '@zxing/library';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { initializeApp } from 'firebase/app';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-alta-usuarios',
  templateUrl: './alta-usuarios.page.html',
  styleUrls: ['./alta-usuarios.page.scss'],
})
export class AltaUsuariosPage implements OnInit {

  allowedFormats = [BarcodeFormat.PDF_417, BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.CODE_128, BarcodeFormat.DATA_MATRIX /*, ...*/];
  nombre: FormControl = new FormControl('', [Validators.required]);
  apellido: FormControl = new FormControl('', [Validators.required]);
  dni: FormControl = new FormControl('', [Validators.required]);
  cuil: FormControl = new FormControl('', [Validators.required]);
  foto: FormControl = new FormControl('', [Validators.required]);
  showSpinner: boolean = false;
  perfil = "dueño";
  format: any;
  mostrarScanner: boolean = false;
  selectedFile: File | null = null;
  @ViewChild('altaForm') altaForm: NgForm;

  constructor(private usuarioServ: UsuariosService) { }

  ngOnInit() {
    const firebaseApp = initializeApp(environment.firebaseConfig);
  }

  async crearDuenio(form: NgForm) {

    const downloadURL = await this.usuarioServ.uploadImage(this.selectedFile, `duenio_superv_images/OP-${this.dni.value?.toString()}-${this.apellido.value?.toString()}-${this.apellido.value?.toString()}-${this.perfil}`);

    let duenio: Usuarios = {
      nombre: this.nombre.value?.toString(),
      apellido: this.apellido.value?.toString(),
      dni: this.dni.value?.toString(),
      cuil: this.cuil.value?.toString(),
      foto: downloadURL,
      tipo: this.perfil,
      estado: 'activo',
      mesa: ''
    }

    this.showSpinner = true;
    setTimeout(() => {
      this.usuarioServ.agregarCliente(duenio, 'Dueño agregado con exito!');
      this.showSpinner = false;
      Swal.fire({
        title: 'Usuario en proceso de creación!',
        icon: 'success',
        heightAuto: false,
      });
      // Reiniciar el formulario y limpiar variables
      form.resetForm();
      this.nombre.reset();
      this.apellido.reset();
      this.dni.reset();
      this.cuil.reset();
    }, 2000);

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

}