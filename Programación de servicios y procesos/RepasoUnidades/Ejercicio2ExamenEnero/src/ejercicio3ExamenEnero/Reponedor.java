/* https://drive.google.com/file/d/1iZ9mMcju7c8mF17HbubkC6aophuwEo30/view */

package ejercicio3ExamenEnero;

import java.util.Random;

public class Reponedor extends Thread {

	GestorProductos gestor;

	public Reponedor(GestorProductos gestor) {
		this.gestor = gestor;
	}

	@Override
	public void run() {

		Random numAleatorio = new Random();

		while (true) {
			try {
				Thread.sleep(numAleatorio.nextInt(3000, 6000));
			} catch (InterruptedException e) {

				e.printStackTrace();
			}

			System.out.println("El reponedor: " + getName() + " está trabajando.");
			gestor.chequearStock(getName());
		}

	}
}
