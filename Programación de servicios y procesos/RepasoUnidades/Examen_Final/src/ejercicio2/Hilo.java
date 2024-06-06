package ejercicio2;

import java.util.Random;

public class Hilo extends Thread {
	private final int idHilo;
	private final Control control;

	public Hilo(int idHilo, Control control) {
		this.idHilo = idHilo;
		this.control = control;
	}

	@Override
	public void run() {
		Random random = new Random();
		while (true) {
			synchronized (control) {
				if (control.getTurnoActual() == idHilo) {
					int numero = random.nextInt(500) + 1;
					boolean acertado = control.adivinarNumero(numero, idHilo);
					if (acertado) {
						break;
					}
					try {
						Thread.sleep(1000);
					} catch (InterruptedException e) {
						e.printStackTrace();
					}
				}
			}
		}
	}
}
