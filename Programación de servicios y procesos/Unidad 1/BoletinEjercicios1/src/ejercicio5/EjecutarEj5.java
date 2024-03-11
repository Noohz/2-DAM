package ejercicio5;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

public class EjecutarEj5 {

	static Scanner src = new Scanner(System.in);
	
	public static void main(String[] args) {
		String countryName = "";	
		
		System.out.print("Introduce el nombre del país en ingles:");
		countryName = src.nextLine();
		
		try {
			ProcessBuilder pb = new ProcessBuilder("java", "-cp", "bin","ejercicio5.Ejercicio5", countryName);
			Process p1 = pb.start();
			
			BufferedReader reader = new BufferedReader(new InputStreamReader(p1.getInputStream()));
            String linea;
            while ((linea = reader.readLine()) != null) {
                System.out.println(linea);
            }
            
            BufferedReader errorReader = new BufferedReader(new InputStreamReader(p1.getErrorStream()));
            String errorLine;
            while ((errorLine = errorReader.readLine()) != null) {
                System.err.println(errorLine);
            }

			
			int exitCode = p1.waitFor();
			System.exit(exitCode);
			
		} catch (IOException e) {
			
			e.printStackTrace();
			
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}
		

	}

}
