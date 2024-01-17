import {
  Component,
  ElementRef,
  Input,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { AccesoService } from 'src/app/services/acceso.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';
import { BarcodeFormat } from '@zxing/library';
import { ChatService } from 'src/app/services/chat.service';
import { PushNotificationsService } from 'src/app/services/notificacion.service';
import { Router } from '@angular/router';
import { ProductoService } from 'src/app/services/producto.service';
import { Subscription, interval } from 'rxjs';
import { PedidoService } from 'src/app/services/pedido.service';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-mesa',
  templateUrl: './mesa.page.html',
  styleUrls: ['./mesa.page.scss'],
})
export class MesaPage implements OnInit, OnDestroy {
  allowedFormats = [BarcodeFormat.QR_CODE];
  mostrarScanner: boolean = false;
  valorScanneado = '';
  showSpinner = false;
  isModalOpen: boolean = false;
  @Input() estadoPedido: any = 'sin-pedido';
  pedido: any = null;
  total: number = 0;
  tiempo: number = 0;
  @ViewChild('content', { static: false }) content: ElementRef;
  mensaje: string = '';
  elemento: any;
  usuario: any;
  sala = '';
  showChat = false;
  usuarioSuscripcion: Subscription | undefined;
  productoSuscripcion: Subscription | undefined;
  productos: any[] = [];
  tokenMozos: string[] = [];
  productosPedido: any[] = [];
  pedidoActualSuscripcion: Subscription | undefined;
  private intervalSubscription: Subscription | undefined;

  constructor(
    public accesoService: AccesoService,
    private usuarioService: UsuariosService,
    public chatService: ChatService,
    private pushNotification: PushNotificationsService,
    public router: Router,
    private productoService: ProductoService,
    private modalController: ModalController,
    private pedidoService: PedidoService
  ) {}

  ngOnDestroy(): void {
    this.productoSuscripcion?.unsubscribe();
    this.usuarioSuscripcion?.unsubscribe();
    this.pedidoActualSuscripcion?.unsubscribe();
  }

  ngOnInit() {
    if (this.accesoService.usuarioLogueado.pedidoActualId == '') {
      this.usuario = this.accesoService.usuarioLogueado;

      this.pedido = {
        lista: [],
        mesa: this.usuario.mesa,
        clienteId: this.usuario.id,
        clienteNombre: this.usuario.nombre + ' ' + this.usuario.apellido,
        estado: 'pendiente-aprobacion',
        total: this.total,
        tiempo: this.tiempo,
        propina: 0,
      };
    }

    this.productoSuscripcion = this.usuarioService
      .traerMozos()
      .subscribe((mozos: any) => {
        this.tokenMozos = [];
        mozos.forEach((mozo: any) => {
          if (mozo.token != '') {
            this.tokenMozos.push(mozo.token);
          }
        });
      });

    this.productoSuscripcion = this.productoService
      .traerProductos()
      .subscribe((lista) => {
        this.productos = lista;
      });

    this.elemento = document.getElementById('chat-mensajes');
    this.chatService
      .cargarMensajes('Chat_Mesa' + this.accesoService.usuarioLogueado.mesa)
      .subscribe(() => {
        setTimeout(() => {
          this.scrollChatToBottom();
        }, 5);
      });

    this.trampa();
  }

  trampa() {
    this.intervalSubscription = interval(3000).subscribe(() => {
      if (this.accesoService.usuarioLogueado) {
        this.usuario = this.accesoService.usuarioLogueado;

        if (this.accesoService.usuarioLogueado.estado == 'activo') {
          this.router.navigateByUrl('/home');
          this.stopInterval();
        }

        if (this.accesoService.usuarioLogueado.pedidoActualId != '') {
          if (!this.pedido) {
            this.pedidoActualSuscripcion = this.pedidoService
              .traerPedido(this.usuario.pedidoActualId)
              .subscribe((p) => {
                if (p) {
                  this.pedido = p[0];
                  this.productosPedido = this.pedido['lista'];
                  this.calcularTotal(this.productosPedido);
                }
                if (this.pedido) {
                  this.pedidoActualSuscripcion?.unsubscribe();
                }
              });
          }
        }
      }
    });
  }
  private stopInterval() {
    if (this.intervalSubscription) {
      this.intervalSubscription.unsubscribe();
    }
  }

