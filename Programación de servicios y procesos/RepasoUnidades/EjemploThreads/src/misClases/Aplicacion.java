package misClases;

public class Aplicacion {

	public static void main(String[] args) {
		
		/*// Hilo Thread
		Hilo1 hilo1 = new Hilo1();
		hilo1.setName("Hilo1");
		
		// Hilo Runnable
		Hilo2 hl2 = new Hilo2("Hilo2"); // El parámetro que se le pasa será el nombre del hilo.
		Thread hilo2 = new Thread(hl2);

		hilo1.start();
		hilo2.start();
		
		try {
			hilo1.join(); // El join no influye en que hilo ha terminado antes.
			hilo2.join();
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}
		*/
		
		int NUM_HILOS = 7;
		
		// Crear el array para los hilos.
		Hilo1[] arHilos = new Hilo1[NUM_HILOS];
		
		Compartida compartida = new Compartida(0); // Una variable que compartirán todos los Hilos.
		
		// Creamos los objetos para los Hilos y los ponemos en marcha.
		for (int i = 0; i < NUM_HILOS; i++) {
			arHilos[i] = new Hilo1(compartida);
			arHilos[i].start();
		}
		
		// Esperamos a que todos los Hilos hayan terminado. ESTO SIGUE SIN DETERMINAR EL ORDEN EN EL QUE TERMINAN.
		for (int i = 0; i < NUM_HILOS; i++) {
			try {
				arHilos[i].join();
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
		}
		
		System.out.println("Aquí termina la ejecución del Hilo principal.");
	}

}
