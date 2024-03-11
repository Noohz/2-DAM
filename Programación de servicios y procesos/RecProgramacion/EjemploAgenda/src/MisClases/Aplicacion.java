package MisClases;

import java.util.Scanner;

public class Aplicacion {

	static Scanner teclado = new Scanner(System.in);

	public static void main(String[] args) {
		GestorLista gestor;
		gestor = new GestorLista();

		// Leemos el contenido de la agenda del disco.
		gestor.leerAgendaDisco();
		
		boolean salir = false;

		while (salir == false) {
			System.out.println("#** Menú ** #");
			System.out.println("1.- Añadir entrada");
			System.out.println("2.- Borrar entrada");
			System.out.println("3.- Modificar entrada");
			System.out.println("4.- Mostrar contenido");
			System.out.println("5.- Buscar entradas");
			System.out.println("9.- Salir");

			System.out.println("Selecciona una opción");

			int opcion = teclado.nextInt();
			teclado.nextLine();

			switch (opcion) {
			case 1:
				gestor.añadirEntrada();
				break;
			case 2:
				gestor.borrarEntrada();
				break;
			case 3:
				gestor.modificarEntrada();
				break;
			case 4:
				gestor.mostrarContenido();
				break;
			case 5:
				gestor.buscarContenido();
				break;
			case 9:
				salir = true;
				break;
			}

		}

		// Escribimos en disco el contenido de la agenda
		gestor.escribirAgendaDisco();
	}

}
