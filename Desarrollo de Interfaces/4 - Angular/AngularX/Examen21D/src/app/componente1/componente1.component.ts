import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-componente1',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './componente1.component.html',
  styleUrl: './componente1.component.css'
})
export class Componente1Component {
  titulo="bloque 1";
  botones:string[] = ["boton1", "boton2", "boton3", "boton4", "boton5"];
  color:string = "color1";
  cambiar(i:number) {
    this.color="color"+ (i+1);
  }
    
}
