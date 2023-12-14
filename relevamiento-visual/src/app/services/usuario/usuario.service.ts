import { Injectable } from '@angular/core';
import { Auth, signInWithEmailAndPassword, signOut } from '@angular/fire/auth';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private auth :Auth) { }

  public IniciarSesion(usuario :string, clave :string){
    return signInWithEmailAndPassword(this.auth, usuario, clave);
  }

  public CerrarSesion(){
    return signOut(this.auth);
  }
}
