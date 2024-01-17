import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-accesos-rapidos',
  templateUrl: './accesos-rapidos.page.html',
  styleUrls: ['./accesos-rapidos.page.scss'],
})
export class AccesosRapidosPage implements OnInit {

  perfil: string;
  showSpinner: boolean;
  
  constructor(public navCtrl: NavController) { }

  ngOnInit() {
  }

  seleccionarPerfil(tipo: string){

    switch (tipo) {
      case 'cliente':
          this.showSpinner = true;
          setTimeout(() => {
            this.showSpinner = false;
            this.navCtrl.navigateRoot(['/alta-clientes']);
          }, 2000);
        break;
      case 'duenio':
          this.showSpinner = true;
          setTimeout(() => {
            this.showSpinner = false;
            this.navCtrl.navigateRoot(['/duenio-panel']);
          }, 2000);
        break;
      default:
        this.perfil = tipo;
    }
  }

}
