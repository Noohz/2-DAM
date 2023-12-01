package rutas;

public class Paraje {
	private int id;
	private String nombre;
	private int hectareas;

	public Paraje() {
		super();
	}

	public Paraje(int id, String nombre, int hectareas) {
		super();
		this.id = id;
		this.nombre = nombre;
		this.hectareas = hectareas;
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

	public int getHectareas() {
		return hectareas;
	}

	public void setHectareas(int hectareas) {
		this.hectareas = hectareas;
	}

	@Override
	public String toString() {
		return "Paraje [id=" + id + ", nombre=" + nombre + ", hectareas=" + hectareas + "]";
	}
}
