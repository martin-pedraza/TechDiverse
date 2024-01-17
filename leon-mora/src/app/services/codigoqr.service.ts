import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
// La documentacion del uso de la API se encuentra aqui: https://goqr.me/
export class CodigoqrService {
  endpoint :string = 'https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=';
  apiUrl :string = 'http://api.qrserver.com/v1/read-qr-code/';


  constructor(private http :HttpClient) { }

  generarQR(qrEndpoint :string){
    return this.http.get(qrEndpoint);
  }

  usarEndpoint(nombre :string):string{
    return this.endpoint + nombre;
  }

  leerQR(fileUrl: string): Observable<any> {
    const apiUrl = `${this.apiUrl}?fileurl=${encodeURIComponent(fileUrl)}`;

    return this.http.get(apiUrl);
  }
}
