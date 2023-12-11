import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  titulo:string = 'AngularX - 0';
  nombre:string = 'Aitor Ramos';
  practica:string = 'Práctica 0';
  numAleatorio:number = Math.round(Math.random()*1000);
}
