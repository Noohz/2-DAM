package ejercicio3;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ContadorDeCaracteres {
	public static void main(String[] args) {
		if (args.length != 2) {
			System.err.println("Uso: java ContadorDeCaracteres <ruta_del_fichero> <caracter>");
			System.exit(-1);
		}

		String rutaDelFichero = args[0];
		char caracter = args[1].charAt(0);
		int count = 0;

		try (BufferedReader reader = new BufferedReader(new FileReader(rutaDelFichero))) {
			int c;
			while ((c = reader.read()) != -1) {
				if (Character.toLowerCase((char) c) == Character.toLowerCase(caracter)) {
					count++;
				}
			}
			System.out.println("El carácter '" + caracter + "' aparece " + count + " veces en el fichero.");
			System.exit(0);
		} catch (IOException e) {
			System.err.println("Error al leer el fichero: " + e.getMessage());
			System.exit(-1);
		}
	}
}
