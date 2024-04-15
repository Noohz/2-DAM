package MisClases;

import java.io.BufferedReader;
import java.io.IOException;

public class Hilo2 extends Thread {

	BufferedReader bf;
	Contador contador;

	Hilo2(BufferedReader bf, Contador contadorEspacios) {
		this.bf = bf;
		this.contador = contadorEspacios;
	}

	public void run() {

		// Vamos leyendo las líneas del BufferedReader de forma organizada.
		String linea;
		while ((linea = leerLinea()) != null) {

			// Cuento cuántos espacios hay en la línea
			for (int i = 0; i < linea.length(); i++) {
				if (linea.charAt(i) == ' ') {
					contador.incrementarContador();
				}

			}
		}

	}

	private synchronized String leerLinea() {
		String resultado = null;

		try {
			resultado = bf.readLine();
		} catch (IOException e) {

			e.printStackTrace();
		}
		return resultado;
	}

}
