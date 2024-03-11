package ejercicio3;

public class Consumidor extends Thread {
	private CintaTransportadora cinta;

	public Consumidor(CintaTransportadora cinta) {
		this.cinta = cinta;
	}

	public void run() {
		try {
			while (true) {
				int producto = cinta.retirarProducto();
				System.out.println("Consumidor retiró el producto: " + producto);
				Thread.sleep((int) (Math.random() * 1000)); // Simular tiempo de trabajo
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}