package examen;

public class Empleados {

	String codEmpleado;
	String dni;
	String nombre;
	String codTienda;
	boolean activo;

	public Empleados() {

	}

	public Empleados(String codEmpleado, String dni, String nombre, String codTienda, boolean activo) {
		this.codEmpleado = codEmpleado;
		this.dni = dni;
		this.nombre = nombre;
		this.codTienda = codTienda;
		this.activo = activo;
	}

	public String getCodEmpleado() {
		return codEmpleado;
	}

	public void setCodEmpleado(String codEmpleado) {
		this.codEmpleado = codEmpleado;
	}

	public String getDni() {
		return dni;
	}

	public void setDni(String dni) {
		this.dni = dni;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getCodTienda() {
		return codTienda;
	}

	public void setCodTienda(String codTienda) {
		this.codTienda = codTienda;
	}

	public boolean isActivo() {
		return activo;
	}

	public void setActivo(boolean activo) {
		this.activo = activo;
	}

	

}
