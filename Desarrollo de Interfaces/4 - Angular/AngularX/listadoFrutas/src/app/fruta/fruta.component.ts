import { Component } from '@angular/core';
import { Fruta } from '../fruta';
import { ServicioFService } from '../servicio-f.service';

@Component({
  selector: 'app-fruta',
  templateUrl: './fruta.component.html',
  styleUrl: './fruta.component.css',
})
export class FrutaComponent {
  fruta!: Fruta[];
  constructor(private servicioHttp: ServicioFService) {
    this.servicioHttp.leer_Fruta().subscribe((x) => (this.fruta = x));
  }
}
