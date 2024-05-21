package skills;

import java.text.ParseException;
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
				System.out.println("1 - Crear prueba");
				System.out.println("2 - Modificar prueba");
				System.out.println("3 - Corregir prueba");
				System.out.println("4 - Borrar prueba)");
				opcion = t.nextInt();
				t.nextLine();
				switch (opcion) {
				case 1:
					ejercicio1();
					break;
				case 2:
					ejercicio2();
					break;
				case 3:
					ejercicio3();
					break;
				case 4:

					break;
				}

			} while (opcion != 0);
			bd.cerrar();
		} else {
			System.out.println("Error de conexión");
		}
	}

	private static void ejercicio3() {
		
		
	}

	private static void ejercicio2() {
		mostrarPruebasModalidad(null);

		System.out.println("Introduce el código de una prueba: ");
		Prueba p = bd.obtenerPrueba(t.nextInt());
		t.nextLine();

		try {
			if (p != null) {
				System.out.println("Introduce nueva fecha (ddMMyyyy): ");
				p.setFecha(formato.parse(t.nextLine()));

				System.out.println("Introduce un nuevo título: ");
				p.getInfo().setTitulo(t.nextLine());

				System.out.println("Introduce la nueva descripción: ");
				p.getInfo().setDescripcion(t.nextLine());
				
				System.out.println("Introduce la nueva puntuacion: ");
				int nuevaPuntuacion = t.nextInt();
				t.nextLine();
				
				if (bd.obtenerPuntuacion(p.getModalidad() - p.getPuntuacion()) + nuevaPuntuacion > 10) {
					System.err.println("Error, la suma de las notas es mayor de 10.");
				} else {
					p.setPuntuacion(nuevaPuntuacion);
					if (bd.modificarPrueba(p)) {
						mostrarPruebasModalidad(bd.obtenerModalidad(p.getModalidad()));
					} else {
						System.err.println("Error, ha ocurrido un error al modificar la prueba...");
					}
				}
			} else {
				System.err.println("Error, no existe ninguna prueba con el código introducido...");
			}
		} catch (ParseException e) {
			System.err.println("Error, el formato de la fecha es incorrecto...");
		}
	}

	private static void ejercicio1() {
		mostrarModalidades();

		System.out.println("Introduce el código de una módalidad: ");
		Modalidad m = bd.obtenerModalidad(t.nextInt());
		t.nextLine();

		if (m != null) {
			Prueba p = new Prueba();
			p.setModalidad(m.getId());
			p.setFecha(new Date());

			System.out.println("Introduce el título de la prueba: ");
			p.setInfo(new Infoprueba(t.nextLine(), null));
			System.out.println("Introduce la descripción de la prueba: ");
			p.getInfo().setDescripcion(t.nextLine());
			System.out.println("Introduce la puntuación de la prueba: ");
			p.setPuntuacion(t.nextInt());
			t.nextLine();

			if (bd.obtenerPuntuacion(m.getId()) + p.getPuntuacion() <= 10) {
				if (bd.crearPrueba(p)) {
					System.out.println("Prueba creada correctamente.");
					mostrarPruebasModalidad(m);
				} else {
					System.err.println("Ha ocurrido un error al crear la prueba.");
				}
			} else {
				System.err.println("Error, las pruebas sumas más de 10.");
			}
		} else {
			System.err.println("Error, no existe una modalidad con el código introducido.");
		}
	}

	private static void mostrarPruebasModalidad(Modalidad m) {
		ArrayList<Prueba> listaPruebas = bd.obtenerPruebas(m);

		for (Prueba prueba : listaPruebas) {
			System.out.println(prueba);
		}

	}

	private static void mostrarModalidades() {
		ArrayList<Modalidad> m = bd.obtenerModalidades();

		for (Modalidad modalidad : m) {
			System.out.println(modalidad);
		}
	}

}
