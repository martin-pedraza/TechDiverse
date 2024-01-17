import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { Usuarios } from 'src/app/models/usuarios';
import { FirebaseService } from 'src/app/services/firebase.service';
import Swal from 'sweetalert2';
import { BarcodeFormat } from '@zxing/library';
import { UsuariosService } from 'src/app/services/usuarios.service';
import { initializeApp } from 'firebase/app';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-alta-empleados',
  templateUrl: './alta-empleados.component.html',
  styleUrls: ['./alta-empleados.component.scss'],
})
export class AltaEmpleadosPage implements OnInit {
  allowedFormats = [
    BarcodeFormat.PDF_417,
    BarcodeFormat.QR_CODE,
    BarcodeFormat.EAN_13,
    BarcodeFormat.CODE_128,
    BarcodeFormat.DATA_MATRIX,
  ];

  nombre: FormControl = new FormControl('', [Validators.required]);
  apellido: FormControl = new FormControl('', [Validators.required]);
  dni: FormControl = new FormControl('', [Validators.required]);
  cuil: FormControl = new FormControl('', [Validators.required]);
  foto: FormControl = new FormControl('');
  showSpinner: boolean = false;
  perfil = 'empleado';
  format: any;
  mostrarScanner: boolean = false;
  selectedOption: boolean = false;
  envio: boolean = true;
  imagen: string = 'assets/images/empleados.png';

  selectedFile: File | null = null;

  constructor(private usuariosService: UsuariosService) {}

  ngOnInit() {
    initializeApp(environment.firebaseConfig);
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

  cambiarPerfil(event: any) {
    this.perfil = event.detail.value;
    this.selectedOption = this.perfil != 'empleado';
    switch (this.perfil) {
      case 'metre':
        this.imagen = 'assets/images/recepcionista.png';
        break;
      case 'mozo':
        this.imagen = 'assets/images/mozo.png';
        break;
      case 'cocinero':
        this.imagen = 'assets/images/cocinero.png';
        break;
      case 'bartender':
        this.imagen = 'assets/images/bartender.png';
        break;
      default:
        this.imagen = 'assets/images/empleados.png';
    }
  }

  async crearEmpleado(form: NgForm) {
    const downloadURL = await this.cargarImagen();

    const empleado: Usuarios = this.construirEmpleado(downloadURL);

    if (this.verificarCampos()) {
      this.showSpinner = true;
      this.usuariosService.agregarEmpleado(empleado);
      setTimeout(() => {
        this.showSpinner = false;
        Swal.fire({
          title: 'Empleado en proceso de creación!',
          icon: 'success',
          heightAuto: false,
        });
        this.reiniciarCampos(form);
      }, 2000);
    } else {
      this.envio = false;
    }
  }

  verificarCampos(): boolean {
    return (
      this.nombre.errors == null &&
      this.apellido.errors == null &&
      this.dni.errors == null &&
      this.cuil.errors == null &&
      this.selectedOption
    );
  }

  reiniciarCampos(form: NgForm) {
    form.resetForm();
    this.nombre.reset();
    this.apellido.reset();
    this.dni.reset();
    this.cuil.reset();
    this.foto.reset();
    this.perfil = 'empleado';
    this.imagen = 'assets/images/empleados.png';

    let selectElement = document.getElementById('tipo') as HTMLSelectElement;
    if (selectElement) {
      selectElement.value = '';
    }
  }

  cargarImagen(){
    return this.usuariosService.uploadImage(
      this.selectedFile,
      `empleado_images/OP-${this.dni.value?.toString()}-${this.nombre.value?.toString()}-${this.apellido.value?.toString()}-${
        this.perfil
      }`
    );
  }

  construirEmpleado(downloadURL :any){
    return {
      nombre: this.nombre.value?.toString(),
      apellido: this.apellido.value?.toString(),
      dni: this.dni.value?.toString(),
      cuil: this.cuil.value?.toString(),
      foto: downloadURL,
      tipo: this.perfil,
      estado: 'activo',
      mesa: ''
    };
  }
}
