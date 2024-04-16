package ejercicio3ExamenEnero;

public class Cliente extends Thread {

	GestorProductos gestor;

	public Cliente(GestorProductos gestor) {
		this.gestor = gestor;
	}

	@Override
	public void run() {
		System.out.println("El cliente " + getName() + " ha entrado en la tienda.");

		try {
			// Hacemos una pausa de 1000 milisegundos mientras el cliente busca el producto.
			Thread.sleep(1000);

		} catch (InterruptedException e) {

			e.printStackTrace();
		}

		// El cliente intentará comprar el producto.
		gestor.intentarComprarProducto(getName());
	}
}
