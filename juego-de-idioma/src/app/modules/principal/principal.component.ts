import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss'],
})
export class PrincipalComponent implements OnInit {
  public opcionElegida: string = 'animales';
  public idiomaElegido: string = 'español';
  botonIdioma: string = './../../../assets/flags/espana.png';
  botonOpcion: string = 'logo-tux';

  constructor(private router: Router, private userService: UserService) {}

  ngOnInit() {}

  public CambiarOpcion(opcion: string) {
    this.opcionElegida = opcion;
    switch (opcion) {
      case 'colores':
        this.botonOpcion = 'color-palette';
        break;
      case 'numeros':
        this.botonOpcion = 'calendar-number-outline';
        break;
      default:
        this.botonOpcion = 'logo-tux';
    }
  }

  public CambiarIdioma(idioma: string) {
    this.idiomaElegido = idioma;
    switch (idioma) {
      case 'ingles':
        this.botonIdioma = './../../../assets/flags/england.png';
        break;
      case 'portugues':
        this.botonIdioma = './../../../assets/flags/portugal.png';
        break;
      default:
        this.botonIdioma = './../../../assets/flags/espana.png';
    }
  }

  public EmitirSonido(opcion: string) {
    const audio = new Audio(
      './../../../assets/' + this.idiomaElegido + '-' + opcion + '.wav'
    );
    audio.play();
  }

  public CerrarSesion() {
    this.userService
      .CerrarSesion()
      .then((response) => this.router.navigateByUrl('/acceso'));
  }
}
