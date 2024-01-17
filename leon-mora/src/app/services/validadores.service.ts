import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidadoresService {

  constructor() { }

  static soloNumeros(control: AbstractControl) {
    const value = control.value;
    const soloNumerosPattern = /^[0-9]+$/; 
  
    if (value && !soloNumerosPattern.test(value)) {
      return { soloNumeros: true }; 
    }
  
    return null; 
  }

  static soloLetrasYEspacios(control: AbstractControl) {
    const value = control.value;
    const soloLetrasYEspaciosPattern = /^[A-Za-z\s]+$/; 
  
    if (value && !soloLetrasYEspaciosPattern.test(value)) {
      return { soloLetrasYEspacios: true }; 
    }
  
    return null; 
  }
}
