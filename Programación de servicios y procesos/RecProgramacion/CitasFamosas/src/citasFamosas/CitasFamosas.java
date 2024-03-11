package citasFamosas;

import java.util.Scanner;

public class CitasFamosas {

	static Scanner src = new Scanner(System.in);
	
	public static void main(String[] args) {
		GestorCitas gestor = new GestorCitas();
		
		gestor.cargarFichero();
		System.out.println("#** Citas actuales almacenadas en citas.dat **#");
		gestor.mostrarCitas();
		
		int opcion = 0;

		do {
			System.out.println("\n#** Menú **#");
			System.out.println("1 - Añadir cita.");
			System.out.println("2 - Modificar cita.");
			System.out.println("3 - Borrar cita.");
			System.out.println("4 - Buscar cita.");
			System.out.println("5 - Salir.");
			System.out.println("Selecciona una opción");
			
			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				gestor.aniadirCita();
				break;
			case 2:
				gestor.modificarCita();
				break;
			case 3:
				gestor.borrarCita();
				break;
			case 4:
				gestor.buscarCita();
				break;
			}
		} while (opcion != 5);
		src.close();
	}
}
