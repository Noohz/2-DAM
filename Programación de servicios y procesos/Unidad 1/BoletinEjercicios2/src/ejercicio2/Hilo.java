package ejercicio2;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Hilo extends Thread {
	private String[] rutaFicheros;
	private int totalPalabras;
	private int totalCaracteres;

	public Hilo(String[] filePaths) {
		this.rutaFicheros = filePaths;
		this.totalPalabras = 0;
		this.totalCaracteres = 0;
	}

	@Override
	public void run() {
		for (String rutaFichero : rutaFicheros) {
			int palabrasEnArchivo = 0;
			int caracteresEnArchivo = 0;

			try (BufferedReader br = new BufferedReader(new FileReader(rutaFichero))) {
				String linea;

				while ((linea = br.readLine()) != null) {
					String[] palabras = linea.split("\\s+");
					palabrasEnArchivo += palabras.length;

					for (String palabra : palabras) {
						caracteresEnArchivo += palabra.length();
					}
				}
			} catch (FileNotFoundException e) {

				System.err.println("No se ha encontrado el archivo.");

			} catch (IOException e) {

				System.err.println("Error al leer el fichero" + rutaFichero);
			}

			System.out.println("Datos del archivo: " + rutaFichero);
			System.out.println("Palabras: " + palabrasEnArchivo);
			System.out.println("Carácteres: " + caracteresEnArchivo + "\n");

			synchronized (this) {
				totalPalabras += palabrasEnArchivo;
				totalCaracteres += caracteresEnArchivo;
			}
		}
	}

	public int getTotalPalabras() {
		return totalPalabras;
	}

	public int getTotalCaracteres() {
		return totalCaracteres;
	}
}
