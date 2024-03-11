package ejercicio;

import java.util.Scanner;

public class Aplicacion {

	static Scanner teclado = new Scanner(System.in);
	
	public static void main(String[] args) {

		BucketS3 gestor = new BucketS3();
		
		boolean salir = false;

		while (salir == false) {
			System.out.println("#** Menú **#");
			System.out.println("1 - Crear bucket.");
			System.out.println("2 - Descomponer Quijote.");

			System.out.println("9 - Salir ");
			System.out.println("Introduce una opción");

			int opcion = teclado.nextInt();
			teclado.nextLine();
			switch (opcion) {
			case 1:
				gestor.crearBucket();
				break;
			case 2:
				gestor.descomponerQuijote();
				break;
			case 9:
				salir = true;
				break;
			}

		}

	}

}
