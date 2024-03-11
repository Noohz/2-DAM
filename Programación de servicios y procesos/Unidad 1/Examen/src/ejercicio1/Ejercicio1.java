package ejercicio1;

import java.io.IOException;
import java.util.Scanner;

public class Ejercicio1 {

	static Scanner src = new Scanner(System.in);

	public static void main(String[] args) {

		int opcion;

		do {

			System.out.println("# Menú #");
			System.out.println("1. - Comprimir archivo.");
			System.out.println("2. - Descomprimir archivo.");
			System.out.println("3. - Salir");
			System.out.println("Selecciona una opción.");
			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				comprimirArchivo();
				break;
			case 2:
				descomprimirArchivo();
				break;
			case 3:
				break;
			default:
				System.err.println("Has introducido una opción incorrecta.");
			}

		} while (opcion != 3);
		src.close();

	}

	private static void descomprimirArchivo() {
		System.out.println("Introduce la ruta del archivo a descomprimir");
		System.out.println("PJ: C:\\usr\\archivo.txt");
		System.out.print("Ruta / Archivo: ");
		String rutaArchivo = src.nextLine();
		
		System.out.print("Introduzca la ruta de destino para la descompresión: ");
        String destino = src.nextLine();

		try {
            Process process = Runtime.getRuntime().exec("tar -xvf " + rutaArchivo + " -C " + destino);
            int exitCode = process.waitFor();
            if (exitCode == 0) {
                System.out.println("Archivo comprimido descomprimido exitosamente.");
            } else {
                System.out.println("Error al descomprimir el archivo comprimido. Código de salida: " + exitCode);
            }
        } catch (IOException | InterruptedException e) {
            System.out.println("Error al descomprimir el archivo comprimido: " + e.getMessage());
        }

	}

	private static void comprimirArchivo() {
		System.out.println("Introduce la ruta del archivo a comprimir");
		System.out.println("PJ: C:\\usr\\archivo.txt");
		System.out.print("Ruta / Archivo: ");
		String rutaArchivo = src.nextLine();
		
		System.out.print("Introduzca la ruta de destino para la compresión (*SI LO DEJAS VACÍO SE EXTRAE EN LA PROPIA CARPETA*): ");
        String destino = src.nextLine();

		try {
			Process process = Runtime.getRuntime().exec("tar -cvf " + destino + "archivoComprimido.tar " + rutaArchivo);
            int exitCode = process.waitFor();
            if (exitCode == 0) {
                System.out.println("Archivo o carpeta comprimido exitosamente.");
            } else {
                System.out.println("Error al comprimir el archivo o carpeta. Código de salida: " + exitCode);
            }
        } catch (IOException | InterruptedException e) {
            System.out.println("Error al comprimir el archivo o carpeta: " + e.getMessage());
        }
	}

}
