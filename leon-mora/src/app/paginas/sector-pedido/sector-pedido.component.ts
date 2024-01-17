import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FILE } from 'dns';
import { AccesoService } from 'src/app/services/acceso.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import { UsuariosService } from 'src/app/services/usuarios.service';

@Component({
  selector: 'app-sector-pedido',
  templateUrl: './sector-pedido.component.html',
  styleUrls: ['./sector-pedido.component.scss'],
})
export class SectorPedidoComponent implements OnInit {
  cocinaList: any[] = [];
  barList: any[] = [];
  pedidosList: any[] = [];

  horaActual:Date = new Date();

  tokenMozos: string[];
  tokenMetres: string[];
  tipoUsuario:string;

  constructor(private pushNotification : PushNotificationsService,private accesoService: AccesoService, private router: Router, private usuarioService:UsuariosService) 
  {
  }

  ngOnInit() 
  {
    setTimeout(() => {
      console.log(this.accesoService.usuarioLogueado)
      if(this.accesoService.usuarioLogueado)
      {
        console.log(this.accesoService.usuarioLogueado);
        if(this.accesoService.usuarioLogueado.tipo == 'cocinero')
        {
          this.tipoUsuario = 'comida';
        }else if(this.accesoService.usuarioLogueado.tipo == 'bartender')
        {
          this.tipoUsuario = 'bebida';
        }

        this.usuarioService.obtenerPedidos().subscribe((pedidos:any) => {
          this.pedidosList = [];
          pedidos.forEach((ped:any) => {
            if(ped.estado == 'aprobado')
            {
              let flag = false;
              ped.lista.forEach((prod:any)=>{
                if(prod.tipo == this.tipoUsuario && !flag)
                {
                  this.pedidosList.push(ped);
                  flag = true;
                }
              });
            }
          });
          console.log(this.pedidosList);
        });
      }
    }, 1000);
      

    this.usuarioService.traerMozos().subscribe((mozos: any) => {
      this.tokenMozos = [];
      mozos.forEach((m: any) => {
        if (m.token != '') {
          this.tokenMozos.push(m.token);
        }
      });
    });

    this.usuarioService.trarMetres().subscribe((metres: any) => {
      this.tokenMetres = [];
      metres.forEach((m: any) => {
        if (m.token != '') {
          this.tokenMetres.push(m.token);
        }
      });
    });

  }

  cerrarSesion() {
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }

  pedidoListo(pedido:any){
    pedido.lista.forEach((producto:any) => {
      if(producto.tipo == this.tipoUsuario)
      {
        producto.tipo = 'preparado';
      }
    });
    this.usuarioService.cambiarEstadoProductos(pedido);
    if(pedido.lista.every((producto:any) => producto.tipo === 'preparado'))
    {
      this.usuarioService.cambiarEstadoPedido('para-entregar',pedido.id);
      this.sendPush(pedido);
    }

  }
  

  sendPush(pedido: any) {
    console.log(this.tokenMozos);
    // Enviar notificacion solamente a los dueños, sin hardcodear
    this.pushNotification
      .sendPushNotification({
        registration_ids: this.tokenMozos,
        notification: {
          image:
            'https://images.emojiterra.com/google/android-12l/512px/1f372.png',
          title: 'El pedido ya esta listo para entregar! ✅🆗',
          body: 'Mesa: ' + pedido.mesa + ' \nCliente: ' + pedido.clienteNombre,
        },
        data: {
          id: 1,
          nombre: 'Test',
        },
      })
      .subscribe((data) => {
        console.log(data);
      });
  }
}
