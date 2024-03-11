package ejercicio3;

public class Productor extends Thread {
	private CintaTransportadora cinta;

	public Productor(CintaTransportadora cinta) {
		this.cinta = cinta;
	}

	public void run() {
		try {
			while (true) {
				int producto = (int) (Math.random() * 10) + 1; // Generar número aleatorio
				cinta.colocarProducto(producto);
				System.out.println("Productor colocó el producto: " + producto);
				Thread.sleep((int) (Math.random() * 1000)); // Simular tiempo de trabajo
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}
