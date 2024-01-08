import { Component } from '@angular/core';

@Component({
  selector: 'app-componente2',
  standalone: true,
  imports: [],
  templateUrl: './componente2.component.html',
  styleUrl: './componente2.component.css'
})
export class Componente2Component {
  segundo:number=0;
  temporizador!: NodeJS.Timeout;
  iniciar(btn1:HTMLButtonElement, btn2:HTMLButtonElement, btn3:HTMLButtonElement){
    btn1.disabled=true;
    btn2.disabled=false;
    btn3.disabled=true;
    this.temporizador=setInterval(()=>this.segundo++, 1000);
  }

  parar(btn2:HTMLButtonElement, btn3:HTMLButtonElement){
    clearInterval(this.temporizador);
    btn3.disabled=false;
    btn2.disabled=true;
  }
}