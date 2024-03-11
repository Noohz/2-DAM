package examen;

public class Alumno {
	int id;
	String nombre;
	Modalidad modalidad;
	int puntuacion;
	int finalizado;
	
	public Alumno() {
		
	}

	public Alumno(int id, String nombre, Modalidad modalidad, int puntuacion, int finalizado) {
		this.id = id;
		this.nombre = nombre;
		this.modalidad = modalidad;
		this.puntuacion = puntuacion;
		this.finalizado = finalizado;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public Modalidad getModalidad() {
		return modalidad;
	}

	public void setModalidad(Modalidad modalidad) {
		this.modalidad = modalidad;
	}

	public int getPuntuacion() {
		return puntuacion;
	}

	public void setPuntuacion(int puntuacion) {
		this.puntuacion = puntuacion;
	}

	public int getFinalizado() {
		return finalizado;
	}

	public void setFinalizado(int finalizado) {
		this.finalizado = finalizado;
	}

	@Override
	public String toString() {
		return "Alumno [id=" + id + ", nombre=" + nombre + ", modalidad=" + modalidad + ", puntuacion=" + puntuacion
				+ ", finalizado=" + finalizado + "]";
	}
}
