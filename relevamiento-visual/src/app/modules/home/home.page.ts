import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ListadoService } from 'src/app/services/listado/listado.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  constructor(private router: Router, private listadoService: ListadoService) {}

  public EstablecerListaFeas(esFea: boolean) {
    this.listadoService.CambiarTipoFeas(esFea);
    this.router.navigateByUrl('/menu');
  }
}
