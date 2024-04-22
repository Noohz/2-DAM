package examen;

public class Artista {
	int codigo;
	String nombre;
	String correo;
	
	public Artista() {
		
	}

	public Artista(int id, String nombre, String correo) {
		this.codigo = id;
		this.nombre = nombre;
		this.correo = correo;
	}

	public int getId() {
		return codigo;
	}

	public void setId(int id) {
		this.codigo = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getCorreo() {
		return correo;
	}

	public void setCorreo(String correo) {
		this.correo = correo;
	}

	@Override
	public String toString() {
		return "ArtistaTXT [id=" + codigo + ", nombre=" + nombre + ", correo=" + correo + "]";
	}
}
