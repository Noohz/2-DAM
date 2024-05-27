package museo;

public class TipoUbicacion {
	private String seccion;
	private int puesto;

	public TipoUbicacion() {

	}

	public TipoUbicacion(String seccion, int puesto) {
		this.seccion = seccion;
		this.puesto = puesto;
	}

	public String getSeccion() {
		return seccion;
	}

	public void setSeccion(String seccion) {
		this.seccion = seccion;
	}

	public int getPuesto() {
		return puesto;
	}

	public void setPuesto(int puesto) {
		this.puesto = puesto;
	}

	@Override
	public String toString() {
		return "TipoUbicacion [seccion=" + seccion + ", puesto=" + puesto + "]";
	}
}
