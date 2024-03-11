package cliente;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class Cliente {
	private static final String HOST = "localhost";
	private static final int PUERTO = 22222;

	public static void main(String[] args) throws IOException {
		// Leer entrada del usuario
		BufferedReader entradaUsuario = new BufferedReader(new InputStreamReader(System.in));

		System.out.println("Introduzca el término de búsqueda: ");
		String terminoBusqueda = entradaUsuario.readLine();

		System.out.println("Introduzca el idioma (0: Todos, 1: Español, 2: Inglés): ");
		int idioma = Integer.parseInt(entradaUsuario.readLine());

		System.out.println("Introduzca el tipo de respuesta (una/todas): ");
		String tipoRespuesta = entradaUsuario.readLine();

		// Crear socket y conectar con el servidor
		Socket socket = new Socket(HOST, PUERTO);

		// Crear entrada y salida
		BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
		PrintWriter salida = new PrintWriter(socket.getOutputStream(), true);

		// Enviar petición
		String peticion = terminoBusqueda + "/" + idioma + "/" + tipoRespuesta;
		salida.println(peticion);

		// Recibir respuesta
		String respuesta;
		while ((respuesta = entrada.readLine()) != null) {
			System.out.println(respuesta);
		}

		// Cerrar socket
		socket.close();
	}
}
