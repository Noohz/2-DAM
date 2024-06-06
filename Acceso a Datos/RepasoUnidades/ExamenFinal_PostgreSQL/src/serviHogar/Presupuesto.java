package serviHogar;

import java.util.ArrayList;
import java.util.Date;

public class Presupuesto {
	private int id;
	private Date fecha;
	private Cliente datosCliente;
	private ArrayList<String[]> servicios = new ArrayList<String[]>();
	
	public Presupuesto() {
		
	}

	public Presupuesto(int id, Date fecha, Cliente datosCliente, ArrayList<String[]> servicios) {
		this.id = id;
		this.fecha = fecha;
		this.datosCliente = datosCliente;
		this.servicios = servicios;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Date getFecha() {
		return fecha;
	}

	public void setFecha(Date fecha) {
		this.fecha = fecha;
	}

	public Cliente getDatosCliente() {
		return datosCliente;
	}

	public void setDatosCliente(Cliente datosCliente) {
		this.datosCliente = datosCliente;
	}

	public ArrayList<String[]> getServicios() {
		return servicios;
	}

	public void setServicios(ArrayList<String[]> servicios) {
		this.servicios = servicios;
	}

	@Override
	public String toString() {
		return "Presupuesto [id=" + id + ", fecha=" + fecha + ", datosCliente=" + datosCliente + ", servicios="
				+ servicios + "]";
	}
}
