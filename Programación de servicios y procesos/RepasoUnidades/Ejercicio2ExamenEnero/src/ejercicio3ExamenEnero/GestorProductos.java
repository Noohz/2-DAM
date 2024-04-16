package ejercicio3ExamenEnero;

public class GestorProductos {

	// Array con el stock inicial de los 6 productos diferentes.
	int[] productos = { 10, 3, 12, 2, 11, 8 };
	
	void chequearStock(String nombreReponedor) {
		
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
}
