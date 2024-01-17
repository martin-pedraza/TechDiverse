import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { Usuarios } from 'src/app/models/usuarios';
import { AccesoService } from 'src/app/services/acceso.service';
import { PedidoService } from 'src/app/services/pedido.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pedir-cuenta',
  templateUrl: './pedir-cuenta.page.html',
  styleUrls: ['./pedir-cuenta.page.scss'],
})
export class PedirCuentaPage implements OnInit {

  usuario: Usuarios;
  pedido: any;
  showSpinner = false;
  propina = 0;
  satisfaccion= "";

  constructor(public accesoService: AccesoService, 
              public pedidoService: PedidoService,
              private navCtrl: NavController,
              public usuarioService: UsuariosService) { 
    
  }
  
  ngOnInit() {
    this.usuario = this.accesoService.usuarioLogueado;
    console.log("USUARIO LOGGEADO",this.usuario);

    this.pedidoService
    .traerPedidoUsuario(this.usuario)
    .subscribe((pedidos) => {
      this.pedido = pedidos[0].payload.doc.data();
      this.propina = ((this.pedido.propina * this.pedido.total)/100);
      this.satisfaccion = (this.pedido.propina === 20) ? "Excelente" :
                          (this.pedido.propina === 15) ? "Muy Bueno" :
                          (this.pedido.propina === 10) ? "Bueno" :
                          (this.pedido.propina === 5) ? "Regular" :
                          "Malo";
      console.log("ESTE ES EL PEDIDO",this.pedido);
    });
  }


  calcularTotal() {
    return this.pedido.total - this.propina ;
  }

  realizarPago() {
    this.usuarioService.cambiarEstadoPedido("pago-pendiente-verificacion",this.pedido.id);
    this.usuarioService.cambiarEstadoUsuarioSimple(this.usuario.email,"pago-pendiente-verificacion");
    
    Swal.fire({
      title: 'Abonado correctamente!',
      text: '🕔 Aguarda un momento que el mozo valide el pago.',
      icon: 'success',
      timer: 4000,
      heightAuto: false,
    });
    setTimeout(() => {
      this.showSpinner = false;
      this.navCtrl.navigateRoot(['/mesa']);
    }, 2000);
    
  }
}
