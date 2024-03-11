package servidor;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Random;

public class Aplicacion {

	public static ArrayList<String> arrayAlicia = new ArrayList<String>();

	public static void main(String[] args) {

		int puerto = 12345;

		try (ServerSocket servidor = new ServerSocket(puerto)) {
			System.out.println("Servidor a la espera ");
			cargarLibro();

			while (true) {
				Socket cliente = servidor.accept();
				System.out.println("Cliente conectado");
				new GestionConexion(cliente).start();
			}
		} catch (IOException e) {

			e.printStackTrace();
		}
	}

	public static void cargarLibro() {
		try {
			BufferedReader br = new BufferedReader(new FileReader("Alicia.txt"));
			String linea;
			while ((linea = br.readLine()) != null) {
				arrayAlicia.add(linea);
			}
			br.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}