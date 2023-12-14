import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent  implements OnInit {

  constructor(private usuarioService :UsuarioService) { }

  ngOnInit() {}

  public CerrarSesion(){
    localStorage.clear();
    this.usuarioService.CerrarSesion();
  }
}
