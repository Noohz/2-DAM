package hba;

import java.util.List;
import java.util.Scanner;

public class Principal {
	
	public static Scanner t = new Scanner(System.in);
	public static Modelo bd = new Modelo();

	public static void main(String[] args) {

		if (bd.getConexion() != null) {
			int opcion = 0;
			do {
				System.out.println("Selecciona una opción");
				System.out.println("0 - Salir");
				System.out.println("1 - Seleccionar usuario");
				System.out.println("2 - Crear reproducción");
				System.out.println("3 - Crear capítulo");
				System.out.println("4 - Eliminar capítulo");
				System.out.println("5 - Mostrar reproducciones");
				opcion = t.nextInt();
				t.nextLine();

				switch (opcion) {
				case 1:
					ejercicio1();
					break;
				case 2:

					break;
				case 3:

					break;
				case 4:

					break;
				case 5:
					
					break;
				}

			} while (opcion != 0);
			bd.cerrar();
		} else {
			System.out.println("Error no hay conexión");
		}

	}

	private static void ejercicio1() {
		mostrarUsuarios();
		
		System.out.println("Introduce el nick: ");
		Usuario uS = bd.obtenerUsuario(t.nextLine());
		
		if (uS == null) {
			System.err.println("Error, usuario no encontrado");
		} else {
			System.out.println("Usuario logeado.");
		}
	}

	private static void mostrarUsuarios() {
		List<Usuario> usuarios = bd.obtenerUsuarios();
		
		for (Usuario usuario : usuarios) {
			System.out.println(usuario);
		}
	}

	
}
