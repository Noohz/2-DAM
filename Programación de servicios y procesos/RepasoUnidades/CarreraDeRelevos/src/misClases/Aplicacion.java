package misClases;

public class Aplicacion {

	static final int NUM_HILOS = 4;

	public static void main(String[] args) {

		Hilo[] hilos = new Hilo[NUM_HILOS];

		Control control = new Control();

		for (int i = 0; i < NUM_HILOS; i++) {
			hilos[i] = new Hilo(control, i);
			hilos[i].start();
		}

		for (int i = 0; i < NUM_HILOS; i++) {
			try {
				hilos[i].join();

			} catch (InterruptedException e) {

				e.printStackTrace();
			}
		}

		// Establecemos el turno inicial para que empiece la carrera.
		control.setTurno(0);
	}

}
