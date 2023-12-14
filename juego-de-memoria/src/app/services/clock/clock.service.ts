import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { Subscription, interval, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClockService implements OnInit, OnDestroy {
  segundos = 0;
  private subscription: Subscription | undefined;
  private segunderoDetenidoSubject = new BehaviorSubject<boolean>(true);
  segunderoDetenido$ = this.segunderoDetenidoSubject.asObservable();

  ngOnInit() {
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  iniciarSegundero() {
    this.reiniciarReloj();
    this.subscription = interval(1000).subscribe(() => {
      this.segunderoDetenidoSubject.next(false);
      this.segundos++;
    });
  }

  toggleSegundero() {
    this.segunderoDetenidoSubject.next(!this.segunderoDetenidoSubject.value);
  }

  reiniciarReloj() {
    this.segundos = 0;
    this.segunderoDetenidoSubject.next(true);
    this.subscription?.unsubscribe();
  }
}
