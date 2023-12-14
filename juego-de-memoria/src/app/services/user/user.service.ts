import { Injectable } from '@angular/core';
import { Auth, signInWithEmailAndPassword, signOut } from '@angular/fire/auth';
import { Firestore, addDoc, collection, limit, onSnapshot, orderBy, query, setDoc, where } from '@angular/fire/firestore';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private auth :Auth, private firestore :Firestore) { }
  
  public IniciarSesion(usuario :string, clave :string){
    return signInWithEmailAndPassword(this.auth, usuario, clave);
  }

  public CerrarSesion(){
    return signOut(this.auth);
  }

  public async GuardarUsuario(nivel :string, tiempo :number){
    const col = collection(this.firestore, "records");
    const documentoNuevo = await addDoc(col, {});
    setDoc(documentoNuevo, {
      id: documentoNuevo.id,
      usuario: localStorage.getItem("creador")?.split('@')[0],
      nivel: nivel,
      tiempo: tiempo,
      fecha: new Date(Date.now()).toLocaleDateString('es-AR'),
    })
  }

  public TraerRegistros(nivel :string): Observable<any[]>{
    const col = collection(this.firestore, "records");
    const q = query(col, where('nivel', '==', nivel), orderBy('tiempo', 'asc'), limit(5));
  
    return new Observable((observer) => {
      const unsubscribe = onSnapshot(q, (querySnapshot) => {
        const registros = querySnapshot.docs.map((doc) => {
          const data = doc.data();
          return {
            id: data['id'],
            nivel: data['nivel'],
            tiempo: data['tiempo'],
            fecha: data['fecha'],
            usuario: data['usuario'],
          };
        });
        observer.next(registros);
      });
      
      return () => {
        unsubscribe();
      };
    });
  }
}
