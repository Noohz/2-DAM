package instaMongo;

public class Usuario {
	private int id;
	private String email;
	private String nombre;
	private int numPublicaciones;

	public Usuario() {

	}

	public Usuario(int id, String email, String nombre, int numPublicaciones) {
		this.id = id;
		this.email = email;
		this.nombre = nombre;
		this.numPublicaciones = numPublicaciones;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public int getNumPublicaciones() {
		return numPublicaciones;
	}

	public void setNumPublicaciones(int numPublicaciones) {
		this.numPublicaciones = numPublicaciones;
	}

	@Override
	public String toString() {
		return "Usuario [id=" + id + ", email=" + email + ", nombre=" + nombre + ", numPublicaciones="
				+ numPublicaciones + "]";
	}
}
