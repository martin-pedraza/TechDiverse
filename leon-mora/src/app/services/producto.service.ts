import { Injectable } from '@angular/core';
import { Producto } from '../models/producto';
import { FirebaseService } from './firebase.service';
import Swal from 'sweetalert2';
import { getDownloadURL, getStorage, ref, uploadBytes } from 'firebase/storage';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  constructor(private firebase: FirebaseService) {}

  async agregarProducto(producto: Producto) {
    try {
      await this.firebase.agregarRegistro(producto, 'productos');
      Swal.fire({
        title: 'Producto creada con exito!',
        icon: 'success',
        heightAuto: false,
      });
    } catch (error) {
      Swal.fire({
        title: 'Error al crear producto.',
        icon: 'error',
        heightAuto: false,
      });
    }
  }

  async uploadImage(image: any, name: string): Promise<string> {
    const storage = getStorage();
    const storageRef = ref(storage, name);
    const snapshot = await uploadBytes(storageRef, image);
    const downloadURL = await getDownloadURL(snapshot.ref);
    return downloadURL;
  }

  traerProductos() {
    return this.firebase.traerTabla('productos');
  }
}
