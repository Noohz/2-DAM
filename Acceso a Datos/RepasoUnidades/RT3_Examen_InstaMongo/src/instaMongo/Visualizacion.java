package instaMongo;

public class Visualizacion {
	private int amigo; // ID del usuario
	private boolean meGusta;

	public Visualizacion() {

	}

	public Visualizacion(int amigo, boolean meGusta) {
		this.amigo = amigo;
		this.meGusta = meGusta;
	}

	public int getAmigo() {
		return amigo;
	}

	public void setAmigo(int amigo) {
		this.amigo = amigo;
	}

	public boolean isMeGusta() {
		return meGusta;
	}

	public void setMeGusta(boolean meGusta) {
		this.meGusta = meGusta;
	}

	@Override
	public String toString() {
		return "Visualizacion [amigo=" + amigo + ", meGusta=" + meGusta + "]";
	}
}
