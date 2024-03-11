package ejercicio4;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Ejercicio4 {

	static Scanner src = new Scanner(System.in);

	public static void main(String[] args) {

		int opcion = 0;

		try {
			do {
				System.out.println("1 - Comprobar palindromo");
				System.out.println("2 - Salir");
				opcion = src.nextInt();
				src.nextLine();

				switch (opcion) {
				case 1:
					System.out.println("Introduce la frase");
					String frase = src.nextLine();

					if (comprobarPalindromo(frase)) {
						System.out.println("La frase que has introducido es un palindromo.\n");
					} else {
						System.err.println("La frase que has introducido no es un palindromo.\n");
					}
					break;
				case 2:
					break;
				default:
					System.err.println("El valor '" + opcion + "' que has introducido no es válido.\n");
				}
			} while (opcion != 2);
		} catch (InputMismatchException e) {
			System.err.println("El carácter que has introducido no es válido");
		}
	}

	private static boolean comprobarPalindromo(String frase) {

		frase = frase.toLowerCase();
		String cadenaInvertida = "";

		char caracter;
		for (int i = frase.length() - 1; i >= 0; i--) {
			caracter = frase.charAt(i);
			cadenaInvertida += caracter;
		}

		if (frase.equalsIgnoreCase(cadenaInvertida)) {
			return true;
		} else {
			return false;
		}
	}

}
