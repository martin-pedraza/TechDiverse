import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, interval } from 'rxjs';
import { AccesoService } from 'src/app/services/acceso.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';
import { Chart, ChartEvent } from 'chart.js';

@Component({
  selector: 'app-sala-espera-cliente',
  templateUrl: './sala-espera-cliente.page.html',
  styleUrls: ['./sala-espera-cliente.page.scss'],
})
export class SalaEsperaClientePage implements OnInit, OnDestroy {
  mostrarEspera: boolean = false;
  mostrarEncuesta: boolean = false;
  usuariosEnEspera: any[] = [];
  encuestas: any[] = [];
  private intervalSubscription: Subscription | undefined;

  constructor(
    private usuariosServ: UsuariosService,
    private accesoSrv: AccesoService,
    private router: Router
  ) {
    this.trampa();
  }

  ngOnDestroy(): void {}

  ngOnInit() {
    this.obtenerListaEspera();
    this.obtenerEncuestas();
    setTimeout(() => {
      this.generarGrafico();
    }, 2000);
  }

  trampa() {
    this.intervalSubscription = interval(3000).subscribe(() => {
      if (
        this.accesoSrv.usuarioLogueado &&
        this.accesoSrv.usuarioLogueado.estado === 'con mesa'
      ) {
        this.router.navigateByUrl('/mesa');
        this.stopInterval();
      }
      if (
        this.accesoSrv.usuarioLogueado &&
        this.accesoSrv.usuarioLogueado.estado === 'activo'
      ) {
        this.router.navigateByUrl('/home');
        this.stopInterval();
      }
    });
  }
  
  private stopInterval() {
    if (this.intervalSubscription) {
      this.intervalSubscription.unsubscribe();
    }
  }

  cerrarSesion() {
    this.stopInterval();
    this.accesoSrv.cerrar();
    this.router.navigateByUrl('/inicio-sesion');
  }

  async obtenerListaEspera() {
    try {
      (await this.usuariosServ.obtenerClientesPorEstado('en-espera')).subscribe(
        (usuarios) => {
          this.usuariosEnEspera = usuarios;
        }
      );
    } catch (error) {
      console.error('Error al obtener:', error);
    }
  }

  async obtenerEncuestas() {
    try {
      (await this.usuariosServ.obtenerEncuestas()).subscribe((encuestas) => {
        this.encuestas = encuestas;
      });
    } catch (error) {
      console.error('Error al obtener:', error);
    }
  }

  pinFormatter(value: number) {
    const estrellas = '⭐'.repeat(value);
    return estrellas;
  }

  verEspera() {
    let usuarioLoggeado = this.accesoSrv.usuarioLogueado;

    if (usuarioLoggeado == undefined || usuarioLoggeado.tipo != 'cliente') {
      Swal.fire({
        title: 'Si no estas registrado, solo podes ver las encuestas',
        icon: 'error',
        heightAuto: false,
      });
    } else {
      this.mostrarEspera = true;
      // this.usuariosServ.actualizarUsuario(usuarioLoggeado.id, {
      //   estado: 'en-espera',
      //   pedidoActualEstado: 'sin-pedido',
      // });
    }
  }

  generarGrafico() {
    const data = {
      labels: this.encuestas.map((enc: any) => enc.descripcion),
      datasets: [
        {
          data: this.encuestas.map((photo: any) => photo.calificacion),
          backgroundColor: this.colors,
        },
      ],
    };
    this.generateRandomColors();
    if (this.pieChart) {
      this.pieChart.destroy();
    }

    const ctx = (<any>document.getElementById('grafico')).getContext('2d');

    this.pieChart = new Chart(ctx, {
      type: 'pie',
      data: data,
      options: {
        plugins: {},
      },
    });
    this.pieChart.update();
  }

  colors?: string[];
  data = [15, 20, 25, 10, 30];
  pieChart?: any;
  @ViewChild('pieCanvas', { static: true }) pieCanvas!: ElementRef;

  generateRandomColors() {
    this.colors = [];
    for (let i = 0; i < this.data.length; i++) {
      const r = Math.floor(Math.random() * 255);
      const g = Math.floor(Math.random() * 255);
      const b = Math.floor(Math.random() * 255);
      this.colors.push(`rgb(${r}, ${g}, ${b})`);
    }
  }
}
