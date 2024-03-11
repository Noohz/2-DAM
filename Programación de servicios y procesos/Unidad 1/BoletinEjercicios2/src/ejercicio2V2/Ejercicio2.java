package ejercicio2V2;

public class Ejercicio2 {

	public static void main(String[] args) {
		String[] ficheros = { "fichero1", "fichero2" };
		int totalPalabras = 0;
		int totalCaracteres = 0;

		long iniOperacion = System.currentTimeMillis();

		Hilo[] hilo = new Hilo[ficheros.length];

		for (int i = 0; i < ficheros.length; i++) {
			hilo[i] = new Hilo(ficheros[i]);
			hilo[i].start();
			try {
				hilo[i].join();
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
		}

		for (Hilo calcularPalabras : hilo) {
			totalPalabras += calcularPalabras.getTotalPalabras();
			totalCaracteres += calcularPalabras.getTotalCaracteres();
		}

		long finOperacion = System.currentTimeMillis();

		System.out.println("Palabras totales en los ficheros: " + totalPalabras);
		System.out.println("Carácteres totales en los ficheros: " + totalCaracteres);
		System.out.println("Tiempo total empleado: " + (finOperacion - iniOperacion) + " milisegundos");
	}

}
