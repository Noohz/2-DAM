package ejercicio3ExamenEnero;

import java.util.concurrent.Semaphore;

public class Cliente extends Thread {

	GestorProductos gestor;
	Semaphore semaforo;

	public Cliente(GestorProductos gestor, Semaphore semaforo) {
		this.gestor = gestor;
		this.semaforo = semaforo;
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

		// Justo antes de terminar hacemos un release del semaforo, para que pueda entrar un nuevo cliente.
		System.out.println("El cliente " + getName() + " va a abandonar la tienda.");
		semaforo.release();
	}
}
