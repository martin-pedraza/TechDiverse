import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomePage } from 'src/app/modules/home/home.page';
import { AlarmService } from 'src/app/services/alarm/alarm.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss'],
})
export class PasswordComponent implements OnInit {
  public clavePedida: boolean = false;
  public claveIngresada: string = '';

  constructor(
    private alarmService: AlarmService,
    private userService: UserService,
    private router: Router,
    private homePage: HomePage
  ) {}

  ngOnInit() {}

  public PedirClave() {
    this.clavePedida = true;
  }

  public CancelarPedidoClave() {
    this.clavePedida = false;
  }

  public DesactivarAlarma(clave: string) {
    this.userService
      .IniciarSesion(this.userService.correo, clave)
      .then((r) => {
        this.clavePedida = false;
        this.homePage.CambiarEstadoAlarma();
      })
      .catch(() => this.homePage.SonarAlarma());
  }

  public CerrarSesion(clave: string) {
    this.userService
      .IniciarSesion(this.userService.correo, clave)
      .then((r) => {
        this.clavePedida = false;
        this.homePage.CambiarEstadoAlarma();
        this.router.navigateByUrl('/acceso');
      })
      .catch(() => this.homePage.SonarAlarma());
  }
}
