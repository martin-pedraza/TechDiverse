import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccesoService } from 'src/app/services/acceso.service';
import { ChatService } from 'src/app/services/chat.service';
import { MesaService } from 'src/app/services/mesa.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import { PedidoService } from 'src/app/services/pedido.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-mozo-panel',
  templateUrl: './mozo-panel.page.html',
  styleUrls: ['./mozo-panel.page.scss'],
})
export class MozoPanelPage implements OnInit, OnDestroy {
  @ViewChild('content', { static: false }) content: ElementRef;
  showSpinner = false;
  sala = '';
  mensaje: string = '';
  elemento: any;
  usuario: any;
  mesaObj: any;
  mesaLista: any[] = [];
  mesaListaSuscripcion: Subscription | undefined;
  pedidoLista: any[] = [];
  pedidoListaSuscripcion: Subscription | undefined;
  entregaLista: any[] = [];
  pagoLista: any[] = [];
  opcionMenu: string = 'menu';
  tokenCocina: any[] = [];

  constructor(
    public accesoService: AccesoService,
    public chatService: ChatService,
    private router: Router,
    private mesaService: MesaService,
    private pedidoService: PedidoService,
    private usuariosService: UsuariosService,
    private pushNotification: PushNotificationsService
  ) {}

  ngOnDestroy(): void {
    this.mesaListaSuscripcion?.unsubscribe();
    this.pedidoListaSuscripcion?.unsubscribe();
  }

  ngOnInit() {
    this.usuario = this.accesoService.usuarioLogueado;

    this.mesaListaSuscripcion = this.mesaService
      .traerMesas()
      .subscribe((lista) => {
        this.mesaLista = lista;
        this.mesaObj = {};
        lista.forEach((element: any) => {
          this.mesaObj[element.numero] = element.numero;
        });
      });

    this.pedidoListaSuscripcion = this.pedidoService
      .traerPedidos()
      .subscribe((lista) => {
        this.pedidoLista = [];
        this.entregaLista = [];
        this.pagoLista = [];
        for (let index = 0; index < lista.length; index++) {
          const element: any = lista[index];
          if (element['estado'] == 'pendiente-aprobacion') {
            this.pedidoLista.push(element);
          }

          if (element['estado'] == 'para-entregar') {
            this.entregaLista.push(element);
          }

          if (element['estado'] == 'pago-pendiente-verificacion') {
            this.pagoLista.push(element);
          }
        }
      });

    this.usuariosService.traerCocina().subscribe((cocina: any) => {
      this.tokenCocina = [];
      cocina.forEach((c: any) => {
        if (c.token != '') {
          this.tokenCocina.push(c.token);
        }
      });
    });
  }

  sendPush(pedido: any) {
    this.pushNotification
      .sendPushNotification({
        registration_ids: this.tokenCocina,
        notification: {
          image:
            'https://images.emojiterra.com/google/android-12l/512px/1f372.png',
          title: 'El pedido ya fue aprobado! ✅🆗',
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

  cambiarOpcionMenu(opcion: string) {
    this.opcionMenu = opcion;
  }

  aprobarPedido(estaAprobado: boolean, pedido: any, idCliente: string) {
    const estado = estaAprobado ? 'aprobado' : 'sin-pedido';
    this.pedidoService.actualizarPedido(pedido.id, { estado: estado });
    this.usuariosService.actualizarUsuario(idCliente, {
      pedidoActualEstado: estado,
    });
    if (estaAprobado) {
      this.sendPush(pedido);
    }
  }

  entregarPedido(idPedido: string, idCliente: string) {
    this.pedidoService.actualizarPedido(idPedido, { estado: 'entregado' });
    this.usuariosService.actualizarUsuario(idCliente, {
      pedidoActualEstado: 'entregado',
    });
  }

  pagarPedido(idPedido: string, idCliente: string, mesa: string) {
    this.pedidoService.actualizarPedido(idPedido, { estado: 'cerrado' });

    this.usuariosService.actualizarUsuario(idCliente, {
      estado: 'activo',
      mesa: '',
      pedidoActualEstado: 'sin-pedido',
      pedidoActualId: '',
      encuesta: false,
    });

    this.chatService.eliminarMensajes('Chat_Mesa' + mesa);

    for (let index = 0; index < this.mesaLista.length; index++) {
      const element = this.mesaLista[index];
      if (element['numero'] == mesa) {
        this.mesaService.actualizarMesa(element['id'], {
          estado: 'activo',
          cliente: '',
        });
        break;
      }
    }
  }

  seleccionarChat() {
    Swal.fire({
      title: 'Seleccione una mesa',
      input: 'select',
      inputOptions: this.mesaObj,
      heightAuto: false,
      confirmButtonText: 'Ver Chat',
    }).then((result) => {
      if (result.isConfirmed) {
        console.log('You selected: ' + result.value);
        this.abrirChat(result.value);
      }
    });
  }

  abrirChat(mesa: string) {
    this.showSpinner = true;
    setTimeout(() => {
      this.elemento = document.getElementById('chat-mensajes');
      this.chatService.cargarMensajes('Chat_Mesa' + mesa).subscribe(() => {
        setTimeout(() => {
          this.scrollChatToBottom();
        }, 5);
      });
      this.opcionMenu = 'chat';
      this.showSpinner = false;
    }, 2000);
  }

  ngAfterViewInit(): void {
    if (this.content) {
      this.content.nativeElement.scrollTop =
        this.content.nativeElement.scrollHeight;
    }
  }

  scrollChatToBottom() {
    if (this.content) {
      this.content.nativeElement.scrollTop =
        this.content.nativeElement.scrollHeight;
    }
  }

  enviarMensaje() {
    this.chatService.agregarMensaje(
      this.mensaje,
      this.accesoService.usuarioLogueado.nombre +
        ' ' +
        this.accesoService.usuarioLogueado.apellido,
      this.accesoService.usuarioLogueado.email
    );
    this.mensaje = '';
    setTimeout(() => {
      this.scrollChatToBottom();
    }, 500);
  }

  cargarSala(sala: string) {
    this.sala = sala;
    this.chatService.cargarMensajes(sala).subscribe(() => {
      setTimeout(() => {
        this.scrollChatToBottom();
      }, 20);
    });
    this.opcionMenu = 'chat';
    this.showSpinner = true;
    setTimeout(() => {
      this.showSpinner = false;
    }, 2000);
  }

  cerrarSesion() {
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }
}
