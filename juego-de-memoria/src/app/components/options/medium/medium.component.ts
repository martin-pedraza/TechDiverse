import { Component, OnInit } from '@angular/core';
import { ClockService } from 'src/app/services/clock/clock.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-medium',
  templateUrl: './medium.component.html',
  styleUrls: ['./medium.component.scss'],
})
export class MediumComponent  implements OnInit {
  images: string[] = [
    './../../../assets/alicates.png',
    './../../../assets/llave.png',
    './../../../assets/martillo.png',
    './../../../assets/serrucho.png',
    './../../../assets/taladro.png',
    './../../../assets/alicates.png',
    './../../../assets/llave.png',
    './../../../assets/martillo.png',
    './../../../assets/serrucho.png',
    './../../../assets/taladro.png',
  ];
  buttonDisabled: boolean[] = [];
  buttonImages: string[] = [];
  selectedImageIndex: number = -1;
  allButtonsDisabled: boolean = true;
  coincidencia: number = this.images.length / 2;

  constructor(private clockService: ClockService, private userService :UserService) {}

  ngOnInit() {
    this.shuffleArray(this.images);
    this.buttonDisabled = Array(this.images.length).fill(false);
    this.buttonImages = this.images.map(() => '');

    this.clockService.segunderoDetenido$.subscribe((segunderoDetenido) => {
      this.allButtonsDisabled = segunderoDetenido;
    });
    this.ReiniciarJuego();
  }

  private shuffleArray(array: any[]) {
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
  }

  handleButtonClick(image: string, index: number): void {
    if (!this.buttonImages[index]) {
      this.buttonImages[index] = image;
      if (this.selectedImageIndex === -1) {
        this.selectedImageIndex = index;
      } else {
        if (this.buttonImages[this.selectedImageIndex] === image) {
          this.buttonDisabled[index] = true;
          this.buttonDisabled[this.selectedImageIndex] = true;
          this.selectedImageIndex = -1;
          this.coincidencia--;
          if (this.coincidencia === 0) {
            this.userService.GuardarUsuario("medio", this.clockService.segundos);
            this.ReiniciarJuego();
          }
        } else {
          setTimeout(() => {
            this.buttonImages[index] = '';
            this.buttonImages[this.selectedImageIndex] = '';
            this.selectedImageIndex = -1;
          }, 1000);
        }
      }
    }
  }

  ReiniciarJuego() {
    this.clockService.reiniciarReloj();
    this.coincidencia = this.images.length / 2;
    this.buttonImages = [];
    this.buttonDisabled = [];
  }

}
