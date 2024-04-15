package MisClases;

import java.util.Random;

public class Hilo extends Thread {

	ContadorMaximo controlMaximo;

	Hilo(ContadorMaximo controlMaximo) {
		this.controlMaximo = controlMaximo;
	}

	@Override
	public void run() {
		Random numAleatorio = new Random();

		// Generar 100 números aleatorios.
		int suma = 0;

		for (int i = 0; i < 100; i++) {
			suma += numAleatorio.nextInt(1, 1001);
		}

		System.out.println(this.getName() + " - " + suma);
		controlMaximo.setMaximo(suma); // Le pasamos la suma para que compruebe si es el máximo o no.
	}

}
