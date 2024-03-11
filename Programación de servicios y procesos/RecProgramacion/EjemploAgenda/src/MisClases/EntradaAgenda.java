package MisClases;

import java.io.Serializable;

public class EntradaAgenda implements Serializable {
	private String nombre;
	private String direccion;
	private String email;
	private int numFijo;
	private int numMovil;

	public EntradaAgenda() {

	}

	public EntradaAgenda(String nombre, String direccion, String email, int numFijo, int numMovil) {
		this.nombre = nombre;
		this.direccion = direccion;
		this.email = email;
		this.numFijo = numFijo;
		this.numMovil = numMovil;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getDireccion() {
		return direccion;
	}

	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public int getNumFijo() {
		return numFijo;
	}

	public void setNumFijo(int numFijo) {
		this.numFijo = numFijo;
	}

	public int getNumMovil() {
		return numMovil;
	}

	public void setNumMovil(int numMovil) {
		this.numMovil = numMovil;
	}

	@Override
	public String toString() {
		return nombre + "(" + email + ") " + numFijo + ", " +numMovil;
	}
}
