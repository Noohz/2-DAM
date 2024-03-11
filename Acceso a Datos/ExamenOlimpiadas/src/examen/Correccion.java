package examen;

public class Correccion {
	Alumno alumno;
	Prueba prueba;
	int puntos;
	String comentario;
	
	public Correccion() {
	}

	public Correccion(Alumno alumno, Prueba prueba, int puntos, String comentario) {
		this.alumno = alumno;
		this.prueba = prueba;
		this.puntos = puntos;
		this.comentario = comentario;
	}

	public Alumno getAlumno() {
		return alumno;
	}

	public void setAlumno(Alumno alumno) {
		this.alumno = alumno;
	}

	public Prueba getPrueba() {
		return prueba;
	}

	public void setPrueba(Prueba prueba) {
		this.prueba = prueba;
	}

	public int getPuntos() {
		return puntos;
	}

	public void setPuntos(int puntos) {
		this.puntos = puntos;
	}

	public String getComentario() {
		return comentario;
	}

	public void setComentario(String comentario) {
		this.comentario = comentario;
	}

	@Override
	public String toString() {
		return "Correccion [alumno=" + alumno + ", prueba=" + prueba + ", puntos=" + puntos + ", comentario="
				+ comentario + "]";
	}
}
