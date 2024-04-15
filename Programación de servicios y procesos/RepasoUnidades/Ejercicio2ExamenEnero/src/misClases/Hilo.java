package misClases;

import java.util.Random;

public class Hilo extends Thread {

	Object controlSalida;

	Hilo(Object controlSalObject) {
		this.controlSalida = controlSalObject;
	}

	@Override
	public void run() {
		try {
			controlSalida.wait();

			Random numAleatorio = new Random();

			int contador = 0;
			int contadorSeises = 0;

			while (contadorSeises < 9) {
				// Tiro el dado
				int resultado = numAleatorio.nextInt(1, 7);
				contador++;
				
				if (resultado == 6) {
					contadorSeises++;
				} else {
					contadorSeises = 0;
				}
			}

		} catch (InterruptedException e) {

			e.printStackTrace();
		}
	}

}
