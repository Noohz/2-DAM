package ejercicio1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

public class VariablesEntornoSistema {

	static Scanner src = new Scanner(System.in);

	public static void main(String[] args) {
		int opcion;

		do {

			System.out.println("# Menú #");
			System.out.println("1. - Mostrar todas las variables de entorno.");
			System.out.println("2. - Mostrar el valor de la variable X.");
			System.out.println("3. - Asignar el valor de la variable X.");
			System.out.println("4. - Salir");
			System.out.println("Selecciona una opción.");
			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				mostrarVariablesEntorno();
				break;
			case 2:
				System.out.print("Introduce el nombre de la variable de entorno: ");
				String variableEntorno = src.nextLine();
				mostrarVariableX(variableEntorno);
				break;
			case 3:
				System.out.print("Introduce el nombre de la variable de entorno: ");
				String variableEntorno2 = src.nextLine();

				System.out.print("Introduce el valor de la variable: ");
				String valorVariableEntorno2 = src.nextLine();

				asignarValorVariable(variableEntorno2, valorVariableEntorno2);
				break;
			case 4:
				break;
			default:
				System.err.println("Has introducido una opción incorrecta.");
			}

		} while (opcion != 4);
		src.close();

	}

	private static void asignarValorVariable(String variableEntorno2, String valorVariableEntorno2) {

		try {
			ProcessBuilder comando = new ProcessBuilder("CMD", "/C",
					"SET " + variableEntorno2 + "=" + valorVariableEntorno2);
			Process p1 = comando.start();
			int codigoSalida = p1.waitFor();

			BufferedReader reader = new BufferedReader(new InputStreamReader(p1.getInputStream()));
	        String line;
	        while ((line = reader.readLine()) != null) {
	            System.out.println(line);
	        }
			
			if (codigoSalida != 0) {
				System.err.println("Ha ocurrido un error.");
				System.out.println("El programa ha devuelto el código de salida: " + codigoSalida);
			}

		} catch (IOException | InterruptedException e) {

			e.printStackTrace();
		}

	}

	private static void mostrarVariableX(String variableEntorno) {
		System.out.println("#** Datos de la variable de entorno " + variableEntorno + " **#");

		try {
			ProcessBuilder comando = new ProcessBuilder("CMD", "/C", "SET " + variableEntorno);
			Process p1 = comando.start();
			int codigoSalida = p1.waitFor();

			BufferedReader reader = new BufferedReader(new InputStreamReader(p1.getInputStream()));
	        String line;
	        while ((line = reader.readLine()) != null) {
	            System.out.println(line);
	        }
			
			if (codigoSalida != 0) {
				System.err.println("La variable introducida no ha sido encontrada.");
				System.out.println("El programa ha devuelto el código de salida: " + codigoSalida);
			}

		} catch (IOException e) {

			e.printStackTrace();
		} catch (InterruptedException e) {

			e.printStackTrace();
		}

	}

	private static void mostrarVariablesEntorno() {
		System.out.println("#** Datos de las variables de entorno **#");

		try {
			ProcessBuilder comando = new ProcessBuilder("CMD", "/C", "SET");
			Process p1 = comando.start();
			int codigoSalida = p1.waitFor();

			BufferedReader reader = new BufferedReader(new InputStreamReader(p1.getInputStream()));
	        String line;
	        while ((line = reader.readLine()) != null) {
	            System.out.println(line);
	        }
			
			if (codigoSalida != 0) {
				System.err.println("Ha ocurrido un error.");
				System.err.println("El programa ha devuelto el código de salida: " + codigoSalida);
			}

		} catch (IOException e) {

			e.printStackTrace();
		} catch (InterruptedException e) {

			e.printStackTrace();
		}

	}

}
