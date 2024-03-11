package ejercicio2;

public class Ejercicio2 {

	static final int NUMERO_HILOS = 5; // Número de hilos que tiene que lanzar.

	public static void main(String[] args) {
		Contador contador = new Contador(0);
		boolean empezar = false;

		Thread[] threads = new Thread[NUMERO_HILOS];

		// Dar la orden de salida a los hilos
		empezar = true;

		for (int i = 0; i < NUMERO_HILOS; i++) {
			threads[i] = new Thread(new Hilo(100, contador, true, empezar), "Hilo-" + (i + 1));
			threads[i].start();
		}

		// Esperar a que todos los hilos terminen
		for (Thread thread : threads) {
			try {
				thread.join();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}

		System.out.println("Todas las ejecuciones han terminado.");
	}

}
