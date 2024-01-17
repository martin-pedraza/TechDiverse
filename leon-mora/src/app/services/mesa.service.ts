import { Injectable } from '@angular/core';
import { Mesa } from '../models/mesa';
import { FirebaseService } from './firebase.service';
import Swal from 'sweetalert2';
import { getDownloadURL, getStorage, ref, uploadBytes } from 'firebase/storage';

@Injectable({
  providedIn: 'root',
})
export class MesaService {
  constructor(public firebase: FirebaseService) {}

  async agregarMesa(mesa: Mesa) {
    try {
      await this.firebase.agregarRegistro(mesa, 'mesas');
      Swal.fire({
        title: 'Mesa creada con exito!',
        icon: 'success',
        heightAuto: false,
      });
    } catch (error) {
      Swal.fire({
        title: 'Error al crear mesa.',
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

  traerMesas() {
    return this.firebase.traerTabla('mesas');
  }

  actualizarMesa(idMesa: string, data: any) {
    return this.firebase.actualizarDocumento(idMesa, 'mesas', data);
  }
}
