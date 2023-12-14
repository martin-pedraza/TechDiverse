import { Injectable } from '@angular/core';
import { Auth, signInWithEmailAndPassword, signOut } from '@angular/fire/auth';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public correo :string = "";

  constructor(private auth :Auth) { }
  
  public IniciarSesion(usuario :string, clave :string){
    return signInWithEmailAndPassword(this.auth, usuario, clave);
  }

  public CerrarSesion(){
    this.correo = "";
    return signOut(this.auth);
  }

  public GuardarCorreo(usuario :string){
    this.correo = usuario;
  }
}
