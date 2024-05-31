package instaMongo;

import java.util.ArrayList;
import java.util.Date;

public class Foto {
	private int id;
	private int propietario;
	private String url;
	private Date fecha;
	private ArrayList<Visualizacion> visualizaciones = new ArrayList<Visualizacion>();
	
	public Foto() {
		
	}

	public Foto(int id, int propietario, String url, Date fecha, ArrayList<Visualizacion> visualizaciones) {
		this.id = id;
		this.propietario = propietario;
		this.url = url;
		this.fecha = fecha;
		this.visualizaciones = visualizaciones;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getPropietario() {
		return propietario;
	}

	public void setPropietario(int propietario) {
		this.propietario = propietario;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public Date getFecha() {
		return fecha;
	}

	public void setFecha(Date fecha) {
		this.fecha = fecha;
	}

	public ArrayList<Visualizacion> getVisualizaciones() {
		return visualizaciones;
	}

	public void setVisualizaciones(ArrayList<Visualizacion> visualizaciones) {
		this.visualizaciones = visualizaciones;
	}

	@Override
	public String toString() {
		String c = "Foto [id=" + id + ", propietario=" + propietario + ", url=" + url + ", fecha=" + fecha + "]";
		
		for (Visualizacion visualizacion : visualizaciones) {
			c += "--" + visualizacion;
		}
		
		return c;
	}	
}
