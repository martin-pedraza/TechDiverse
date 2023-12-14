import { Injectable } from '@angular/core';
import {
  Firestore,
  addDoc,
  collection,
  getDoc,
  updateDoc,
} from '@angular/fire/firestore';
import {
  doc,
  getDocs,
  query,
  limit,
  orderBy,
  setDoc,
  onSnapshot,
} from 'firebase/firestore';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FirebaseService {
  constructor(private firestore: Firestore) {}

  public async Guardar(listado: string, ruta?: string) {
    const col = collection(this.firestore, listado);
    const documentoNuevo = await addDoc(col, {});
    setDoc(documentoNuevo, {
      id: documentoNuevo.id,
      creador: localStorage.getItem('creador'),
      fecha: new Date(Date.now()).toLocaleDateString('es-AR'),
      segundo: Date.now(),
      foto: ruta,
      likes: 0,
      usuarios: [],
    });
  }

  public async Actualizar(listado: string, id: string) {
    const col = collection(this.firestore, listado);
    const documento = doc(col, id);
    const docSnap = await getDoc(documento);
    if (docSnap.exists()) {
      const data = docSnap.data();

      const updatedUsuarios = [
        ...data['usuarios'],
        localStorage.getItem('creador'),
      ];
      const likes = updatedUsuarios.length;

      await updateDoc(documento, {
        usuarios: updatedUsuarios,
        likes: likes,
      });
    }
  }

  public getLikesData(listado: string): Observable<any[]> {
    const col = collection(this.firestore, listado);
    const q = query(col, orderBy('likes', 'desc'), limit(5));

    return new Observable((observer) => {
      const unsubscribe = onSnapshot(q, (querySnapshot) => {
        const likesData = querySnapshot.docs.map((doc) => {
          const data = doc.data();
          return {
            id: data['id'],
            foto: data['foto'],
            likes: data['likes'],
            fecha: data['fecha'],
            creador: data['creador'].split('@')[0],
          };
        });
        observer.next(likesData);
      });
      
      return () => {
        unsubscribe();
      };
    });
  }
}
