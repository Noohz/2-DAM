export class Empleado {
  id: number = 0;
  nombre: string = '';
  direccion: string = '';
  cargo: string = '';
  edad: number = 0;
  imagen: string = '';

  constructor(id:number,nombre:string,direccion:string,cargo:string,edad:number,imagen:string){
  this.id=id;
  this.nombre=nombre;
  this.direccion=direccion;
  this.cargo=cargo;
  this.edad=edad;
  this.imagen=imagen;
  }



}
