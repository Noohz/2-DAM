import { Component } from '@angular/core';
import { Fruta } from '../fruta';
import { ServicioFrutaService } from '../servicio-fruta.service';

@Component({
  selector: 'app-frutas',
  templateUrl: './frutas.component.html',
  styleUrl: './frutas.component.css',
})
export class FrutasComponent {
  //objeto de la clase fruta para recoger todos los campos del formulario de inserción
  prod!: Fruta;

  //identificar el contenido de cada atributo del valor seleccionado para insertar, modificar o eliminar
  selectedProduct: Fruta = {
    id: '',
    nombre: '',
    precio: 0,
    unidades: 0,
    imagen: '',
  };

  listaFruta!: Fruta[];
  constructor(private servicioHttp: ServicioFrutaService) {
    this.servicioHttp.leerProduct().subscribe(x => this.listaFruta = x);
  }

  crearProducto() {
    this.servicioHttp.createProduct(this.selectedProduct).subscribe((producto: Fruta) => { this.listaFruta.push(producto) });
    this.selectedProduct = { id: '', nombre: '', precio: 0, unidades: 0, imagen: '' };
  }

  seleccionar(fruta: Fruta) {
    this.selectedProduct = fruta;
  }

  eliminar(id: string) {
    this.servicioHttp.deleteProduct(id).subscribe((producto: Fruta) => {
      this.listaFruta = this.listaFruta.filter(f => f.id !== id);
    });
  }

  actualizarProducto() {
    this.servicioHttp.updateProduct(this.selectedProduct).subscribe((producto: Fruta) => { this.prod = producto });
  }
}
