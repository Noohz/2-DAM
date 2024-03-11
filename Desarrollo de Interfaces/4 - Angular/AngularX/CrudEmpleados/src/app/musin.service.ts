import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Empleado } from './empleado';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MusinService {

  constructor(private httpClient: HttpClient) { }

  leerEmpleados():Observable<Empleado[]>{
    return this.httpClient.get<Empleado[]>('http://moralo.atwebpages.com/ajaxListar/getTodoPersonal.php');
  }

  insertarEmpleado(empleado:Empleado){
    return this.httpClient.post<Empleado>('http://moralo.atwebpages.com/ajaxListar/create_persona.php',empleado);
  }

  modificarEmpleado(empleado:Empleado){
    return this.httpClient.put<Empleado>('http://moralo.atwebpages.com/ajaxListar/update_persona.php',empleado);
  }

  eliminarEmplado(empleado:Empleado){
    return this.httpClient.delete<Empleado>('http://moralo.atwebpages.com/ajaxListar/delete_persona.php/?id='+empleado.id);
  }


}
