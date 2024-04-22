package misClases;

import java.util.Random;

public class Hilo extends Thread {
	Control control;

	Hilo(Control control) {
		this.control = control;
	}

	@Override
	public void run() {
		Random numAleatorio = new Random();
		int numero;
		int distanciaRecorrida = 0;

		while (control.haTerminado == false) {
			synchronized (control) {
				for (int i = 0; i < 10; i++) {
					numero = numAleatorio.nextInt(1, 1001);
					try {
						Thread.sleep(100);

					} catch (InterruptedException e) {

						e.printStackTrace();
					}

					if (numero < 5) {
						control.setCarreraFinalizada();
						break;

					} else {
						distanciaRecorrida += numero;

						System.out.println("Soy el hilo " + getName() + " y la distancia recorrida actualmente es: "
								+ distanciaRecorrida + " - " + numero);
					}
				}
			}
		}
	}
}
