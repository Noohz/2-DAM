package juego;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {
	private static final int PUERTO = 23432;

	public static void main(String[] args) {
		ServerSocket socketServidor = null;	

		try {
			// Se crea el socket del servidor en el puerto 23432.
			socketServidor = new ServerSocket(PUERTO);
			System.out.println("Servidor escuchando en el puerto: " + socketServidor.getLocalPort());

			while (true) {
				Socket socketCliente = null;
				socketCliente = socketServidor.accept();
				System.out.println("Cliente conectado desde: " + socketCliente.getInetAddress());
				Hilo hilo = new Hilo(socketCliente);
				hilo.start();
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (socketServidor != null) {
				try {
					socketServidor.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}

}
