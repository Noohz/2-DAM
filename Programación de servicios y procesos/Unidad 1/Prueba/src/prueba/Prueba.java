package prueba;

import java.io.IOException;
import java.io.InputStream;

public class Prueba {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		Process pr;
		Process pr2;

		int codSalida = 0;
		// Lanzamos un proceso con RunTime
		try {
			// Variante 1
			String[] ar = { "notepad.exe", "hola.txt" };
			// Runtime.getRuntime().exec(ar);

			// Variante 2
			// Runtime.getRuntime().exec("notepad.exe", "hola.txt");

			// Como lanzar un proceso con ProcessBuilder.
			ProcessBuilder pb = new ProcessBuilder("CMD", "/C", "DIR", "C:\\");
			pr = pb.start();

			InputStream is = pr.getInputStream();

			int caracter;
			while ((caracter = is.read()) != -1) {
				System.out.print((char) caracter);
			}

		} catch (IOException ex) {
			System.err.println("Ha habido una excepción.");
		}

		System.out.println("He terminado con el código de salida: " + codSalida);
	}
}
