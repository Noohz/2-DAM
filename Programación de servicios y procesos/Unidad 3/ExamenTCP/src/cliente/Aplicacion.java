package cliente;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class Aplicacion {

	public static void main(String[] args) throws IOException {

		int puerto = 12345;
		String servidor = "localhost";
		Socket cliente = new Socket(servidor, puerto);

		Scanner src = new Scanner(System.in);
		int lineaInicial;
		int lineaFinal;
		String palabraABuscar;

		BufferedReader entrada = new BufferedReader(new InputStreamReader(cliente.getInputStream()));
		PrintWriter salida = new PrintWriter(cliente.getOutputStream(), true);
		BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));

		while (true) {
			System.out.println("1 - Solicitar línea fichero.");
			System.out.println("2 - Solicitar líneas fichero.");
			System.out.println("3 - Obtener número de veces que aparece la palabra.");
			System.out.println("4 - Salir.");

			int opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				System.out.println("Introduce el número de línea:");
				int numLinea = Integer.parseInt(teclado.readLine());

				salida.println(numLinea);
				String respuesta1 = entrada.readLine();
				System.out.println(respuesta1);

				break;
			case 2:
				System.out.println("Introduce el número de línea inicial:");
				lineaInicial = Integer.parseInt(teclado.readLine());

				System.out.println("Introduce el número de líneas:");
				lineaFinal = Integer.parseInt(teclado.readLine());

				salida.println("Lineas/" + lineaInicial + "/" + lineaFinal);
				recibirMensaje(entrada);

				break;
			case 3:
				System.out.println("Introduce la palabra a buscar");
				palabraABuscar = teclado.readLine();
				
				salida.println("NumVecesPalabra/" + palabraABuscar);
				
				
				break;
			case 4:
				break;
			}

			if (opcion == 4) {
				break;
			}

		}
	}

	private static void recibirMensaje(BufferedReader entrada) throws IOException {
		String linea;
		while ((linea = entrada.readLine()) != null) {
			if (linea.equals("FinalEnvio")) {
				break;
			}
			System.out.println(linea);
		}
	}
}