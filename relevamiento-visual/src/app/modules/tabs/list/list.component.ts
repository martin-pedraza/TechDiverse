import { Component, OnDestroy, OnInit } from '@angular/core';
import { Firestore, collectionData } from '@angular/fire/firestore';
import { collection, orderBy, query } from 'firebase/firestore';
import { Subscription } from 'rxjs';
import { FirebaseService } from 'src/app/services/firebase/firebase.service';
import { ListadoService } from 'src/app/services/listado/listado.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss'],
})
export class ListComponent implements OnInit, OnDestroy {
  public esFotoFea: boolean = true;
  public fotos: any[] | undefined = [];
  subscripcion: Subscription | undefined;
  subscripcion2: Subscription | undefined;

  constructor(
    private listadoService: ListadoService,
    private firestore: Firestore,
    private firebaseService: FirebaseService
  ) {}

  ngOnInit() {
    this.esFotoFea = this.listadoService.Tipo_feas;

    const col = collection(this.firestore, 'fotosFeas');
    const q = query(col, orderBy('segundo', 'desc'));
    const observable = collectionData(q);
    this.subscripcion = observable.subscribe((respuesta) => {
      this.listadoService.fotosFeas = respuesta;
      if (this.esFotoFea) {
        this.fotos = respuesta;
      }
    });

    const col2 = collection(this.firestore, 'fotosLindas');
    const q2 = query(col2, orderBy('segundo', 'desc'));
    const observable2 = collectionData(q2);
    this.subscripcion2 = observable2.subscribe((respuesta) => {
      this.listadoService.fotosLindas = respuesta;
      if (!this.esFotoFea) {
        this.fotos = respuesta;
      }
    });
  }

  public Gustar(id: string) {
    this.firebaseService.Actualizar(
      this.esFotoFea ? 'fotosFeas' : 'fotosLindas',
      id
    );
  }

  public VerificarListado(usuarios: any[]) {
    return usuarios.includes(localStorage.getItem('creador'));
  }

  ngOnDestroy(): void {
    this.subscripcion?.unsubscribe();
    this.subscripcion2?.unsubscribe();
  }
}
