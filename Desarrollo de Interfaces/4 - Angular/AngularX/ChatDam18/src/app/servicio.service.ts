import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Mensaje } from './mensaje';
@Injectable({
  providedIn: 'root'
})
export class ServicioService {

  constructor(private httpCliente:HttpClient) { }

  leerMensajes():Observable<Mensaje[]>{
    return this.httpCliente.get<Mensaje[]>('http://moralo.atwebpages.com/menuAjax/chat/ObtenerMensajes.php')
  }

  escribirMensaje(mensaje:Mensaje){
    return this.httpCliente.put<Mensaje>('http://moralo.atwebpages.com/menuAjax/chat/AltaMensaje.php',mensaje)
  }



}
