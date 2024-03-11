package examen;

import java.util.Scanner;

public class Principal {

	static Scanner src = new Scanner(System.in);

	public static void main(String[] args) {

		GestorEmbalses gestor = new GestorEmbalses();

		gestor.cargarFichero();

		if (gestor.arrayEmbalse.isEmpty()) {

		} else {
			System.out.println("#** Embalses actuales ** #");
			System.out.println("*******************************************************************");
			gestor.mostrarEmbalses();
			System.out.println("*******************************************************************");
		}

		int opcion = 0;

		do {

			System.out.println("#** Menú **#");
			System.out.println("1.- Añadir embalse.");
			System.out.println("2.- Borrar embalse.");
			System.out.println("3.- Mostrar estado embalse.");
			System.out.println("4.- Mostrar estado embalses por provincia.");
			System.out.println("5.- Mostrar estado embalses por confederación hidrográfica.");
			System.out.println("6.- Modificar nivel embalse.");
			System.out.println("7.- Salir.");
			System.out.print("Introduce una opción:");
			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				gestor.aniadirEmbalse();
				break;
			case 2:
				gestor.borrarEmbalse();
				break;
			case 3:
				System.out.println("*******************************************************************");
				gestor.mostrarEmbalses();
				System.out.println("*******************************************************************");
				break;
			case 4:
				gestor.mostrarEmbalsesPorProvincia();
				break;
			case 5:
				gestor.mostrarEmbalsesPorConfederacion();
				break;
			case 6:
				gestor.modificarNivelEmbalse();
				break;
			case 7:
				break;
			}

		} while (opcion != 7);
		src.close();
	}

}
