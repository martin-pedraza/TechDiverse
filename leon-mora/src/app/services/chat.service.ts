import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { NavController } from '@ionic/angular';
import { AlertController } from '@ionic/angular';
import {
  AngularFirestore,
  AngularFirestoreCollection,
} from '@angular/fire/compat/firestore';
import { map } from 'rxjs/operators';
import Swal from 'sweetalert2';

export interface Mensaje {
  emailUsuario: any;
  nombre: any;
  mensaje?: string;
  fecha?: string;
  uid?: string;
}

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  myDate = new Date();
  private itemCollections: AngularFirestoreCollection<Mensaje> | null = null;
  public chats: Mensaje[] = [];
  public usuario: any = {};

  constructor(
    public auth: AngularFireAuth,
    public navCtrl: NavController,
    public alertController: AlertController,
    private afs: AngularFirestore
  ) {
    this.auth.authState.subscribe((user) => {
      if (!user) {
        return;
      }
      this.usuario.nombre = user.email;
      this.usuario.uid = user.uid;
    });
  }

  cargarMensajes(coleccion: string) {
    this.itemCollections = this.afs.collection<Mensaje>(coleccion, (ref) =>
      ref.orderBy('fecha', 'desc').limit(20)
    );

    return this.itemCollections.valueChanges().pipe(
      map((mensajes: Mensaje[]) => {
        this.chats = [];
        for (let mensaje of mensajes) {
          this.chats.unshift(mensaje);
        }
      })
    );
  }

  // Método para eliminar todos los registros de la colección
  eliminarMensajes(coleccion: string) {
    // Obtener referencia a la colección
    const collectionRef = this.afs.collection(coleccion);

    // Obtener los documentos de la colección
    collectionRef
      .get()
      .toPromise()
      .then((querySnapshot) => {
        // Eliminar cada documento
        querySnapshot?.forEach((doc) => {
          doc.ref.delete();
        });

        // Opcional: También puedes limpiar el arreglo local si lo estás utilizando
        this.chats = [];
      })
      .catch((error) => {
        console.error('Error eliminando mensajes: ', error);
      });
  }

  agregarMensaje(texto: string, nombreUsuario: string, emailUsuario: string) {
    let fecha = new Date();
    let mensaje: Mensaje = {
      emailUsuario: emailUsuario,
      nombre: nombreUsuario,
      mensaje: texto,
      fecha: fecha.toLocaleDateString() + ' ' + fecha.toLocaleTimeString(),
      uid: this.usuario.uid,
    };

    return this.itemCollections?.add(mensaje);
  }
}
