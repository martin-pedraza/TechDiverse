import { Injectable } from '@angular/core';
import { FirebaseService } from './firebase.service';
import { Usuarios } from '../models/usuarios';
import Swal from 'sweetalert2';
import { getDownloadURL, getStorage, ref, uploadBytes } from 'firebase/storage';
import {
  AngularFirestore,
  AngularFirestoreDocument,
} from '@angular/fire/compat/firestore';
import { map, take, takeUntil } from 'rxjs/operators';
import { EmailService } from './email.service';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';
import { Subject, Subscription } from 'rxjs';
import { AccesoService } from './acceso.service';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  usuarioDoc!: AngularFirestoreDocument<Usuarios>;

  constructor(
    public firebase: FirebaseService,
    public firestore: AngularFirestore,
    private emailService: EmailService,
    private auth: AngularFireAuth,
    private router: Router
      ) {}

  async agregarUsuario(usuario: Usuarios, mensaje: string) {
    try {
      await this.firebase.agregarRegistro(usuario, 'usuarios');
      Swal.fire({
        title: mensaje,
        icon: 'success',
        heightAuto: false,
      });
    } catch (error) {
      Swal.fire({
        title: 'Error al crear registro',
        icon: 'error',
        heightAuto: false,
      });
    }
  }

  async agregarEmpleado(empleado: Usuarios) {
    try {
      await this.firebase.agregarRegistro(empleado, 'usuarios');
      Swal.fire({
        title: 'Empleado creado con exito!',
        icon: 'success',
        heightAuto: false,
      });
    } catch (error) {
      Swal.fire({
        title: 'Error al crear registro',
        icon: 'error',
        heightAuto: false,
      });
    }
  }

  async agregarCliente(cliente: Usuarios, mensaje: string) {
    try {
      await this.auth
        .createUserWithEmailAndPassword(cliente.email!, cliente.clave!)
        .then(async (cred) => {
          cliente.id = cred.user?.uid;
          await this.firestore
            .collection('usuarios')
            .doc(cred.user?.uid)
            .set(cliente);
        });
      this.auth.signOut();
      Swal.fire({
        title: mensaje,
        icon: 'success',
        heightAuto: false,
      });
    } catch (err) {
      console.log('error al registrar: ', err);
    }
  }

  agregarPedido(pedido: any) {
    return this.firebase.agregarRegistro(pedido, 'pedidos');
  }

  async uploadImage(image: any, name: string): Promise<string> {
    const storage = getStorage();
    const storageRef = ref(storage, name);
    const snapshot = await uploadBytes(storageRef, image);
    const downloadURL = await getDownloadURL(snapshot.ref);
    return downloadURL;
  }

  async obtenerClientesPendientes(estado: string) {
    try {
      return this.firestore
        .collection('usuarios', (ref) => ref.where('estado', '==', estado))
        .snapshotChanges()
        .pipe(
          map((actions) => {
            return actions.map((a) => {
              const data = a.payload.doc.data();
              const id = a.payload.doc.id;
              return Object.assign({}, data, { id });
            });
          })
        );
    } catch (error) {
      console.error(
        'Error al obtener las cosas usuarios pendientes confirmacion:',
        error
      );
      throw error;
    }
  }

  cambiarEstadoUsuario(
    dni: string,
    nombre: string,
    apellido: string,
    estado: string,
    email: string
  ) {
    const usuarioCollection = this.firestore.collection('usuarios', (ref) => {
      return ref.where('dni', '==', dni).where('apellido', '==', apellido);
    });

    usuarioCollection.get().subscribe((querySnapshot) => {
      querySnapshot.docs.forEach((doc) => {
        doc.ref.update({ estado: estado });
      });
    });

    let nombreYapellido = nombre + ' ' + apellido;
    if (estado == 'activo') {
      this.emailService.sendEmail(nombreYapellido, email, true);
    } else if (estado == 'rechazado') {
      this.emailService.sendEmail(nombreYapellido, email, false);
    } else {
    }
  }

  cambiarEstadoUsuarioSimple(email: any, estado: string) {
    const usuarioCollection = this.firestore.collection('usuarios', (ref) => {
      return ref.where('email', '==', email);
    });

    usuarioCollection.get().subscribe((querySnapshot) => {
      querySnapshot.docs.forEach((doc) => {
        doc.ref.update({ estado: estado });
      });
    });
  }

  traerMozos() {
    const coleccion = this.firestore.collection('usuarios', (ref) =>
      ref.where('tipo', 'in', ['mozo'])
    );
    return coleccion.valueChanges();
  }

  trarMetres() {
    const coleccion = this.firestore.collection('usuarios', (ref) =>
      ref.where('tipo', 'in', ['metre'])
    );
    return coleccion.valueChanges();
  }

  traerCocina() {
    const coleccion = this.firestore.collection('usuarios', (ref) =>
      ref.where('tipo', 'in', ['bartender', 'cocinero'])
    );
    return coleccion.valueChanges();
  }

  traerSupervisores() {
    const coleccion = this.firestore.collection('usuarios', (ref) =>
      ref.where('tipo', 'in', ['supervisor', 'duenio'])
    );
    return coleccion.valueChanges();
  }

  traerUsuarios() {
    return this.firebase.traerTabla('usuarios');
  }

  actualizarUsuario(id: string, data: any) {
    return this.firebase.actualizarDocumento(id, 'usuarios', data);
  }

  async obtenerClientesPorEstado(estado: string) {
    try {
      return this.firestore
        .collection('usuarios', (ref) =>
          ref.where('estado', '==', estado).where('tipo', '==', 'cliente')
        )
        .snapshotChanges()
        .pipe(
          map((actions) => {
            return actions.map((a) => {
              const data = a.payload.doc.data();
              const id = a.payload.doc.id;
              return Object.assign({}, data, { id });
            });
          })
        );
    } catch (error) {
      throw error;
    }
  }

  guardarToken(email: any, token: any) {
    // Primero, realiza una consulta para buscar al usuario por su correo electrónico
    console.log('Tratando de guardar el token', email, token);
    this.firestore
      .collection('usuarios', (ref) => ref.where('email', '==', email))
      .valueChanges()
      .pipe(take(1))
      .subscribe((data: any) => {
        if (data.length > 0) {
          // Se encontró un usuario con el correo electrónico especificado
          console.info('CONSOLE.INFO: ', data);
          console.info('JSON: ', JSON.stringify(data));
          const usuarioId = data[0].id;
          console.log('id: ', usuarioId);
          console.log(usuarioId);
          console.log(typeof usuarioId);

          // Actualiza el campo "pushToken" del usuario
          this.firestore
            .collection('usuarios')
            .doc(usuarioId)
            .update({ token: token });
        } else {
          console.log(
            `No se encontró un usuario con el correo electrónico ${email}`
          );
        }
      });
  }

  async obtenerEncuestas() {
    try {
      return this.firestore
        .collection('encuestas')
        .snapshotChanges()
        .pipe(
          map((actions) => {
            return actions.map((a) => {
              const data = a.payload.doc.data();
              const id = a.payload.doc.id;
              return Object.assign({}, data, { id });
            });
          })
        );
    } catch (error) {
      throw error;
    }
  }

  //para COMPONENTE QR mesa

  irAMesaCuandoCambieDeEstado() {
    const destroy$: Subject<void> = new Subject<void>();
    return this.auth.authState.subscribe((usuarioActual) => {
      if (!usuarioActual) {
        return;
      } else {
        this.firestore
        .collection('usuarios')
        .doc(usuarioActual?.uid)
        .valueChanges()
        .pipe(takeUntil(this.destroy$))
        .subscribe((CambioDetectado) => {
            console.log('funcion: IrAMesaCuandoCambieDeEstado');
            console.log(CambioDetectado)
            let usuario = CambioDetectado as any
            if (usuario.estado === 'con mesa') {
              //revisar estado
              this.destroy$.next(); 
              this.destroy$.complete();
              this.router.navigate(['/mesa']);
              return;
            }
            if (usuario.estado == 'en-espera') {
              this.router.navigate(['/sala-espera-cliente']);
            }
            if (usuario.estado == 'activo') {
              this.router.navigate(['/home']);
            }
          });
      }
    });
  }

  private destroy$: Subject<void> = new Subject<void>();

  esperandoConfirmacionDePedido(idPedido: string): any {
    const estadoPedidoSubject = new Subject<string>();

    this.firestore
      .collection('pedidos')
      .doc(idPedido)
      .snapshotChanges()
      .pipe(takeUntil(this.destroy$))
      .subscribe((docRef) => {
        let pedido = docRef.payload.data() as any;

        if (pedido.estado == 'aprobado') {
          Swal.fire({
            title: 'Aprobado!',
            text: 'Su pedido ha sido Aprobado por el mozo',
            icon: 'success',
            timer: 4000,
            heightAuto: false,
          });
        }

        if (pedido.estado == 'pedido-entregado') {
          this.destroy$.next(); // Desuscribirse cuando el estado es 'entregado-confirmado'
          this.destroy$.complete();
        }

        estadoPedidoSubject.next(pedido.estado);
      });

    return estadoPedidoSubject.asObservable();
  }

  cambiarEstadoPedido(nuevoEstado: string, idPedido: string) {
    try {
      this.firestore
        .collection('pedidos')
        .doc(idPedido)
        .update({ estado: nuevoEstado });
    } catch (err) {
      console.log(err);
    }
  }

  cambiarEstadoProductos(pedido: any) {
    try {
      this.firestore
        .collection('pedidos')
        .doc(pedido.id)
        .update({ lista: pedido.lista });
    } catch (err) {
      console.log(err);
    }
  }

  // cambiarEstadoProducto( idPedido: string){
  //   try {
  //     this.firestore
  //       .collection('pedidos')
  //       .doc(idPedido)
  //       .update();
  //   } catch (err) {
  //     console.log(err);
  //   }
  // }

  agregarPropina(
    mesa: string,
    clienteNombre: string,
    estadoPedido: string,
    propina: number
  ) {
    let pedidosCollection = this.firestore.collection('pedidos', (ref) => {
      return ref
        .where('mesa', '==', mesa)
        .where('clienteNombre', '==', clienteNombre)
        .where('estado', '==', estadoPedido);
    });

    pedidosCollection.get().subscribe((querySnapshot) => {
      if (querySnapshot.size == 0) {
        // Mostrar SweetAlert indicando que no se encontraron registros
        Swal.fire({
          icon: 'info',
          title: 'No se encontraron registros',
          text: 'Recorda que solo podes dar propina cuando te entreguen el pedido y completes la encuesta',
          heightAuto: false,
        });
        return;
      }

      querySnapshot.docs.forEach((doc) => {
        doc.ref
          .update({ propina: propina })
          .then(() => {
            console.log('Salio bien el update');
            Swal.fire({
              icon: 'success',
              title: 'Propina agregada exitosamente',
              showConfirmButton: false,
              heightAuto: false,
              timer: 1500,
            });
          })
          .catch((error) => {
            console.log('Error al updatear propina', error);
            Swal.fire({
              icon: 'error',
              title: 'Error al agregar propina',
              text: error.message,
              heightAuto: false,
            });
          });
      });
    });
  }

  subirResenia(formulario: any) {
    try {
      this.firestore.collection('encuestas').add(formulario);
    } catch (err) {
      console.log(err);
    }
  }

  obtenerPedidos() {
    return this.firestore.collection('pedidos').valueChanges();
  }

  obtenerUsuario(uid:string)
  {
    try{
      return this.firestore.collection('usuarios').doc(uid).valueChanges()
    }
    catch(err)
    {
      console.log(err);
      return null;
    }
  }
}
