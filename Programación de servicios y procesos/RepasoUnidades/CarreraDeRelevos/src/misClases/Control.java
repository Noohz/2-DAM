package misClases;

public class Control {
	private int turno;
	private int distanciaRecorrida;
	private int numVueltas;
	private boolean carrearaTerminada;
	private int numHilos;

	public Control() {

	}

	public Control(int turno, int distanciaRecorrida, int numVueltas, boolean carrearaTerminada, int numHilos) {
		this.turno = 1;
		this.distanciaRecorrida = 0;
		this.numVueltas = 0;
		this.carrearaTerminada = false;
		this.numHilos = numHilos;
	}

	public synchronized int getTurno() {
		return turno;
	}
	
	public synchronized void setTurno(int turno) {
		this.turno = turno;
	}

	public synchronized void setCambiarTurno() {
		this.turno++;

		if (turno >= numHilos) {
			turno = 0;
			numVueltas++;
			System.out.println("Vuelta número: " + numVueltas);
		}
	}

	public int getDistanciaRecorrida() {
		return distanciaRecorrida;
	}

	public void sumarDistanciaRecorrida(int distanciaRecorrida) {
		this.distanciaRecorrida += distanciaRecorrida;
		System.out.println("Distancia recorrida: " + this.distanciaRecorrida);
	}

	public int getNumVueltas() {
		return numVueltas;
	}

	public void setNumVueltas(int numVueltas) {
		this.numVueltas = numVueltas;
	}

	public synchronized boolean isCarrearaTerminada() {
		return carrearaTerminada;
	}

	public synchronized void setCarrearaTerminada(boolean carrearaTerminada) {
		this.carrearaTerminada = carrearaTerminada;
	}

}
