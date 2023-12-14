import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent  implements OnInit {
  public usuario :string = "";
  public clave :string = "";

  constructor(private router :Router, private userService :UserService) { }

  ngOnInit() {}

  public AutocompletarUno(){
    this.usuario = "admin@admin.com";
    this.clave = "111111";
  }

  public AutocompletarDos(){
    this.usuario = "invitado@invitado.com";
    this.clave = "222222";
  }

  public AutocompletarTres(){
    this.usuario = "usuario@usuario.com";
    this.clave = "333333";
  }

  public Acceder(usuario :string, clave :string){
    this.userService.IniciarSesion(usuario, clave)
      .then(respuesta => {
        this.usuario = "";
        this.clave = "";
        this.router.navigateByUrl("/principal")
      });
  }
}