  scanSuccessHandler($event: any) {
    this.mostrarScanner = false;
    this.estadoPedido = this.usuario.pedidoActualEstado;

    if (typeof $event == 'string') {
      this.valorScanneado = $event;
      if (this.usuario.estado == 'con mesa' && this.usuario.tipo == 'cliente') {
        if (this.valorScanneado == this.usuario.mesa) {
          switch (this.estadoPedido) {
            case 'pendiente-aprobacion':
              Swal.fire({
                title: 'Pendiente de aprobacion!',
                text: 'El mozo debe aprobar su pedido',
                icon: 'info',
                heightAuto: false,
              });
              break;
            // case 'sin-pedido':
            // case 'aprobado':
            // case 'para-entregar':
            // case 'entregado':
            // case 'pedido-entregado':
            // case 'pago-pendiente-verificacion':
            // case 'cerrado':
            default:
              this.setOpenModal(true);
              break;
          }
        } else {
          switch (this.valorScanneado) {
            case 'Propina-Excelente':
              this.agregarPropina(20);
              break;
            case 'Propina-MuyBueno':
              this.agregarPropina(15);
              break;
            case 'Propina-Bueno':
              this.agregarPropina(10);
              break;
            case 'Propina-Regular':
              this.agregarPropina(5);
              break;
            case 'Propina-Malo':
              this.agregarPropina(0);
              break;
            default:
              Swal.fire({
                title: 'Código QR invalido!',
                icon: 'error',
                heightAuto: false,
              });
              break;
          }
        }
      } else {
        Swal.fire({
          title: 'Código QR invalido!',
          text: 'No puedes abrir el Menu sin tener una mesa asignada',
          icon: 'error',
          heightAuto: false,
        });
        this.router.navigateByUrl('/home');
      }
    }
  }

  setOpenModal(estado: boolean) {
    this.isModalOpen = estado;
  }

  cambiarCantidad(producto: any, suma: boolean) {
    const index = this.pedido['lista'].findIndex((p) => p.id == producto.id);

    if (!suma && index == -1) {
      return;
    }

    if (suma && index == -1) {
      this.pedido['lista'].push(producto);
      this.pedido['lista'][this.pedido['lista'].length - 1].cantidad = 1;
    }

    if (index != -1) {
      if (suma) {
        this.pedido['lista'][index].cantidad++;
      }

      if (!suma && this.pedido['lista'][index].cantidad > 0) {
        this.pedido['lista'][index].cantidad--;
      }

      if (this.pedido['lista'][index].cantidad == 0) {
        this.pedido['lista'].splice(index, 1);
      }
    }

    this.calcularTotal(this.pedido['lista']);
  }

  calcularTotal(array: any) {
    this.total = 0;
    this.tiempo = 0;
    for (const prod of array) {
      this.total += prod.cantidad * prod.precio;
      if (parseInt(prod.tiempo) > this.tiempo) {
        this.tiempo = prod.tiempo;
      }
    }
    this.pedido.total = this.total;
    this.pedido.tiempo = this.tiempo;
  }

