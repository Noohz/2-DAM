package ejercicio2;

import java.util.Random;

public class Hilo extends Thread {
	Control control = new Control();

	private int id;
	private Random numAleatorio = new Random();
	private int ronda = 0;

	Hilo(int id) {
		this.id = id;
	}

	@Override
	public void run() {
		while (true) {
			int num = numAleatorio.nextInt(200) + 1;
			boolean numGenerado = control.comprobarNumero(num);
			control.mostrarNumerosGenerados();

			if (!numGenerado) {
				System.out.println("Hilo " + id + " eliminado en la ronda " + ronda);
				break;
			}
			ronda++;
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			control.notificarGanador(getName(), ronda);
		}
	}
}
