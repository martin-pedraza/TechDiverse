import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  ActionPerformed,
  PushNotificationSchema,
  PushNotifications,
  Token,
} from '@capacitor/push-notifications';

import {
  LocalNotifications,
  ActionPerformed as localNotificationActionPerformed,
} from '@capacitor/local-notifications';

import { Platform } from '@ionic/angular';
import { UsuariosService } from './usuarios.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AccesoService } from './acceso.service';

@Injectable({
  providedIn: 'root',
})
export class PushNotificationsService {
  constructor(
    private router: Router,
    private platform: Platform,
    private accesoService: AccesoService,
    private userService: UsuariosService,
    private http: HttpClient
  ) {}

  async inicializar() {
    this.addListeners();
    if (this.platform.is('capacitor')) {
      const result = await PushNotifications.requestPermissions();
      if (result.receive === 'granted') {
        await PushNotifications.register();
      }
    }
  }

  sendPushNotification(req): Observable<any> {
    return this.http.post<Observable<any>>(environment.fcmUrl, req, {
      headers: {
        Authorization: `key=${environment.fcmServerKey}`,
        'Content-Type': 'application/json',
      },
    });
  }

  addListeners() {
    PushNotifications.addListener('registration', (token: Token) => {
      this.userService.guardarToken(
        this.accesoService.usuarioLogueado.email,
        token.value
      );
    });

    PushNotifications.addListener('registrationError', (error: any) => {
      alert('Error on registration: ' + JSON.stringify(error));
    });

    // PushNotifications.addListener(
    //   'pushNotificationReceived',
    //   (notification: PushNotificationSchema) => {
    //     if (notification.title && notification.body) {
    //       LocalNotifications.schedule({
    //         notifications: [
    //           {
    //             title: notification.title,
    //             body: notification.body,
    //             id: 1,
    //             extra: {
    //               data: notification.data,
    //             },
    //           },
    //         ],
    //       });
    //     }
    //   }
    // );

    PushNotifications.addListener(
      'pushNotificationActionPerformed',
      (notification: ActionPerformed) => {
        this.router.navigate([notification.notification.data.ruta]);
      }
    );

    // LocalNotifications.addListener(
    //   'localNotificationActionPerformed',
    //   (notification: localNotificationActionPerformed) => {
    //     this.router.navigate([notification.notification.extra.data.ruta]);
    //   }
    // );
  }
}
