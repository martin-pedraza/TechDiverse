import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClockService } from 'src/app/services/clock/clock.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent  implements OnInit {
  public relojIniciado :boolean = false;
  public esTop :boolean = false;

  public get Clock() :number {
    return this.clockService.segundos;
  }

  public get RelojIniciado() : boolean {
    return this.relojIniciado;
  }

  constructor(private router :Router, private userService :UserService, private clockService :ClockService) { }

  ngOnInit() {
    this.clockService.segunderoDetenido$.subscribe((segunderoDetenido) => {
      this.relojIniciado= segunderoDetenido;
    });
  }

  public CerrarSesion(){
    this.userService.CerrarSesion().then(r=>{
      localStorage.clear();
      this.router.navigateByUrl('/acceso');
    })
  }

  public IniciarReloj(){
    this.clockService.iniciarSegundero();
  }

  public CammbiarEsTop(esTop :boolean){
    this.esTop = esTop;
  }
}
