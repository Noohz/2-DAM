package ejercicio2;

import java.util.Scanner;

public class Aplicacion {
	private static final int NUM_THREADS = 3;

	public static void main(String[] args) {
		Scanner src = new Scanner(System.in);
		boolean jugarNuevamente;

		do {
			Control control = new Control(NUM_THREADS);
			System.out.print("Introduce un número secreto entre 1 y 500: ");
			int numeroSecreto = src.nextInt();
			control.setNumeroSecreto(numeroSecreto);

			Hilo[] hilos = new Hilo[NUM_THREADS];
			for (int i = 0; i < NUM_THREADS; i++) {
				hilos[i] = new Hilo(i, control);
				hilos[i].start();
			}

			for (Hilo hilo : hilos) {
				try {
					hilo.join();
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			}

			System.out.print("¿Quieres jugar nuevamente? (s/n): ");
			jugarNuevamente = src.next().equalsIgnoreCase("s");
		} while (jugarNuevamente);

		src.close();
	}
}
