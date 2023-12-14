import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AlarmService {
  public alarmaActivada :boolean = false;

  constructor() { }

  public CambiarEstado(){
    this.alarmaActivada = !this.alarmaActivada;
  }
}
