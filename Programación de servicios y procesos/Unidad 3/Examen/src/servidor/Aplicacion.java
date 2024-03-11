package servidor;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Aplicacion {

	public static final int PUERTO = 23432;
	public static final String[] PALABRAS = { "carroza", "musculo", "tibia", "nariz", "pierna" };

	public static void main(String[] args) throws IOException {
		try (ServerSocket servidor = new ServerSocket(PUERTO)) {
			System.out.println("Servidor iniciado en el puerto " + PUERTO);

			while (true) {
				Socket cliente = servidor.accept();
				System.out.println("Cliente conectado: " + cliente.getInetAddress());
				new GestionConexion(cliente).start();
			}
		}
	}
}