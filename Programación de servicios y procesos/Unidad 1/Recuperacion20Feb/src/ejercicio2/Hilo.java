package ejercicio2;

public class Hilo extends Thread {

	int numAleatorio;
	static int distanciaRecorrida = 0;
	int id;
	static boolean finBucle = false;
	int contador = 0;

	public Hilo() {

	}

	public Hilo(int id) {
		this.id = id;
	}

	@Override
	public synchronized void run() {
		while (!finBucle) {

			for (int i = 0; i < 10; i++) {
				try {
					Thread.sleep(150);

				} catch (InterruptedException e) {

					e.printStackTrace();
				}

				numAleatorio = (int) (Math.random() * 1001);

				System.out.println("Soy el Hilo número: " + id + " y mi número aleatorio es: " + numAleatorio);

				distanciaRecorrida += numAleatorio;
				contador++;

				if (contador == 10) {
					stop();
				}

				if (numAleatorio < 5) {
					finBucle = true;
					stop();
				}
			}
		}
	}

	public static int getDistanciaRecorrida() {
		return distanciaRecorrida;
	}

	public static void setDistanciaRecorrida(int distanciaRecorrida) {
		Hilo.distanciaRecorrida = distanciaRecorrida;
	}

}
