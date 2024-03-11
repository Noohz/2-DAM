import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fruta } from './fruta';

@Injectable({
  providedIn: 'root',
})
export class ServicioFService {
  constructor(private httpCliente: HttpClient) {}
  leer_Fruta(): Observable<Fruta[]> {
    return this.httpCliente.get<Fruta[]>(
      'http://moralo.atwebpages.com/menuAjax/productos2/index.php'
    );
  }

  insertar_Fruta() {}

  eliminar_Fruta() {}
}
