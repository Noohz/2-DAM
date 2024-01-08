import { Component } from '@angular/core';

@Component({
  selector: 'app-componente3',
  standalone: true,
  imports: [],
  templateUrl: './componente3.component.html',
  styleUrl: './componente3.component.css'
})
export class Componente3Component {
imagen:string="";
generarImagen(){
  let posicion=Math.round(Math.random()*50);
  this.imagen="https://randomuser.me/api/portraits/men/"+posicion+".jpg";
}
}
