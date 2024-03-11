package ejercicio3;

import java.util.concurrent.Semaphore;

public class CintaTransportadora {
	private int[] productos;
	private int capacidadMaxima;
	private Semaphore semaforoEspacio;
	private Semaphore semaforoProductos;

	public CintaTransportadora(int capacidadMaxima) {
		this.capacidadMaxima = capacidadMaxima;
		productos = new int[capacidadMaxima];
		semaforoEspacio = new Semaphore(capacidadMaxima);
		semaforoProductos = new Semaphore(0);
	}

	public void colocarProducto(int producto) throws InterruptedException {
		semaforoEspacio.acquire();
		synchronized (this) {
			for (int i = 0; i < capacidadMaxima; i++) {
				if (productos[i] == 0) {
					productos[i] = producto;
					break;
				}
			}
		}
		semaforoProductos.release();
	}

	public int retirarProducto() throws InterruptedException {
		semaforoProductos.acquire();
		int producto;
		synchronized (this) {
			for (int i = 0; i < capacidadMaxima; i++) {
				if (productos[i] != 0) {
					producto = productos[i];
					productos[i] = 0;
					semaforoEspacio.release();
					return producto;
				}
			}
		}
		return -1; // Nunca debería llegar aquí
	}
}