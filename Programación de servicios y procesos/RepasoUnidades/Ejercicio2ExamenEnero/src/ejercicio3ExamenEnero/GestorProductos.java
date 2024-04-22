package ejercicio3ExamenEnero;

import java.util.Random;

public class GestorProductos {

	// Array con el stock inicial de los 6 productos diferentes.
	int[] productos = { 10, 3, 12, 2, 11, 8 };
	
	synchronized void chequearStock(String nombreReponedor) {
		
		boolean productoEncontrado = false;
		
		/*for (int i = 0; i < productos.length; i++) {
			if (productos[i] < 2) {
				productos[i] += 10;
				
				productoEncontrado = true;
				
				System.out.println("El " + nombreReponedor + " ha incrementado en 10 unidades el stock del producto " + i + " (" + productos[i] + ")");
			}
		}*/
		
		for (int i : productos) {
			
			// Si quedan menos de 2 unidades, reponemos 10 más.
			if (i < 2) {
				i += 10;
				productoEncontrado = true;
				
				System.out.println("El " + nombreReponedor + " ha incrementado en 10 unidades el stock del producto " + i + " (" + i + ")");
			}
		}
		
		if (productoEncontrado == false) {
			System.err.println("El " + nombreReponedor + " no ha encontrado ningún producto para actualizar.");
		}
	}

	public synchronized void intentarComprarProducto(String nombreCliente) {
		Random numAleatorio = new Random();
		
		// Seleccionar el producto.
		int idProducto = numAleatorio.nextInt(0, productos.length);
		int numUnidades = numAleatorio.nextInt(1, 4);
		
		if (productos[idProducto] >= numUnidades) {
			productos[idProducto] -= numUnidades;
			
			// El cliente puede comprar ese producto.
			System.out.println("El cliente " + nombreCliente + " ha comprado " + numUnidades + " unidades del producto " + idProducto + ". Quedan " + productos[idProducto] + "unidades.");
		} else {
			// El cliente no puede comprar ese producto por que no hay stock suficiente.
			System.err.println("El cliente " + nombreCliente + " ha intentado comprar " + numUnidades + " del producto " + idProducto + " pero no había stock suficiente.");
		}
		
	}
}
