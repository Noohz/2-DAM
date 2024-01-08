import { Component } from '@angular/core';

@Component({
  selector: 'app-componente4',
  standalone: true,
  imports: [],
  templateUrl: './componente4.component.html',
  styleUrl: './componente4.component.css'
})
export class Componente4Component {
  contenido:string="";
  insertarFila(tb:HTMLTableElement){
    tb.innerHTML+= "<tr><td>"+this.contenido+"</td></tr>"
  }
}
