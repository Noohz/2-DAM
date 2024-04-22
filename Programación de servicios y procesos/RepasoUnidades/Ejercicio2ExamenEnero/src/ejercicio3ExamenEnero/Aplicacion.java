package ejercicio3ExamenEnero;

import java.util.concurrent.Semaphore;

public class Aplicacion {

	static final int NUM_MAX_CLIENTES = 10;
	static final int NUM_REPONEDORES = 2;

	public static void main(String[] args) {

		// Creo el objeto que gestionará el array de productos.
		GestorProductos gestor = new GestorProductos();

		// Creamos los hilos para los reponedores.
		Reponedor[] reponedores = new Reponedor[NUM_REPONEDORES];

		for (int i = 0; i < NUM_REPONEDORES; i++) {
			reponedores[i] = new Reponedor(gestor);
			reponedores[i].start();
		}

		// Crear el semáforo para controlar el número de clientes simultaneos.
		Semaphore semaforo = new Semaphore(NUM_MAX_CLIENTES);

		// Los clientes estarán continuamente entrando y saliendo de la tienda.
		while (true) {
			try {
				// Compruebo si el cliente puede entrar a la tienda.
				semaforo.acquire();

			} catch (InterruptedException e) {

				e.printStackTrace();
			}

			// Creo el hilo para el nuevo cliente.
			Cliente nuevoCliente = new Cliente(gestor, semaforo);
			nuevoCliente.start();

			
		}

	}

}
