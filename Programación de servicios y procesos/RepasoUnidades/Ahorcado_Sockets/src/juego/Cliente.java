package juego;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

public class Cliente {
	private static final String SERVIDOR = "localhost";
	private static final int PUERTO = 23432;

	public static void main(String[] args) {
		Socket socketCliente = null;
		try {
			socketCliente = new Socket(SERVIDOR, PUERTO);
			BufferedReader in = new BufferedReader(new InputStreamReader(socketCliente.getInputStream()));
			PrintWriter out = new PrintWriter(socketCliente.getOutputStream());

			
			// Me quedo escuchando hasta que el servidor me mande la trama inicial
			String trama=in.readLine();
			String[] partes=trama.split("\t");
			
			// Muestro el estado inicial de la palabra
			System.out.println("Número de fallos actual : " + partes[1]);			
			System.out.println("Palabra a a adivinar : " + partes[2]);
			
			
			boolean salir=false;
			while(salir==false) {
				
			}
			
			

		} catch (UnknownHostException e) {
			System.err.println("Error, no se ha encontrado el servidor...");
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (socketCliente != null) {
				try {
					socketCliente.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}
}
