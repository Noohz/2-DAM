package servidor;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class Servidor {
	private static final int PUERTO = 22222;
	private static List<Cita> citas = new ArrayList<>();

	public static void main(String[] args) throws IOException {
		// Inicializar lista de citas
		citas.add(new Cita("Groucho Marx", "¿A quién va usted a creer, a mí o a sus propios ojos?", 1));
		citas.add(new Cita("Groucho Marx", "No puedo decir que no estoy en desacuerdo contigo", 1));
		citas.add(new Cita("Groucho Marx",
				"Those are my principles, and if you don't like them... well, I have others.", 2));
		citas.add(new Cita("Groucho Marx", "I refuse to join any club that would have me as a member.", 2));
		citas.add(new Cita("Benjamin Franklin", "Well done is better than well said", 2));
		citas.add(new Cita("Mark Twain", "Don't dream your life, live your dream", 2));
		citas.add(new Cita("Mark Twain", "The harder I work, the luckier I get", 2));
		citas.add(new Cita("Octavio Paz", "Aprender a sonreír es aprender a ser libres", 1));
		citas.add(new Cita("Hemingway", "Se necesitan dos años para aprender a hablar y sesenta para aprender a callar",
				1));
		citas.add(new Cita("Che Guevara", "Seamos realistas y hagamos lo imposible.", 1));

		// CrearServerSocket
		ServerSocket serverSocket = new ServerSocket(PUERTO);

		while (true) {
			// Aceptar conexión
			Socket socket = serverSocket.accept();

			// Crear entrada y salida
			BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
			PrintWriter salida = new PrintWriter(socket.getOutputStream(), true);

			// Atender petición
			String peticion = entrada.readLine();
			String[] partes = peticion.split("/");

			String terminoBusqueda = partes[0];
			int idioma = Integer.parseInt(partes[1]);
			String tipoRespuesta = partes[2];

			List<Cita> citasFiltradas = buscarCitas(terminoBusqueda, idioma);

			if (tipoRespuesta.equals("una")) {
				Cita citaAleatoria = citasFiltradas.get((int) (Math.random() * citasFiltradas.size()));
				salida.println(citaAleatoria.getTexto() + " (" + citaAleatoria.getAutor() + ")");
			} else if (tipoRespuesta.equals("todas")) {
				for (Cita cita : citasFiltradas) {
					salida.println(cita.getTexto() + " (" + cita.getAutor() + ")");
				}
			}

			// Cerrar socket
			socket.close();
		}
	}

	private static List<Cita> buscarCitas(String terminoBusqueda, int idioma) {
		List<Cita> citasFiltradas = new ArrayList<>();

		for (Cita cita : citas) {
			if (cita.getTexto().toLowerCase().contains(terminoBusqueda.toLowerCase())
					|| cita.getAutor().toLowerCase().contains(terminoBusqueda.toLowerCase())) {
				if (idioma == 1 && cita.getIdioma() == 1) {
					citasFiltradas.add(cita);
				} else if (idioma == 2 && cita.getIdioma() == 2) {
					citasFiltradas.add(cita);
				} else if (idioma == 0) {
					citasFiltradas.add(cita);
				}
			}
		}

		return citasFiltradas;
	}
}
