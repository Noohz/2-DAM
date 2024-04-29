package skills;

import java.util.ArrayList;
import java.util.Scanner;

public class Principal {

	public static Scanner tec = new Scanner(System.in);
	public static Modelo modelo = new Modelo();

	public static void main(String[] args) {
		int opc = -1;

		if (modelo.getConexion() != null) {
			do {
				System.out.println("---------------MENU--------------");
				System.out.println("0 - Salir del programa.");
				System.out.println("1 - Alta Alumno / Modalidad.");
				System.out.println("2 - Crear Prueba.");
				System.out.println("3 - Registrar Corrección.");
				System.out.println("4 - Mostrar Ganadores.");
				System.out.println("Seleccione una opción: ");
				opc = tec.nextInt();
				tec.nextLine();
				System.out.println("---------------------------------");

				switch (opc) {
				case 1:
					ejercicio1();
					break;
				case 2:
					ejercicio2();
					break;
				case 3:
					ejercicio3();
					;
					break;
				case 4:
					ejercicio4();
					break;
				}
			} while (opc != 0);
			modelo.cerrar();
		}

	}

	private static void ejercicio4() {

	}

	private static void ejercicio3() {

	}

	private static void ejercicio2() {

	}

	private static void ejercicio1() {
		System.out.println("Introduce tu DNI: ");
		String dni = tec.nextLine();

		Alumno alumno = modelo.obtenerAlumno(dni);

		if (alumno != null) {
			System.err.println("Error, el alumno ya existe en la modalidad: " + alumno.getModalidad().getModalidad());
		} else {
			mostrarModalidades();
			
			System.out.println("Introduce el id de la modalidad (0 - Para crear una nueva): ");
			int opc = tec.nextInt();
			tec.nextLine();
			
			if (opc == 0) {
				// Crear modalidad.
				
			}
			// Crear alumno.
		}

	}

	private static void mostrarModalidades() {
		ArrayList<Modalidad> listaModalidades = modelo.obtenerModalidades();
		
		for (Modalidad modalidad : listaModalidades) {
			System.out.println(modalidad);
		}
		
	}

}
