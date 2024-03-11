package examen;

import java.util.Date;

public class Prueba {
	int id;
	Modalidad modalidad;
	Date fecha;
	String descripcion;
	int puntuacion;
	
	public Prueba() {
		
	}

	public Prueba(int id, Modalidad modalidad, Date fecha, String descripcion, int puntuacion) {
		this.id = id;
		this.modalidad = modalidad;
		this.fecha = fecha;
		this.descripcion = descripcion;
		this.puntuacion = puntuacion;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Modalidad getModalidad() {
		return modalidad;
	}

	public void setModalidad(Modalidad modalidad) {
		this.modalidad = modalidad;
	}

	public Date getFecha() {
		return fecha;
	}

	public void setFecha(Date fecha) {
		this.fecha = fecha;
	}

	public String getDescripcion() {
		return descripcion;
	}

	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}

	public int getPuntuacion() {
		return puntuacion;
	}

	public void setPuntuacion(int puntuacion) {
		this.puntuacion = puntuacion;
	}

	@Override
	public String toString() {
		return "Prueba [id=" + id + ", modalidad=" + modalidad + ", fecha=" + fecha + ", descripcion=" + descripcion
				+ ", puntuacion=" + puntuacion + "]";
	}
}
