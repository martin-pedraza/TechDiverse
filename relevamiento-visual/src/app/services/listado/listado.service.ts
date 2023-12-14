import { Injectable, OnDestroy, OnInit } from '@angular/core';
import {
  Firestore,
} from '@angular/fire/firestore';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ListadoService {
  tipo_feas: boolean = true;
  public fotosFeas: any[] = [];
  public fotosLindas: any[] = [];

  public get Tipo_feas(): boolean {
    return this.tipo_feas;
  }


  constructor() {}

  public CambiarTipoFeas(esFea: boolean) {
    this.tipo_feas = esFea;
  }
}
