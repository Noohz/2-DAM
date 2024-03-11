package ejercicio2;

public class Ejercicio2 {

	public static void main(String[] args) {
		String[] ficheros = { "fichero1", "fichero2" };

		long iniOperacion = System.currentTimeMillis();
		
		Hilo hilo = new Hilo(ficheros);
		hilo.start();
		try {
			hilo.join();
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}

		long finOperacion = System.currentTimeMillis();
		
		System.out.println("Palabras totales en los ficheros: " + hilo.getTotalPalabras());
		System.out.println("Carácteres totales en los ficheros: " + hilo.getTotalCaracteres());
		System.out.println("Tiempo total empleado: " + (finOperacion - iniOperacion) + " milisegundos");
	}

}