  confirmacionCierrePedido() {
    Swal.fire({
      title: 'Desea confirmar su pedido?',
      text: 'Una vez confirmado el mozo debe validar su pedido.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Confirmar',
      heightAuto: false,
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire({
          title: 'Confirmado!',
          text: 'Su pedido ha sido confirmado, en breves momentos el mozo lo validara',
          icon: 'success',
          timer: 4000,
          heightAuto: false,
        });

        this.usuarioService.agregarPedido(this.pedido).then((a) => {
          this.usuarioService.actualizarUsuario(this.usuario.id, {
            pedidoActualId: a,
            pedidoActualEstado: 'pendiente-aprobacion',
          });

          this.pushNotification
          .sendPushNotification({
            registration_ids: this.tokenMozos,
            notification: {
              image: 'https://freepngimg.com/thumb/chat/12-2-chat-png.png',
              title: 'Hay pedidos pendientes de aprobacion! 🌮🥟',
              body:
                'En la mesa número ' +
                this.usuario.mesa +
                ', el cliente ' +
                this.usuario.nombre +
                ' ' +
                this.usuario.apellido +
                ' ha hecho un pedido.',
            },
            data: {
              id: 1,
              nombre: 'Test',
            },
          })
          .subscribe((data) => {
            console.log(data);
          });
        });

        this.setOpenModal(false);
      }
    });
  }

  confirmarEntrega() {
    Swal.fire({
      title: 'Desea confirmar la entrega?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Confirmar',
      heightAuto: false,
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire({
          title: 'Entrega confirmada!',
          icon: 'success',
          timer: 2000,
          heightAuto: false,
        });

        this.usuarioService.cambiarEstadoPedido(
          'pedido-entregado',
          this.usuario.pedidoActualId
        );
        this.usuarioService.actualizarUsuario(this.usuario.id, {
          pedidoActualEstado: 'pedido-entregado',
        });

        this.estadoPedido = 'pedido-entregado';
      }
    });
  }

  // Funciones del chat

  abrirChat() {
    console.log(
      'Usuario loggeado que abrio el chat',
      this.accesoService.usuarioLogueado
    );
    console.log('Chat Mesa: ', this.accesoService.usuarioLogueado.mesa);

    this.showSpinner = true;
    setTimeout(() => {
      this.showChat = true;
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
    this.sendPushMozo(this.accesoService.usuarioLogueado);
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
    this.showChat = true;
    this.showSpinner = true;
    setTimeout(() => {
      this.showSpinner = false;
    }, 2000);
  }

  sendPushMozo(cliente: any) {
    console.log('------- \n  Por mandar notificacion al MOZO -------');
    console.log('TOKEN MOZOS: ', this.tokenMozos);

    // Enviar notificación solamente a los mozos
    this.pushNotification
      .sendPushNotification({
        registration_ids: this.tokenMozos,
        notification: {
          image: 'https://freepngimg.com/thumb/chat/12-2-chat-png.png',
          title: 'Hay clientes que te están hablando al chat! 🌮🥟',
          body:
            'En la mesa número ' +
            cliente.mesa +
            ', te está hablando el cliente ' +
            cliente.nombre +
            ' ' +
            cliente.apellido,
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

  cerrarSesion() {
    this.stopInterval();
    this.accesoService.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }

  agregarPropina(porcentaje: number) {
    let usuarioLoggeado = this.accesoService.usuarioLogueado;
    if (usuarioLoggeado && usuarioLoggeado.encuesta) {
      let nombreCliente =
        usuarioLoggeado.nombre + ' ' + usuarioLoggeado.apellido;
      console.log('Propina: ', porcentaje);
      console.log('Nombre Usuario Loggeado Propina: ', nombreCliente);
      this.usuarioService.agregarPropina(
        usuarioLoggeado.mesa,
        nombreCliente,
        'pedido-entregado',
        porcentaje
      );
    } else {
      Swal.fire({
        title: 'Debe realizar la encuesta para dejar la propina!',
        icon: 'error',
        timer: 2000,
        heightAuto: false,
      });
    }
  }

  async redireccionar(direccion: string) {
    this.setOpenModal(false);
    await this.modalController.dismiss();

    // Redirige a la página deseada
    this.router.navigate([direccion]);
  }
}
