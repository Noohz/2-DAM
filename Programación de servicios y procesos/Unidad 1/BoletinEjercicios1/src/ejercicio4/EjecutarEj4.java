package ejercicio4;

import java.io.IOException;

public class EjecutarEj4 {

	public static void main(String[] args) {
		
		try {
			ProcessBuilder pb = new ProcessBuilder("java", "Ejercicio4");
			Process p1 = pb.start();
			
			int exitCode = p1.waitFor();
						
			System.exit(exitCode);
			
		} catch (IOException e) {
			
			System.err.println("Error al intentar ejecutar el programa Ejercicio4");
			
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}

	}

}
