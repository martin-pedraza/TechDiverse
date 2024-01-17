import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { Camera, CameraResultType } from '@capacitor/camera';
import { initializeApp } from 'firebase/app';
import { Producto } from 'src/app/models/producto';
import { CodigoqrService } from 'src/app/services/codigoqr.service';
import { ProductoService } from 'src/app/services/producto.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-alta-producto',
  templateUrl: './alta-producto.component.html',
  styleUrls: ['./alta-producto.component.scss'],
})
export class AltaProductoPage implements OnInit {
  nombre: FormControl = new FormControl('', [Validators.required]);
  descripcion: FormControl = new FormControl('', [Validators.required]);
  tiempo: FormControl = new FormControl('', [Validators.required]);
  precio: FormControl = new FormControl('', [Validators.required]);
  fotoUno: any = '';
  fotoDos: any = '';
  fotoTres: any = '';
  fotoFisicaUno: any;
  fotoFisicaDos: any;
  fotoFisicaTres: any;
  showSpinner: boolean = false;
  contador: number = 3;

  constructor(
    private productoService: ProductoService,
    private codigoqrService: CodigoqrService
  ) {}

  ngOnInit() {
    initializeApp(environment.firebaseConfig);
  }

  async takePicture() {
    const image = await Camera.getPhoto({
      quality: 90,
      allowEditing: true,
      resultType: CameraResultType.Uri,
    });

    if (image.webPath) {
      let foto = image.webPath;
      await this.asignarImagen(foto);
      this.disminuirContadorFoto();
    }
  }

  async crearProducto(form: NgForm) {
    const downloadURLUno = await this.cargarImagen(
      this.fotoFisicaUno,
      this.fotoUno
    );

    const downloadURLDos = await this.cargarImagen(
      this.fotoFisicaDos,
      this.fotoDos
    );

    const downloadURLTres = await this.cargarImagen(
      this.fotoFisicaTres,
      this.fotoTres
    );

    const qr = this.crearQR();

    const producto: Producto = this.construirProducto(
      downloadURLUno,
      downloadURLDos,
      downloadURLTres,
      qr
    );

    this.showSpinner = true;

    setTimeout(() => {
      this.productoService.agregarProducto(producto);
      this.showSpinner = false;
      this.reiniciarCampos(form);
    }, 2000);
  }

  cambiarTipo(event: any) {
    this.tiempo = event.detail.value;
  }

  async asignarImagen(foto: any) {
    if (!this.fotoUno) {
      this.fotoUno = foto;
      this.fotoFisicaUno = await fetch(foto).then((response) =>
        response.blob()
      );
    } else if (!this.fotoDos) {
      this.fotoDos = foto;
      this.fotoFisicaDos = await fetch(foto).then((response) =>
        response.blob()
      );
    } else if (!this.fotoTres) {
      this.fotoTres = foto;
      this.fotoFisicaTres = await fetch(foto).then((response) =>
        response.blob()
      );
    }
  }

  disminuirContadorFoto() {
    this.contador--;
  }

  cargarImagen(fotoFisica: any, foto: any) {
    return this.productoService.uploadImage(
      fotoFisica,
      'producto_images/' + this.nombre + '-' + foto
    );
  }

  crearQR() {
    return this.codigoqrService.usarEndpoint(
      `${this.nombre.value?.toString()}-${this.descripcion.value?.toString()}`
    );
  }

  construirProducto(
    downloadURLUno: any,
    downloadURLDos: any,
    downloadURLTres: any,
    qr: string
  ) {
    return {
      nombre: this.nombre.value?.toString(),
      descripcion: this.descripcion.value?.toString(),
      tiempo: this.tiempo.value?.toString(),
      precio: this.precio.value?.toString(),
      fotoUno: downloadURLUno,
      fotoDos: downloadURLDos,
      fotoTres: downloadURLTres,
      qr: qr,
    };
  }

  reiniciarCampos(form: NgForm) {
    form.resetForm();
    this.nombre.reset();
    this.descripcion.reset();
    this.tiempo.reset();
    this.precio.reset();
    this.fotoUno = '';
    this.fotoDos = '';
    this.fotoTres = '';
    this.contador = 3;
    this.fotoFisicaUno = null;
    this.fotoFisicaDos = null;
    this.fotoFisicaTres = null;
  }
}
