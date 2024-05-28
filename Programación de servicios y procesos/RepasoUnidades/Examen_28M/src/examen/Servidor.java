package examen;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {

	static final int PUERTO = 11211;

	public static void main(String[] args) {
		ServerSocket servidor = null;

		try {
			servidor = new ServerSocket(PUERTO);

			while (true) {
				System.out.println("El servidor está a la escucha.");
				Socket socketCliente = servidor.accept();

				System.out.println("Se ha establecido la conexión con el cliente.");
				Thread hilo = new Thread(new Gestor(socketCliente));
				hilo.start();
			}

		} catch (IOException e) {
			e.printStackTrace();
		} finally {

			if (servidor != null) {
				try {
					servidor.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}

}
