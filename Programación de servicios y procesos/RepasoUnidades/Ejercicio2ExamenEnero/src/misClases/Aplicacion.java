package misClases;

public class Aplicacion {

	static final int NUM_HILOS = 10;
	
	public static void main(String[] args) {
		
		// Creo el array para los hilos.
		Hilo[] hilos = new Hilo[NUM_HILOS];
		
		Object controlSalida = new Object();
		
		// Creamos los hilos y los ponemos en marcha.
		for (int i = 0; i < NUM_HILOS; i++) {
			hilos[i] = new Hilo(controlSalida);
			hilos[i].start();
		}
		
		// Doy la salida oficial.
		controlSalida.notifyAll();
	}

}
