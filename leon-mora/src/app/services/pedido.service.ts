import { Injectable } from '@angular/core';
import { FirebaseService } from './firebase.service';
import { Usuarios } from '../models/usuarios';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PedidoService {
  
  constructor(private firestore: FirebaseService, public afs:AngularFirestore ) {}

  traerPedidosPendientes() {
    return this.firestore.traerTablaConAtributo(
      'pedidos',
      'estado',
      'pendiente-aprobacion'
    );
  }

  actualizarPedido(id: string, data: any) {
    return this.firestore.actualizarDocumento(id, 'pedidos', data);
  }

  traerPedido(id: string) {
    return this.firestore.traerTablaConAtributo('pedidos', 'id', id);
  }

  traerPedidos() {
    return this.firestore.traerTabla('pedidos');
  }


  traerPedidoUsuario(usuario: Usuarios): Observable<any[]> {
    return this.afs
      .collection('pedidos', (ref) => {
        return ref
          .where('clienteId', '==', usuario.id)
          .where('estado', '==', "pedido-entregado")
          .where('clienteNombre', '==', usuario.nombre + " " + usuario.apellido)
          .where('mesa', '==', usuario.mesa);
      })
      .snapshotChanges();
  }

  
}
