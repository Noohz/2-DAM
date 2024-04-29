package skills;

public class Alumno {
	private int id;
	private String nombre;
	private int puntuacion;
	private boolean finalizado;
	private Modalidad modalidad;

	public Alumno() {

	}

	public Alumno(int id, String nombre, int puntuacion, boolean finalizado, Modalidad modalidad) {
		this.id = id;
		this.nombre = nombre;
		this.puntuacion = puntuacion;
		this.finalizado = finalizado;
		this.modalidad = modalidad;
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

	public int getPuntuacion() {
		return puntuacion;
	}

	public void setPuntuacion(int puntuacion) {
		this.puntuacion = puntuacion;
	}

	public boolean isFinalizado() {
		return finalizado;
	}

	public void setFinalizado(boolean finalizado) {
		this.finalizado = finalizado;
	}

	public Modalidad getModalidad() {
		return modalidad;
	}

	public void setModalidad(Modalidad modalidad) {
		this.modalidad = modalidad;
	}

	@Override
	public String toString() {
		return "Alumno [id=" + id + ", nombre=" + nombre + ", puntuacion=" + puntuacion + ", finalizado=" + finalizado
				+ ", modalidad=" + modalidad + "]";
	}
}
