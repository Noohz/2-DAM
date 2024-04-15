package MisClases;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Aplicacion {

	final static int NUM_HILOS = 10;

	public static void main(String[] args) {
		ejercicio2();
		ejercicio3();

	}

	static void ejercicio2() {
		Hilo[] hilos = new Hilo[NUM_HILOS];

		// Creo el objeto que controlará el máximo.
		ContadorMaximo maximo = new ContadorMaximo();

		for (int i = 0; i < NUM_HILOS; i++) {
			// Crear el hilo.
			hilos[i] = new Hilo(maximo);

			// Poner en marcha el hilo.
			hilos[i].start();
		}

		// Esperamos a que todos los hilos hayan terminado.
		for (int i = 0; i < NUM_HILOS; i++) {
			try {
				hilos[i].join();
			} catch (InterruptedException e) {

				e.printStackTrace();
			}
		}

		// Muestro el máximo obtenido.
		System.out.println("El máximo obtenido ha sido: " + maximo.getMaximo());

	}

	static void ejercicio3() {

		Hilo2[] hilos = new Hilo2[NUM_HILOS];

		String rutaFichero = "C:\\Ejemplos\\quijote.txt";
		FileReader fichero = null;
		BufferedReader bf = null;

		// Creo el objeto contador que compartirán los hilos.
		Contador contadorEspacios = new Contador();

		try {
			int numVeces = 0;
			// Leemos el fichero que le indiquemos línea a línea.
			fichero = new FileReader(rutaFichero);

			// Usamos un bufferedReader para procesarlo más fácilmente.
			bf = new BufferedReader(fichero);

			// Creamos los hilos y los ponemos en marcha.
			for (int i = 0; i < NUM_HILOS; i++) {
				hilos[i] = new Hilo2(bf, contadorEspacios);
				hilos[i].start();
			}

			// Esperamos a que los hilos terminen de hacer su trabajo.
			for (int i = 0; i < NUM_HILOS; i++) {
				hilos[i].join();
			}
			
			System.out.println("El número resultante es: " + contadorEspacios.getContador());

		} catch (FileNotFoundException e) {
			e.printStackTrace();
			
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		} finally {
			if (bf != null) {
				try {
					bf.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

	}
}
