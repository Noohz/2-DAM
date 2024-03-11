package ejercicio2;

public class Principal {

	static final int NUMERO_HILOS = 4;
	static Hilo claseHilo = new Hilo();

	public static void main(String[] args) {
		
		Hilo[] hilo = new Hilo[NUMERO_HILOS];

		for (int i = 0; i < NUMERO_HILOS; i++) {
			hilo[i] = new Hilo(i + 1);
			hilo[i].start();
			try {
				hilo[i].join();
			} catch (InterruptedException e) {

				e.printStackTrace();
			}
		}

		System.out.println("\n#** Fin de la carrera **#");
		System.out.println("La distancia recorrida total es: " + Hilo.distanciaRecorrida + " metros.");

	}

}
