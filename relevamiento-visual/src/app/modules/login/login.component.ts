import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent  implements OnInit {
  public usuario :string = "";
  public clave :string = "";

  constructor(private router :Router, private usuarioService :UsuarioService) { }

  ngOnInit() {}

  public AutocompletarUno(){
    this.usuario = "tester@tester.com";
    this.clave = "555555";
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
    this.usuarioService.IniciarSesion(usuario, clave)
      .then(respuesta => {
        this.usuario = "";
        this.clave = "";
        localStorage.setItem('creador', usuario);
        this.router.navigateByUrl("/inicio")
      });
  }
}
