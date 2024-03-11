package ejercicio3;

import java.util.Scanner;

public class ContadorDeVocales {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.print("Introduce la ruta del fichero de texto: ");
		String rutaDelFichero = scanner.nextLine();
		scanner.close();

		try {
			// Invocar la primera aplicación para contar las vocales
			Process proceso = Runtime.getRuntime().exec("java ContadorDeCaracteres " + rutaDelFichero + " a");
			proceso.waitFor();

			// Recuperar la salida estándar del proceso
			Scanner resultadoScanner = new Scanner(proceso.getInputStream());
			int totalVocales = 0;
			char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

			while (resultadoScanner.hasNextLine()) {
				String linea = resultadoScanner.nextLine();
				int apariciones = Integer.parseInt(linea.split(" ")[5]);
				totalVocales += apariciones;
			}

			resultadoScanner.close();

			// Imprimir el resultado
			System.out.println("Total de vocales en el fichero: " + totalVocales);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
