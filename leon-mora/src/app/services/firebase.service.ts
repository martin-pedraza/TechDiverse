import { Injectable } from '@angular/core';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { from, switchMap, take } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FirebaseService {
  constructor(private firebase: AngularFirestore) {}

  async agregarRegistro(data: any, coleccion: string) {
    const colection = this.firebase.collection(coleccion);
    const newDoc = await colection.add(data);
    await newDoc.update({
      id: newDoc.id,
    });
    return newDoc.id;
  }

  traerTabla(tabla: any) {
    const col = this.firebase.collection(tabla);
    return col.valueChanges();
  }

  actualizarDocumento(id: string, coleccion: string, data: any) {
    const document = this.firebase.doc(coleccion + '/' + id);
    document.update(data);
  }

  traerTablaConAtributo(tabla: string, atributo: string, valor: string) {
    const col = this.firebase.collection(tabla, (ref) =>
      ref.where(atributo, '==', valor)
    );

    return col.valueChanges();
  }
}
