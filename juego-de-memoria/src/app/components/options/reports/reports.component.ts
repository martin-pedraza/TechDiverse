import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss'],
})
export class ReportsComponent implements OnInit, OnDestroy {
  registrosFacilSubscription: Subscription | undefined;
  registrosFacil: any[] = [];
  registrosMedioSubscription: Subscription | undefined;
  registrosMedio: any[] = [];
  registrosDificilSubscription: Subscription | undefined;
  registrosDificil: any[] = [];

  constructor(private userService: UserService) {}

  ngOnDestroy(): void {
    this.registrosDificilSubscription?.unsubscribe();
    this.registrosFacilSubscription?.unsubscribe();
    this.registrosMedioSubscription?.unsubscribe();
  }

  ngOnInit() {
    this.registrosFacilSubscription = this.userService
      .TraerRegistros('facil')
      .subscribe((data) => {
        this.registrosFacil = data;
      });

    this.registrosMedioSubscription = this.userService
      .TraerRegistros('medio')
      .subscribe((data) => {
        this.registrosMedio = data;
      });

    this.registrosDificilSubscription = this.userService
      .TraerRegistros('dificil')
      .subscribe((data) => {
        this.registrosDificil = data;
      });
  }
}
