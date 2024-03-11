import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  titulo: string = 'Reloj con Angular';
  autor: string = 'Aitor';
  contSegundos: number = 0;
  hora: string = '';
  minutos: string = '';
  segundos: string = '';
  milesimas: string = '';
  reloj: NodeJS.Timeout | undefined;
  constructor() {
    this.MarcarHora();
  }

  MarcarHora() {
    // Función anonima -> (() => {}, X)
    this.reloj = setInterval(() => {
      this.contSegundos++;
      this.hora = new Date().getHours().toString();
      this.minutos = new Date().getMinutes.toString();
      this.segundos = new Date().getSeconds().toString();
      if (this.segundos.length < 2) {
        this.segundos = '0' + this.segundos;
      }
      this.milesimas = new Date().getMilliseconds().toString();
    }, 100);
  }

  iniciar($event: MouseEvent, _t9: HTMLButtonElement) {
    
  }

  parar($event: MouseEvent, _t11: HTMLButtonElement) {
    clearInterval(this.reloj);
  }
}
