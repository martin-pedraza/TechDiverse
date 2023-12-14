import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  OnDestroy,
} from '@angular/core';
import { Chart } from 'chart.js/auto';
import { Subscription } from 'rxjs';
import { FirebaseService } from 'src/app/services/firebase/firebase.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss'],
})
export class ReportsComponent implements OnInit, OnDestroy {
  likesDataFeas: any[] = [];
  likesDataLindas: any[] = [];
  @ViewChild('modal') modal: ElementRef | undefined;
  private likesDataFeasSubscription: Subscription | undefined;
  private likesDataLindasSubscription: Subscription | undefined;
  private chartFeas: Chart | undefined;
  private chartLindas: Chart<"pie", any[], any> | undefined;

  constructor(private firebaseService: FirebaseService) {}

  ngOnDestroy(): void {
    if (this.likesDataFeasSubscription) {
      this.likesDataFeasSubscription.unsubscribe();
    }
    if (this.likesDataLindasSubscription) {
      this.likesDataLindasSubscription.unsubscribe();
    }
    if (this.chartFeas) {
      this.chartFeas.destroy();
    }
    if (this.chartLindas) {
      this.chartLindas.destroy();
    }
  }

  ngOnInit(): void {
    this.likesDataFeasSubscription = this.firebaseService
      .getLikesData('fotosFeas')
      .subscribe((likesData) => {
        this.likesDataFeas = likesData;
        this.renderChart();
      });
    this.likesDataLindasSubscription = this.firebaseService
      .getLikesData('fotosLindas')
      .subscribe((likesData) => {
        this.likesDataLindas = likesData;
        this.renderChart2();
      });
  }

  renderChart() {
    if (this.chartFeas) {
      this.chartFeas.destroy(); // Destruir gráfico existente
    }
    const labels = this.likesDataFeas.map((item) => item.creador);
    const likes = this.likesDataFeas.map((item) => item.likes);

    const canvas: any = document.getElementById('likesChart');
    const ctx = canvas.getContext('2d');

    this.chartFeas = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Likes',
            data: likes,
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });

    canvas.onclick = (event: any) => {
      if (this.chartFeas) {
        const activePoints = this.chartFeas.getElementsAtEventForMode(
          event,
          'nearest',
          { intersect: true },
          false
        );
        if (activePoints.length > 0) {
          const index = activePoints[0].index;
          const imgSrc = this.likesDataFeas[index].foto;
          this.openModal(imgSrc);
        }
      }
    };
  }

  openModal(imgSrc: string) {
    if (this.modal) {
      const modalImg: HTMLImageElement =
        this.modal.nativeElement.querySelector('img');
      modalImg.src = imgSrc;
      this.modal.nativeElement.style.display = 'block';
    } else {
      console.error('Modal element is undefined.');
    }
  }

  closeModal() {
    if (this.modal) {
      this.modal.nativeElement.style.display = 'none';
    } else {
      console.error('Modal element is undefined.');
    }
  }

  renderChart2() {
    if (this.chartLindas) {
      this.chartLindas.destroy(); // Destruir gráfico existente
    }
    const labels = this.likesDataLindas.map((item) => item.creador);
    const likes = this.likesDataLindas.map((item) => item.likes);

    const canvas: any = document.getElementById('likesChart2');
    const ctx = canvas.getContext('2d');

    this.chartLindas = new Chart(ctx, 
    {
      type: 'pie',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Likes',
            data: likes,
            backgroundColor: [
              'rgba(75, 192, 192, 0.2)',
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(153, 102, 255, 0.2)',
            ],
            borderColor: [
              'rgba(75, 192, 192, 1)',
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(153, 102, 255, 1)',
            ],
            borderWidth: 1,
          },
        ],
      }
    });

    canvas.onclick = (event: any) => {
      if (this.chartLindas) {
        const activePoints = this.chartLindas.getElementsAtEventForMode(
          event,
          'nearest',
          { intersect: true },
          false
        );
        if (activePoints.length > 0) {
          const index = activePoints[0].index;
          const imgSrc = this.likesDataLindas[index].foto;
          this.openModal(imgSrc);
        }
      }
    };
  }
}
