/*
 * Lanza la calculadora tanto en Ubuntu como en Windows.
 * A continuación, comprueba los datos del proceso creado tanto con las aplicaciones gráficas como con el terminal de consola de ambos sistemas. 
 */

package ejercicio1;

import java.io.IOException;
import java.util.Scanner;

public class Ejercicio1 {

	static Scanner sc = new Scanner(System.in);
	
	public static void main(String[] args) {
		
		int menu = 0;
		
		do {
			
			System.out.println("Selecciona tu Sistema Operativo o introduce 0 para salir del programa.");
			System.out.println("0 - Salir");
			System.out.println("1 - Windows");
			System.out.println("2 - Ubuntu");

			menu = sc.nextInt();
			sc.nextLine();

			switch (menu) {
			case 1:
				calcWindows();
				break;
			case 2:
				calcUbuntu();
				break;

			}
			
		} while (menu != 0);

	}

	private static void calcUbuntu() {

		try {
			Runtime.getRuntime().exec("gnome-calculator");
			
		} catch (IOException e) {
			System.err.println("Ha ocurrido una excepción.");
			e.printStackTrace();
		}
	}

	private static void calcWindows() {
		
		try {
			Runtime.getRuntime().exec("calc");
			
		} catch (IOException e) {
			System.err.println("Ha ocurrido una excepción.");
			e.printStackTrace();
		}
		
	}

}
