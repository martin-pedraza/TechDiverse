import { Injectable } from '@angular/core';
import { UsuariosService } from './usuarios.service';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { switchMap } from 'rxjs';
import { AngularFirestore } from '@angular/fire/compat/firestore';

@Injectable({
  providedIn: 'root',
})
export class AccesoService {
  private principalList: any[] = [];
  usuarioLogueado: any;

  constructor(
    private usuariosService: UsuariosService,
    private auth: AngularFireAuth,
    private firestore: AngularFirestore
  ) {
    this.cargarListaUsuarios();
    this.inicializarUsuarioLogueado();
  }

  private cargarListaUsuarios() {
    this.usuariosService.traerUsuarios().subscribe((list) => {
      this.principalList = list;
    });
  }

  // private inicializarUsuarioLogueado() {
  //   this.auth.authState.subscribe((user) => {
  //     this.usuarioLogueado = null;
  //     if (user) {
  //       for (let index = 0; index < this.principalList.length; index++) {
  //         const element = this.principalList[index];
  //         if (user['email'] == element['email']) {
  //           this.usuarioLogueado = element;
  //         }
  //       }
  //     }
  //   });
  // }

  private inicializarUsuarioLogueado() {
    this.auth.authState.pipe(
      switchMap((user) => {
        this.usuarioLogueado = null;
        if (user) {
          return this.firestore.collection('usuarios').doc(user.uid).valueChanges();
        } else {
          return [];
        }
      })
    ).subscribe((userData: any) => {
      if (userData) {
        this.usuarioLogueado = userData;
      }
    });
  }

  // acceder(formulario: any): boolean {
  //   for (let index = 0; index < this.listaUsuarios.length; index++) {
  //     const usuario = this.listaUsuarios[index];
  //     if (
  //       usuario['email'] === formulario['mail'] &&
  //       usuario['clave'] === formulario['clave']
  //     ) {
  //       this.usuarioLogueado = usuario;
  //       return true;
  //     }
  //   }
  //   return false;
  // }

  async acceder(formulario: any): Promise<boolean> {
    try {
      await this.auth.signInWithEmailAndPassword(
        formulario['mail'],
        formulario['clave']
      );

      return true;
    } catch (error) {
      return false;
    }
  }

  cerrar() {
    // this.usuarioLogueado = null;
    this.auth.signOut();
  }
}
