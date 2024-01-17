import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { Mesa } from 'src/app/models/mesa';
import { MesaService } from 'src/app/services/mesa.service';
import { Camera, CameraResultType } from '@capacitor/camera';
import { CodigoqrService } from 'src/app/services/codigoqr.service';
import { environment } from 'src/environments/environment';
import { initializeApp } from 'firebase/app';

@Component({
  selector: 'app-alta-mesa',
  templateUrl: './alta-mesa.page.html',
  styleUrls: ['./alta-mesa.page.scss'],
})
export class AltaMesaPage implements OnInit {
  numero: FormControl = new FormControl('', [Validators.required]);
  capacidad: FormControl = new FormControl('', [Validators.required]);
  tipo: string;
  fotoMesa: any = '';
  fotoFisicaMesa: any;
  showSpinner: boolean = false;
  selectedFile: File | null = null;

  constructor(
    private mesaServ: MesaService,
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

    this.fotoMesa = image.webPath;

    if (image.webPath) {
      let foto = image.webPath;

      this.fotoMesa = foto;
      this.fotoFisicaMesa = await fetch(foto).then((response) =>
        response.blob()
      );
    }
  }

  async crearMesa(form: NgForm) {
    const downloadURL = await this.mesaServ.uploadImage(
      this.fotoFisicaMesa,
      'mesa_images/ID-' +
        this.numero.value?.toString() +
        '-Capacidad-' +
        this.capacidad.value?.toString() +
        '-' +
        this.tipo
    );

    const qr = this.codigoqrService.usarEndpoint(
      `Mesa-${this.numero.value?.toString()}-${this.capacidad.value?.toString()}-${
        this.tipo
      }`
    );

    let mesa: Mesa = {
      numero: this.numero.value?.toString(),
      capacidad: this.capacidad.value?.toString(),
      tipo: this.tipo,
      foto: downloadURL,
      estado: 'activo',
      qr: qr,
      cliente: '',
    };
    this.showSpinner = true;
    setTimeout(() => {
      this.mesaServ.agregarMesa(mesa);
      this.showSpinner = false;
      // Reiniciar el formulario y limpiar variables
      form.resetForm();
      this.numero.reset();
      this.capacidad.reset();
      this.tipo = '';
      this.fotoMesa = '';
      this.fotoFisicaMesa = null;
    }, 2000);
  }

  cambiarTipo(event: any) {
    this.tipo = event.detail.value;
  }
}
