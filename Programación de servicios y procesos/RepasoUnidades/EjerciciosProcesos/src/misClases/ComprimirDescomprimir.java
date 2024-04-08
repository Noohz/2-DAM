package misClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Scanner;

public class ComprimirDescomprimir {

	static Scanner src = new Scanner(System.in);
	public static void main(String[] args) {

		int opcion = 0;
		boolean salir = false;

		while (salir == false) {
			System.out.println("# Menú #");
			System.out.println("1. - Comprimir archivo.");
			System.out.println("2. - Descomprimir archivo.");
			System.out.println("3. - Salir");
			System.out.println("Selecciona una opción.");
			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				comprimirArchivo();
				break;
			case 2:
				descomprimirArchivo();
				break;
			case 3:
				salir = true;
				break;
			default:
				System.err.println("Has introducido una opción incorrecta.");
			}
		}

	}
	private static void descomprimirArchivo() {
		System.out.println("Introduce la ruta y el nombre del archivo comprimido");
		String ruta = src.nextLine();
		
		System.out.println("Introduzca la ruta para descomprimir el archivo.");
        String destino = src.nextLine();
		
        ProcessBuilder pb = new ProcessBuilder("tar", "-xvf", ruta, destino);
        try {
			Process p1 = pb.start();
			
			int codSalida = p1.waitFor();
			
			if (codSalida == 0) {
				InputStream inputStream = p1.getInputStream();
				BufferedReader br = new BufferedReader(new InputStreamReader(inputStream));
				
				String linea;
				while ((linea = br.readLine()) != null) {
					System.out.println(linea);
				}
			} else {
				InputStream errorStream = p1.getErrorStream();
				BufferedReader br = new BufferedReader(new InputStreamReader(errorStream));
				
				String linea;
				while ((linea = br.readLine()) != null) {
					System.out.println(linea);
				}
			}
			
		} catch (IOException e) {
			
			e.printStackTrace();
			
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}
        
	}
	
	private static void comprimirArchivo() {
		System.out.println("Introduce la ruta y el nombre para el archivo comprimido");
		String ruta = src.nextLine();
		
		System.out.println("Introduzca la ruta del fichero a comprimir");
        String destino = src.nextLine();
		
        ProcessBuilder pb = new ProcessBuilder("tar", "-cvf", ruta, destino);
        try {
			Process p1 = pb.start();
			
			int codSalida = p1.waitFor();
			
			if (codSalida == 0) {
				System.out.println("Operación completada correctamente.\n");
				InputStream inputStream = p1.getInputStream();
				BufferedReader br = new BufferedReader(new InputStreamReader(inputStream));
				
				String linea;
				while ((linea = br.readLine()) != null) {
					System.out.println(linea);
				}
			} else {
				InputStream errorStream = p1.getErrorStream();
				BufferedReader br = new BufferedReader(new InputStreamReader(errorStream));
				
				String linea;
				while ((linea = br.readLine()) != null) {
					System.out.println(linea);
				}
			}
			
		} catch (IOException e) {
			
			e.printStackTrace();
			
		} catch (InterruptedException e) {
			
			e.printStackTrace();
		}
	}

}
