package farmacia;

public class Farmacia {
	private int codigo;
	private String nombre;
	private String cif;
	private String direccion;

	public Farmacia() {

	}

	public Farmacia(int codigo, String nombre, String cif, String direccion) {
		this.codigo = codigo;
		this.nombre = nombre;
		this.cif = cif;
		this.direccion = direccion;
	}

	public int getCodigo() {
		return codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getCif() {
		return cif;
	}

	public void setCif(String cif) {
		this.cif = cif;
	}

	public String getDireccion() {
		return direccion;
	}

	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}

	@Override
	public String toString() {
		return "Farmacia [codigo=" + codigo + ", nombre=" + nombre + ", cif=" + cif + ", direccion=" + direccion + "]";
	}
}
