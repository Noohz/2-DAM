import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { CuadroDialogoEmpleadoComponent } from '../cuadro-dialogo-empleado/cuadro-dialogo-empleado.component';
import { Empleado } from '../empleado';
import { MusinService } from '../musin.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css']
})
export class ListadoComponent {

  cabecera: string[] = ['id', 'nombre', 'direccion', 'cargo', 'edad', 'imagen', 'eliminar', 'modificar'];
  listaEmpleado = new MatTableDataSource<Empleado>;
  empleado!: Empleado;


  @ViewChild(MatTable) tabla1!: MatTable<Empleado>;
  @ViewChild(MatPaginator) paginador!: MatPaginator;
  @ViewChild(MatSort) ordenacion!: MatSort;

  applyFilter(event: KeyboardEvent) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.listaEmpleado.filter = filterValue.trim().toLowerCase();

    if (this.listaEmpleado.paginator) {
      this.listaEmpleado.paginator.firstPage();
    }
  }

  modificarEmpleado(emp: Empleado) {
    const dialogo2 = this.dialogo.open(CuadroDialogoEmpleadoComponent, { data: emp });
    dialogo2.afterClosed().subscribe(arg => {
      console.log("Después de cerrar el modificar" + arg)

      if (arg != undefined) {
        this.servicio.modificarEmpleado(arg).subscribe(x => {
          alert("Se ha mmodificado correctamente el empleado " + arg.nombre)
        });
      } else {
        alert("No se ha modificado el empleado.")
      }
    })
  }

  eliminarEmpleado(emp: Empleado) {

    if (confirm("¿Estás seguro de eliminar a " + emp.nombre + "?")) {
      this.servicio.eliminarEmplado(emp).subscribe(arg => {
        alert("Se ha eliminado el empleado correctamente.")
        this.listarEmpleados();
      })
    } else {
      alert("No se ha eliminado el empleado " + emp.nombre)
    }
  }


  abrirDialogo() {
    const dialogo1 = this.dialogo.open(CuadroDialogoEmpleadoComponent, { data: new Empleado(0, "", "", "", 0, "") });
    dialogo1.afterClosed().subscribe(arg => {
      console.log("Después de cerrar" + arg);

      if (arg != undefined && arg.id != 0 && arg.id != null) {
        this.servicio.insertarEmpleado(arg).subscribe(x => {

          this.listarEmpleados();
          alert("Se ha insertado el Empleado");

        });
      } else {
        alert("No se ha insertado ningún empleado")
      }

    })
  }


  constructor(private servicio: MusinService, public dialogo: MatDialog) {
    this.listarEmpleados();
  }

  listarEmpleados() {
    this.servicio.leerEmpleados().subscribe(arg => {
      this.listaEmpleado.data = arg;
      this.listaEmpleado.paginator = this.paginador;
      this.listaEmpleado.sort = this.ordenacion;
    });

  }

}
