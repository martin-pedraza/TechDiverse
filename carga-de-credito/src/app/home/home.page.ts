import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user/user.service';
import jsQR, { QRCode } from 'jsqr';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit, OnDestroy {
  private video: HTMLVideoElement | undefined;
  private estaEncendido: boolean = false;
  qr10: string = '8c95def646b6127282ed50454b73240300dccabc';
  qr50: string = 'ae338e4e0cbb4e4bcffaf9ce5b409feb8edd5172 ';
  qr100: string = '2786f4877b9091dcad7f35751bfcf5d5ea712b2f';
  mensaje: string = '';
  creditos: number = 0;
  private creditoSubscription: Subscription | undefined;

  constructor(private router: Router, private userService: UserService) {}

  ngOnInit() {
    this.estaEncendido = true;
    this.initCamera();

    this.creditoSubscription = this.userService.creditoObservable.subscribe(
      (credito) => {
        this.creditos = credito;
      }
    );

    this.userService.TraerCreditos();
  }

  ngOnDestroy() {
    this.stopCamera();
    this.estaEncendido = false;
    this.creditoSubscription?.unsubscribe();
  }

  private initCamera() {
    this.video = document.getElementById('qr') as HTMLVideoElement;

    const constraints: MediaStreamConstraints = {
      video: {
        facingMode: { ideal: 'environment' },
      },
    };

    navigator.mediaDevices.getUserMedia(constraints).then((stream) => {
      if (this.video) {
        this.video.srcObject = stream;
        this.video.play();
        this.scanQRCode();
      }
    });
  }

  private stopCamera() {
    if (this.video && this.video.srcObject) {
      const tracks = (this.video.srcObject as MediaStream).getTracks();
      tracks.forEach((track) => track.stop());
    }
  }

  private scanQRCode() {
    if (!this.video) {
      console.error('Video or canvas is undefined.');
      return;
    }

    const qrElement = this.video;

    const scan = () => {
      if (qrElement && qrElement instanceof HTMLVideoElement) {
        qrElement.width = qrElement.videoWidth;
        qrElement.height = qrElement.videoHeight;

        const canvas = document.createElement('canvas');
        canvas.width = qrElement.videoWidth;
        canvas.height = qrElement.videoHeight;
        const canvasContext = canvas.getContext('2d', {
          willReadFrequently: true,
        });

        if (canvasContext !== null) {
          canvasContext.drawImage(
            qrElement,
            0,
            0,
            qrElement.width,
            qrElement.height
          );

          const imageData = canvasContext.getImageData(
            0,
            0,
            qrElement.width,
            qrElement.height
          );

          const code: QRCode | null = jsQR(
            imageData.data,
            imageData.width,
            imageData.height
          );

          if (code) {
            this.CargarCredito(code.data);
          }
        }

        if (this.estaEncendido) {
          requestAnimationFrame(scan);
        }
      }
    };

    this.video.addEventListener('canplay', () => {
      requestAnimationFrame(scan);
    });
  }

  CargarCredito(codigo: string) {
    if (this.ValidarUsuario(codigo)) {
      switch (codigo) {
        case this.qr10:
          this.userService.ActualizarRegistro(10);
          this.mensaje = '10 créditos sumados';
          break;
        case this.qr50:
          this.userService.ActualizarRegistro(50);
          this.mensaje = '50 créditos sumados';
          break;
        case this.qr100:
          this.userService.ActualizarRegistro(100);
          this.mensaje = '100 créditos sumados';
          break;
        default:
          this.mensaje = 'QR no registrado';
      }
    } else {
      this.mensaje = 'No se cargó crédito';
    }
  }

  ValidarUsuario(codigo: string): boolean {
    const index = this.userService.usuarios?.findIndex(
      (obj) => obj.correo == localStorage.getItem('usuario')
    );

    if (
      this.userService.usuarios != undefined &&
      index != -1 &&
      index != undefined
    ) {
      const usuarioActual = this.userService.usuarios[index];
      if (!usuarioActual.admin) {
        if (
          (codigo == this.qr10 && usuarioActual['10'] > 0) ||
          (codigo == this.qr50 && usuarioActual['50'] > 0) ||
          (codigo == this.qr100 && usuarioActual['100'] > 0)
        ) {
          return false;
        }
        return true;
      } else {
        if (
          (codigo == this.qr10 && usuarioActual['10'] > 1) ||
          (codigo == this.qr50 && usuarioActual['50'] > 1) ||
          (codigo == this.qr100 && usuarioActual['100'] > 1)
        ) {
          return false;
        }
        return true;
      }
    }

    return false;
  }

  LimpiarCredito() {
    this.mensaje = 'Créditos limpiados';
    this.userService.ActualizarRegistro(0);
  }

  public CerrarSesion() {
    this.userService.CerrarSesion().then(() => {
      localStorage.clear();
      this.stopCamera();
      this.router.navigateByUrl('/acceso');
    });
  }
}
