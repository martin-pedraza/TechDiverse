import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccesoService } from 'src/app/services/acceso.service';
import { UsuariosService } from 'src/app/services/usuarios.service';
import Swal from 'sweetalert2';
import { Chart, ChartEvent } from 'chart.js';

@Component({
  selector: 'app-hacer-encuesta',
  templateUrl: './hacer-encuesta.page.html',
  styleUrls: ['./hacer-encuesta.page.scss'],
})
export class HacerEncuestaPage implements OnInit {
  usuario:any;
  resenaForm: FormGroup;
  encuesta:boolean = true;
  encuestas: any[] = [];

  constructor(private accesoService:AccesoService, private router:Router, private fb: FormBuilder, private usuarioService: UsuariosService) 
  {
    this.resenaForm = this.fb.group({
      descripcion: ['', Validators.required],
      calificacion: [5, Validators.required],
      estadoComida: ['excelente', Validators.required],
      estadoLimpieza: ['excelente', Validators.required],
      mostrarResena: [false, Validators.requiredTrue]
    });
  }

  ngOnInit() {
    const sub = this.usuarioService.obtenerUsuario(this.accesoService.usuarioLogueado.id)?.subscribe((user:any) => {
      this.usuario = user;
      if(this.usuario) 
      {
        if(!this.usuario?.mesa)
        {
          Swal.fire({
            title: 'No puede realizar la encuesta',
            text: 'Debe tener una mesa asignada para realizar la encuesta!',
            icon: 'warning',
            heightAuto: false,
          });
          this.router.navigate(['sala-espera-cliente']);
        }
    
        if(this.usuario?.encuesta){ 
          setTimeout(()=>{
            this.generarGrafico();
          },1000)
          this.obtenerEncuestas();
          this.encuesta = false;
        }
      }
      else{
        this.router.navigate(['inicio-sesion']);
      }
    }); 
  }

  pinFormatter(value: number) {
       
    const estrellas = "⭐".repeat(value);
    return estrellas
  }

  

  enviarResena() {
    if(this.resenaForm.valid)
    {
      this.accesoService.usuarioLogueado = {
        ...this.accesoService.usuarioLogueado,
        encuesta: true
      }
      this.usuarioService.actualizarUsuario(this.usuario.id, {encuesta: true});
      this.usuarioService.subirResenia(this.resenaForm.value);
      this.router.navigate(['mesa']);
    }
  }

  async obtenerEncuestas() {
    try {
      (await this.usuarioService.obtenerEncuestas()).subscribe((encuestas) => {
        console.log(encuestas);
        this.encuestas = encuestas;
      });
    } catch (error) {
      console.error('Error al obtener:', error);
    }
  }


  generarGrafico()
  {
    const data = {
      labels: this.encuestas.map((enc: any) => enc.descripcion),
      datasets: [{
        data: this.encuestas.map((photo: any) => photo.calificacion),
        backgroundColor: this.colors
      }]
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
        
        plugins: {

        }
      }
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
