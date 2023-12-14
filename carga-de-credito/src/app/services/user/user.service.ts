import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { Auth, signInWithEmailAndPassword, signOut } from '@angular/fire/auth';
import {
  Firestore,
  collection,
  doc,
  getDoc,
  getDocs,
  query,
  updateDoc,
  where,
} from '@angular/fire/firestore';
import { collectionData } from 'rxfire/firestore';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService implements OnInit, OnDestroy {
  public usuarios: any[] | undefined;
  suscripcionUsuarios: Subscription | undefined;
  credito :number = 0;
  private creditoSubject: BehaviorSubject<number> = new BehaviorSubject<number>(
    0
  );
  public creditoObservable: Observable<number> =
    this.creditoSubject.asObservable();

  constructor(private auth: Auth, private firestore: Firestore) {}

  ngOnDestroy(): void {
    this.suscripcionUsuarios?.unsubscribe();
  }

  ngOnInit(): void {
    this.TraerCreditos();
  }

  public IniciarSesion(usuario: string, clave: string) {
    return signInWithEmailAndPassword(this.auth, usuario, clave);
  }

  public CerrarSesion() {
    return signOut(this.auth);
  }

  public TraerCreditos() {
    const col = collection(this.firestore, 'usuarios');
    const q = query(
      col,
      where('correo', '==', localStorage.getItem('usuario'))
    );

    getDocs(q).then((querySnapshot) => {
      querySnapshot.forEach((doc) => {
        const usuario = doc.data();
        this.credito = usuario ? usuario['credito'] : 0;
        this.creditoSubject.next(this.credito);
      });
    });
  }

  public TraerUsuarios() {
    const col = collection(this.firestore, 'usuarios');
    const observable = collectionData(col);

    this.suscripcionUsuarios = observable.subscribe((response) => {
      this.usuarios = response;
    });
  }

  public async ActualizarRegistro(codigo: number) {
    const index = this.usuarios?.findIndex(
      (obj) => obj.correo == localStorage.getItem('usuario')
    );

    if (this.usuarios != undefined && index != -1 && index != undefined) {
      const id = this.usuarios[index].id;

      const col = collection(this.firestore, 'usuarios');
      const documento = doc(col, id);
      const docSnap = await getDoc(documento);
      if (docSnap.exists()) {
        const data = docSnap.data();

        let creditoTotal = data['credito'];
        let Total10 = data['10'];
        let Total50 = data['50'];
        let Total100 = data['100'];

        switch (codigo) {
          case 10:
            Total10++;
            creditoTotal += 10;
            break;
          case 50:
            Total50++;
            creditoTotal += 50;
            break;
          case 100:
            Total100++;
            creditoTotal += 100;
            break;
          default:
            creditoTotal = 0;
            Total10 = 0;
            Total50 = 0;
            Total100 = 0;
        }

        await updateDoc(documento, {
          credito: creditoTotal,
          10: Total10,
          50: Total50,
          100: Total100,
        });

        this.creditoSubject.next(creditoTotal); // Actualizar el BehaviorSubject
      }
    }
  }
}
