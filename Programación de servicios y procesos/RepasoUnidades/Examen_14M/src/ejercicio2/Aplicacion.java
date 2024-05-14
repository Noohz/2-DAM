package ejercicio2;

public class Aplicacion {

	static final int NUM_HILOS = 3;

	public static void main(String[] args) {
		Control control = new Control();
		Hilo[] hilos = new Hilo[NUM_HILOS];

		for (int i = 0; i < NUM_HILOS; i++) {
			hilos[i] = new Hilo(i + 1);
			hilos[i].start();
		}

		for (Hilo hilo : hilos) {
			try {
				hilo.join();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}

		System.out.println("¡Fin del juego!" + " - " + " El ganador es: " + control.getGanador() + " - rondas: " + control.getNumRondas());
	}

}
