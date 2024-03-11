import { Component } from '@angular/core';
import { Mensaje } from '../mensaje';
import { ServicioService } from '../servicio.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {

texto: string="";
usuario: string="";
listaMensajes: Mensaje[]=[];
// mensaje:Mensaje={
//   id: 0,
//   fecha: "",
//   usuario: "",
//   texto: ""
// };

mensaje: Mensaje= new Mensaje();

constructor(private servicio:ServicioService){

}

refrescar() {
this.servicio.leerMensajes().subscribe(x =>  {this.listaMensajes = x;console.log(x)});
console.log(this.listaMensajes);
}
enviarMensaje() {
  this.mensaje.fecha= (Date.now(),"hh:mm:ss/dd-MM-yyyy").toString();
  this.mensaje.usuario=this.usuario;
  this.mensaje.mensaje=this.texto;
  this.servicio.escribirMensaje(this.mensaje).subscribe();
}

}
