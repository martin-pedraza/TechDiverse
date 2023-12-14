import { Component, OnDestroy } from '@angular/core';
import { AlarmService } from 'src/app/services/alarm/alarm.service';
import { Flashlight } from '@ionic-native/flashlight/ngx';
import { Vibration } from '@awesome-cordova-plugins/vibration/ngx';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnDestroy {
  private izquierda = './../../../assets/izquierda.wav';
  private derecha = './../../../assets/derecha.wav';
  private arriba = './../../../assets/arriba.wav';
  private abajo = './../../../assets/abajo.wav';
  private clave = './../../../assets/clave.wav';
  private audio = new Audio();
  private isListeningToDeviceMotion = false;
  currentPositionCellPhone = 'actual';
  previousPositionCellPhone = 'anterior';
  firstAdmission = true;
  firstAdmissionFlash = true;

  public get AlarmaActivada(): boolean {
    return this.alarmService.alarmaActivada;
  }

  constructor(
    private alarmService: AlarmService,
    private flashlight: Flashlight,
    private vibration: Vibration
  ) {}

  public CambiarEstadoAlarma() {
    this.alarmService.CambiarEstado();
    this.updateDeviceMotionListener();
  }

  private updateDeviceMotionListener() {
    if (this.AlarmaActivada) {
      this.startDeviceMotionListener();
    } else {
      this.stopDeviceMotionListener();
    }
  }

  private startDeviceMotionListener() {
    if (!this.isListeningToDeviceMotion) {
      window.addEventListener(
        'devicemotion',
        this.handleDeviceMotion.bind(this),
        false
      );
      this.isListeningToDeviceMotion = true;
    }
  }

  private stopDeviceMotionListener() {
    if (this.isListeningToDeviceMotion) {
      window.removeEventListener(
        'devicemotion',
        this.handleDeviceMotion,
        false
      );
      this.isListeningToDeviceMotion = false;
      this.audio.pause();
    }
  }

  private handleDeviceMotion(event: DeviceMotionEvent) {
    if (this.isListeningToDeviceMotion) {
      const acceleration = event.accelerationIncludingGravity;
      if (acceleration) {
        const x = acceleration.x;
        const y = acceleration.y;
        const z = acceleration.z;

        if (x !== null && y !== null && z !== null) {
          if (x < -5) {
            this.currentPositionCellPhone = 'izquierda';
            this.playSoundLeft();
          } else if (x > 5) {
            this.currentPositionCellPhone = 'derecha';
            this.playSoundRight();
          }

          if (y >= 9) {
            this.currentPositionCellPhone = 'arriba';
            this.playSoundVertical();
            this.EncenderLinterna();
          } else if (z >= 9 && y >= -1 && y <= 1 && x >= -1 && x <= 1) {
            this.currentPositionCellPhone = 'horizontal';
            this.playSoundHorizontal();
            this.Vibrar();
          }
        }
      }
    }
  }

  private playSoundLeft() {
    if (this.currentPositionCellPhone != this.previousPositionCellPhone) {
      this.previousPositionCellPhone = 'izquierda';
      this.audio.src = this.izquierda;
      this.audio.play();
    }
  }

  private playSoundRight() {
    if (this.currentPositionCellPhone != this.previousPositionCellPhone) {
      this.previousPositionCellPhone = 'derecha';
      this.audio.src = this.derecha;
      this.audio.play();
    }
  }

  private playSoundVertical() {
    if (this.currentPositionCellPhone != this.previousPositionCellPhone) {
      this.previousPositionCellPhone = 'arriba';
      this.audio.src = this.arriba;
      this.audio.play();
      this.firstAdmissionFlash = true;
    }
  }

  private playSoundHorizontal() {
    if (this.currentPositionCellPhone != this.previousPositionCellPhone) {
      this.previousPositionCellPhone = 'horizontal';
      this.audio.src = this.abajo;
      this.audio.play();
      this.firstAdmission = true;
    }
  }

  public SonarAlarma() {
    this.audio.src = this.clave;
    this.audio.play();
    this.firstAdmission = true;
    this.firstAdmissionFlash = true;
    this.Vibrar();
    this.EncenderLinterna();
  }

  public EncenderLinterna() {
    if (this.firstAdmissionFlash) {
      this.flashlight.switchOn().then(() =>
        setTimeout(() => {
          this.firstAdmissionFlash = false;
          this.flashlight.switchOff();
        }, 5000)
      );
    }
  }

  public Vibrar() {
    if (this.firstAdmission) {
      this.vibration.vibrate(5000);
      this.firstAdmission = false;
    }
  }

  ngOnDestroy() {
    this.stopDeviceMotionListener();
  }
}
