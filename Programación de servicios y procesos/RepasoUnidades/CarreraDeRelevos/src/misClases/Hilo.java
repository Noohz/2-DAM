package misClases;

import java.util.Random;

public class Hilo extends Thread {
	Control control;
	private int numHilo;

	Hilo(Control control, int numHilo) {
		this.control = control;
		this.numHilo = numHilo;
	}

	@Override
	public void run() {

		Random numAleatorio = new Random();

		while (control.isCarrearaTerminada() == false) {
			if (control.getTurno() == numHilo) {
				int numNumeros = 0;

				System.out.println("El hilo " + numHilo + " comienza a correr.");

				while (numNumeros < 10) {
					// Hacemos una pausa para ver mejor la evolución.
					try {
						Thread.sleep(200);
					} catch (InterruptedException e) {

						e.printStackTrace();
					}

					int numero = numAleatorio.nextInt(1, 1001);

					numNumeros++;

					if (numero < 5) {
						// El testigo ha caido y la carrera terminó.
						control.setCarrearaTerminada(true);

						synchronized (control) {
							// Avisamos a todos los hilos que estén esperando de que la carrera ha terminado.
							control.notifyAll();
						}
						
						System.err.println("¡Fin de la carrera! - El testigo ha caido.");

						break; // Nos salimos del while.

					} else {
						// Incrementamos la distancia recorrida.
						control.sumarDistanciaRecorrida(numero);
					}
				}

				if (numNumeros >= 10) {
					// Cambiar el turno del corredor.
					control.setCambiarTurno();

					synchronized (control) {
						// Avisamos a todos los hilos que estén esperando de que ha cambiado el turno.
						control.notifyAll();
					}
				}

			} else {
				try {
					// Cuando no es mi turno, me quedo esperando.
					synchronized (control) {
						control.wait();
					}
				} catch (InterruptedException e) {

					e.printStackTrace();
				}
			}
		}
	}
}
