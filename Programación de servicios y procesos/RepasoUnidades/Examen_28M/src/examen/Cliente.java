package examen;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Cliente {

	static final int PUERTO = 11211;
	static final String SERVIDOR = "localhost";

	public static boolean deboFinalizar = false;
	static Scanner teclado = new Scanner(System.in);

	public static void main(String[] args) {
		Socket socket = null;
		OutputStream os = null;
		BufferedReader lectorDatos = null;
		InputStream is = null;

		try {
			socket = new Socket(SERVIDOR, PUERTO);

			os = socket.getOutputStream();
			is = socket.getInputStream();
			InputStreamReader inputStreamReader = new InputStreamReader(is);
			lectorDatos = new BufferedReader(inputStreamReader);

			boolean deboFinalizar = false;
			while (!deboFinalizar) {
				System.out.println("1 - Juego global");
				System.out.println("2 - Juego por continente");
				System.out.println("3 - Salir");
				int opcion = teclado.nextInt();
				teclado.nextLine();

				if (opcion == 1) {
					System.out.println("Introduce el número de preguntas a contestar (Entre 5 y 10): ");
					int numPreguntas = teclado.nextInt();
					teclado.nextLine();

					mandarMensajeServidor(os, lectorDatos, "JuegoGlobal \t" + numPreguntas + "\n", true);

				} else if (opcion == 2) {
					System.out.println("Introduce el número de preguntas a contestar (Entre 5 y 10): ");
					int numPreguntas = teclado.nextInt();
					teclado.nextLine();

					System.out.println("Introduce el continente con el que deseas jugar: ");
					String continente = teclado.nextLine();

					mandarMensajeServidor(os, lectorDatos,
							"JuegoContinente \t" + numPreguntas + "\t" + continente + "\n", true);
				} else {
					deboFinalizar = true;
				}
			}

			mandarMensajeServidor(os, lectorDatos, "Final\n", false);

		} catch (UnknownHostException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} finally {

			if (os != null)
				try {
					os.close();
				} catch (IOException e) {

					e.printStackTrace();
				}

			if (lectorDatos != null)
				try {
					lectorDatos.close();
				} catch (IOException e) {

					e.printStackTrace();
				}

			if (socket != null)
				try {
					socket.close();
				} catch (IOException e) {

					e.printStackTrace();
				}

			if (teclado != null)
				teclado.close();
		}

	}

	public static String mandarMensajeServidor(OutputStream os, BufferedReader lectorDatos, String mensaje,
			boolean esperarRespuesta) {
		try {
			os.write((mensaje).getBytes());

			if (esperarRespuesta == true) {
				String linea = leerRespuestaServidor(lectorDatos);
				if (linea != null)
					tratarMensajeServidor(os, lectorDatos, linea);
				return linea;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}

	private static void tratarMensajeServidor(OutputStream os, BufferedReader lectorDatos, String linea) {

		String[] partes = linea.split("\t");

		if (partes[0].equals("Pregunta")) {

		}
	}

	private static String leerRespuestaServidor(BufferedReader lectorDatos) {
		String linea = null;
		try {
			while ((linea = lectorDatos.readLine()) != null) {
				break;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		return linea;
	}
}