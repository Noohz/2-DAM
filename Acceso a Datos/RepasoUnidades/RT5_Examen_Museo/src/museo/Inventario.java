package museo;

import java.util.ArrayList;
import java.util.Date;

public class Inventario {

	private int id;
	private String nombre;
	private Date fechaAlta;
	private TipoUbicacion ubicacion;
	private ArrayList<String[]> caracteristicas = new ArrayList<String[]>();

	public Inventario() {

	}

	public Inventario(int id, String nombre, Date fechaAlta, TipoUbicacion ubicacion,
			ArrayList<String[]> caracteristicas) {
		this.id = id;
		this.nombre = nombre;
		this.fechaAlta = fechaAlta;
		this.ubicacion = ubicacion;
		this.caracteristicas = caracteristicas;
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

	public Date getFechaAlta() {
		return fechaAlta;
	}

	public void setFechaAlta(Date fechaAlta) {
		this.fechaAlta = fechaAlta;
	}

	public TipoUbicacion getUbicacion() {
		return ubicacion;
	}

	public void setUbicacion(TipoUbicacion ubicacion) {
		this.ubicacion = ubicacion;
	}

	public ArrayList<String[]> getCaracteristicas() {
		return caracteristicas;
	}

	public void setCaracteristicas(ArrayList<String[]> caracteristicas) {
		this.caracteristicas = caracteristicas;
	}

	@Override
	public String toString() {
		return "Inventario [id=" + id + ", nombre=" + nombre + ", fechaAlta=" + fechaAlta + ", ubicacion=" + ubicacion
				+ "]";
	}

	public void mostrarCaracteristicas() {
		for (String[] datos : caracteristicas) {
			System.out.println("Característica: " + datos[0] + " -- " + datos[1]);
		}
	}
}
