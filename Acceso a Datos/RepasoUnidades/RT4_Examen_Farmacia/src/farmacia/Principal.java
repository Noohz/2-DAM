package farmacia;

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
				System.out.println("1 - Crear farmacia");
				System.out.println("2 – Crear pedido");
				System.out.println("3 - Añadir ínea de artículo a pedido");
				opcion = t.nextInt();
				t.nextLine();

				switch (opcion) {
				case 1:
					ejercicio1();
					break;
				case 2:
					// ejercicio2();
					break;
				case 3:
					// ejercicio3();
					break;
				case 4:
					// ejercicio4();
					break;
				}

			} while (opcion != 0);
			bd.cerrar();
		} else {
			System.out.println("Error no hay conexión");
		}
	}

	private static void ejercicio1() {
		System.out.println("Introduce el CIF de la farmacia: ");

		List<Farmacia> f = bd.obtenerFarmacia(t.nextLine());

		if (!f.isEmpty()) {

			System.out.println("Introduce un nombre para la farmacia: ");
			String nombre = t.nextLine();

			System.out.println("Introduce la dirección de la farmacia: ");
			String direccion = t.nextLine();

			Farmacia far = new Farmacia(0, nombre, f.get(0).getCif(), direccion);

			if (bd.crearFarmacia(far)) {
				System.out.println("Farmacia creada correctamente.");

				mostrarFarmacias();
			} else {
				System.err.println("Error, no ha sido posible crear la farmacia...");
			}
		} else {
			System.err.println("Error, no existe ninguna farmacia con el cif especificado...");
		}

	}

	private static void mostrarFarmacias() {
		List<Farmacia> listaFarmacias = bd.obtenerFarmacias();

		for (Farmacia f : listaFarmacias) {
			System.out.println(f);
		}

	}
}
