import { Component, OnInit } from '@angular/core';
import { ListadoService } from 'src/app/services/listado/listado.service';
import { Camera, CameraResultType, CameraSource, Photo } from '@capacitor/camera';
import { FirebaseService } from 'src/app/services/firebase/firebase.service';

@Component({
  selector: 'app-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss'],
})
export class CameraComponent  implements OnInit {
  public esFotoFea :boolean;

  constructor(private firebase :FirebaseService, private listadoService :ListadoService) {
    this.esFotoFea = listadoService.Tipo_feas;
  }

  ngOnInit() {}

  public async TomarFoto() {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Uri,
      source: CameraSource.Camera,
      quality: 100,
    });
    const listado = this.esFotoFea ? 'fotosFeas' : 'fotosLindas';
    const ruta = capturedPhoto.webPath;
    this.firebase.Guardar(listado, ruta);
  }

}
