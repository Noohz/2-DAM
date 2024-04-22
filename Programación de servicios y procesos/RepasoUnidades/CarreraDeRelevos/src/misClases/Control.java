package misClases;

public class Control {
	private int distanciaRecorrida;
	boolean haTerminado;
	int contador;
	
	public Control() {
		
	}

	public Control(int distanciaRecorrida) {
		this.distanciaRecorrida = distanciaRecorrida;
		haTerminado = false;
		this.contador = 0;
	}

	public int getDistanciaRecorrida() {
		return distanciaRecorrida;
	}

	public void setDistanciaRecorrida(int distanciaRecorrida) {
		this.distanciaRecorrida = distanciaRecorrida;
	}
	
	public void setCarreraFinalizada() {
		haTerminado = true;
		System.err.println("La carrera ha finalizado.");
	}
	
	
}
