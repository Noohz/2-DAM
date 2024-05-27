package museo;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

public class Principal {

	public static Scanner t = new Scanner(System.in);
	public static Modelo bd = new Modelo();
	public static SimpleDateFormat formato = new SimpleDateFormat("ddMMyyyy");

	public static void main(String[] args) {
		if (bd.getConexion() != null) {
			int opcion = 0;
			do {
				System.out.println("Selecciona una opción");
				System.out.println("0 - Salir");
				System.out.println("1 - Crear inventario");
				System.out.println("2 - Añadir carácterística");
				System.out.println("3 - Modificar ubicación");
				System.out.println("4 - Borrar inventario");
				opcion = t.nextInt();
				t.nextLine();
				switch (opcion) {
				case 1:
					ejercicio1();
					break;
				case 2:
					break;
				case 3:
					ejercicio3();
					break;
				case 4:
					ejercicio4();
					break;
				}

			} while (opcion != 0);
			bd.cerrar();
		} else {
			System.out.println("Error de conexión");
		}
	}

	private static void ejercicio4() {
		mostrarInventarios();

		System.out.println("Introduce el id del inventario que deseas modificar la ubicación: ");
		Inventario inv = bd.obtenerInventario(t.nextInt());
		t.nextLine();

		if (inv != null) {
			boolean existe = false;
			ArrayList<Inventario> invent = bd.obtenerCaracteristicas(inv.getId());

			for (Inventario inventario : invent) {
				if (!existe) {
					for (String[] i : inventario.getCaracteristicas()) {
						if (i[0].equals(String.valueOf(inv.getCaracteristicas()))) {
							existe = true;
							break;
						}
					}
				} else {
					break;
				}
			}

			if (existe) {
				System.out.println(
						"El inventario seleccionado contiene características... ¿Estas seguro de eliminarlo? (Si/No): ");
				String respuesta = t.nextLine();

				if (respuesta.equalsIgnoreCase("si")) {
					if (bd.borrarInventario(inv)) {
						mostrarInventarios();
						System.out.println("Inventario eliminado correctamente.");
					} else {
						System.err.println("Ha ocurrido un error al eliminar el inventario...");
					}
				} else {
					System.err.println("Operación cancelada...");
				}
			} else {
				if (bd.borrarInventario(inv)) {
					mostrarInventarios();
					System.out.println("Inventario eliminado correctamente.");
				} else {
					System.err.println("Ha ocurrido un error al eliminar el inventario...");
				}
			}
		} else {
			System.err.println("Error, no se ha encontrado un inventario con el id introducido...");
		}
	}

	private static void ejercicio3() {
		mostrarInventarios();

		System.out.println("Introduce el id del inventario que deseas modificar la ubicación: ");
		Inventario inv = bd.obtenerInventario(t.nextInt());
		t.nextLine();

		if (inv != null) {
			System.out.println("Introduce el nuevo nombre de ubicación (sección): ");
			inv.getUbicacion().setSeccion(t.nextLine());

			System.out.println("Introduce el nuevo puesto de la sección: ");
			inv.getUbicacion().setPuesto(t.nextInt());
			t.nextLine();

			if (bd.modificarUbicacionInventario(inv)) {
				System.out.println("Se ha modificado correctamente la ubicación del inventario.\n");
				mostrarInventario(inv);
			} else {
				System.err.println("Error, no se ha podido modificar la ubicación del inventario...\n");
			}
		} else {
			System.err.println("Error, no se ha encontrado un inventario con el id introducido...");
		}
	}

	private static void mostrarInventario(Inventario inv) {
		ArrayList<Inventario> inventarios = bd.obtenerInventarioUnico(inv);

		for (Inventario inventario : inventarios) {
			System.out.println(inventario);
			inventario.mostrarCaracteristicas();
			System.out.println();
		}

	}

	private static void ejercicio1() {
		System.out.println("Introduce un nombre para el inventario: ");
		String nombre = t.nextLine();

		System.out.println("Introduce el nombre de la ubicación (sección): ");
		String nombreUbicacion = t.nextLine();

		System.out.println("Introduce el puesto de la sección: ");
		int puestoSeccion = t.nextInt();
		t.nextLine();

		Inventario inv = new Inventario(0, nombre, new Date(), new TipoUbicacion(nombreUbicacion, puestoSeccion), null);

		if (bd.crearInventario(inv)) {
			System.out.println("Inventario creado correctamente.\n");
			mostrarInventarios();
		} else {
			System.err.println("Ha ocurrido un error al crear el inventario...");
		}
	}

	private static void mostrarInventarios() {
		ArrayList<Inventario> inventarios = bd.obtenerInventarios();

		for (Inventario inventario : inventarios) {
			System.out.println(inventario);
			inventario.mostrarCaracteristicas();
			System.out.println();
		}

	}
}
