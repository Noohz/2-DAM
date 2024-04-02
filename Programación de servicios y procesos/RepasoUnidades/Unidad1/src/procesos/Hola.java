package procesos;

import java.io.IOException;
import java.io.InputStream;

public class Hola {

	public static void main(String[] args) {
		
		try {
			ProcessBuilder pb = new ProcessBuilder("CMD", "/C", "dir", "C:");
			Process p1 = pb.start();
			p1.getInputStream(); // Esto permite recoger la salida de información que devuelve el proceso.
						
			int codigoSalida = p1.waitFor();

			if (codigoSalida == 0) {
				System.out.println("Todo se ejecutó correctamente");
			} else {
				InputStream is = p1.getErrorStream(); // Esto permite recoger la salida de errores que devuelve el proceso.
				System.err.println(is);
			}

		} catch (IOException e) {

			e.printStackTrace();

		} catch (InterruptedException e) {

			e.printStackTrace();
		}

	}

}
