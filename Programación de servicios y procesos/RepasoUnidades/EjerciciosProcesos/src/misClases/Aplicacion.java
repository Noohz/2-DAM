package misClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Scanner;

public class Aplicacion {

	static Scanner teclado = new Scanner(System.in);

	public static void main(String[] args) {

		boolean salir = false;

		while (salir == false) {
			System.out.println("1 - Aplicar Hash a fichero.");
			System.out.println("2 - Salir.");

			int opcion = teclado.nextInt();
			teclado.nextLine();

			switch (opcion) {
			case 1:
				calcularHash();
				break;
			case 2:
				salir = true;
				break;
			default:
				System.err.println("Opción no válida.");
			}
		}
		teclado.close();
	}

	private static void calcularHash() {
		// Le pedimos al usuario el fichero sobre el que pasar el hash.
		System.out.println("Introduce la ruta del fichero.");
		String ruta = teclado.nextLine();

		System.out.println("Introduce el algoritmo que quieres aplicar.");
		String algoritmo = teclado.nextLine();

		// Creamos una instancia de ProcessBuilder con los datos del proceso.
		ProcessBuilder pb = new ProcessBuilder("CertUtil", "-hashfile", "\"" + ruta + "\"", algoritmo);

		// Lanzamos el proceso.
		try {
			Process proceso = pb.start();

			// Esperamos a que el proceso termine de hacer su tarea.
			int codSalida = proceso.waitFor();

			if (codSalida == 0) {
				// El proceso se ejecutó correctamente.
				InputStream inputStream = proceso.getInputStream();
				BufferedReader lectorInput = new BufferedReader(new InputStreamReader(inputStream));

				String linea;
				int numLinea = 0;
				while ((linea = lectorInput.readLine()) != null) {
					numLinea++;

					if (numLinea == 2) {
						System.out.println(algoritmo + " - " + linea);
						break;
					}
				}
			} else {
				// Hubo alguna incidencia en la ejecución.
				InputStream errorStream = proceso.getInputStream(); // En este caso el CertUtil no devuelve el error a través del getErrorStream si no que utiliza el getInputStream.
				BufferedReader lectorErrores = new BufferedReader(new InputStreamReader(errorStream));

				String linea;
				while ((linea = lectorErrores.readLine()) != null) {
					System.out.println(linea);
				}
			}

		} catch (IOException e) {

			e.printStackTrace();
		} catch (InterruptedException e) {

			e.printStackTrace();
		}
	}

}
