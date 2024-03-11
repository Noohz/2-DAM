package examen;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;

public class GestorEmbalses implements Serializable {
	ArrayList<Embalse> arrayEmbalse = new ArrayList<Embalse>();

	public void cargarFichero() {
		FileInputStream fichero;
		ObjectInputStream entradaDatos = null;

		try {
			fichero = new FileInputStream(
					"C:\\Github\\2-DAM\\Programación de servicios y procesos\\RecProgramacion\\InfoEmbalses\\datosEmbalses.dat");
			entradaDatos = new ObjectInputStream(fichero);

			arrayEmbalse = (ArrayList<Embalse>) entradaDatos.readObject();

		} catch (FileNotFoundException e) {

			System.err.println("No se ha encontrado el fichero citas. Creandolo...");

		} catch (IOException e) {

			System.err.println("Ha ocurrido un error al intentar leer el fichero. " + e);

		} catch (ClassNotFoundException e) {

			System.err.println("No se ha podido la clase a cargar." + e);
		} finally {
			if (entradaDatos != null) {
				try {
					entradaDatos.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}
	}

	public void escribirFichero() {
		FileOutputStream fichero;
		ObjectOutputStream salidaBytes = null;

		try {
			fichero = new FileOutputStream(
					"C:\\Github\\2-DAM\\Programación de servicios y procesos\\RecProgramacion\\InfoEmbalses\\datosEmbalses.dat");

			salidaBytes = new ObjectOutputStream(fichero);

			salidaBytes.writeObject(arrayEmbalse);

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			if (salidaBytes != null) {
				try {
					salidaBytes.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}
	}

	public void aniadirEmbalse() {
		boolean vacio = false;

		System.out.print("Introduce el nombre del embalse: ");
		String nombre = Principal.src.nextLine();

		while (vacio == false) {
			if (!nombre.equalsIgnoreCase("")) {
				vacio = true;
			} else {
				System.out.print("Tienes que introducir un nombre para el embalse: ");
				nombre = Principal.src.nextLine();
			}
		}

		System.out.print("Introduce la capacidad del embalse: ");
		int capacidad = Principal.src.nextInt();
		Principal.src.nextLine();

		System.out.print("Introduce el nivel actual del embalse: ");
		int nivelActual = Principal.src.nextInt();
		Principal.src.nextLine();

		System.out.print("Introduce la variación de la última medida del embalse: ");
		int variacionUltimaMedida = Principal.src.nextInt();
		Principal.src.nextLine();

		System.out.print("Introduce la confederación hidrográfica del embalse: ");
		String confederacionHidrografica = Principal.src.nextLine();

		System.out.print("Introduce la provincia del embalse: ");
		String provincia = Principal.src.nextLine();

		Embalse nuevoEmbalse = new Embalse(nombre, capacidad, nivelActual, variacionUltimaMedida,
				confederacionHidrografica, provincia);
		arrayEmbalse.add(nuevoEmbalse);
		escribirFichero();
		System.out.println("Embalse añadido correctamente.");
		mostrarEmbalses();
	}

	public void mostrarEmbalses() {
		for (int i = 0; i < arrayEmbalse.size(); i++) {
			Embalse embalses = arrayEmbalse.get(i);

			System.out.println("Nombre: " + embalses.getNombre() + "(" + embalses.getProvincia() + ")" + "\t------\t"
					+ "(Confederación hidrográfica del " + embalses.getConfederacionHidrografica() + ")");
			System.out.println("Nivel actual: " + embalses.getNivelActual() + " sobre " + embalses.getCapacidad() + "("
					+ embalses.getPorcentaje() + "%)\t" + "Variación de la última medida: "
					+ embalses.getVariacionUltimaMedida());
			System.out.println();
		}
	}

	public void borrarEmbalse() {
		System.out.print("Introduce el nombre del embalse a eliminar: ");
		String nombre = Principal.src.nextLine();
		String busqueda = nombre.toLowerCase();

		for (int i = 0; i < arrayEmbalse.size(); i++) {
			Embalse embalses = arrayEmbalse.get(i);

			if (embalses.getNombre().toLowerCase().equals(busqueda)) {
				System.out.println("Nombre: " + embalses.getNombre() + "(" + embalses.getProvincia() + ")"
						+ "\t------\t" + "(Confederación hidrográfica del " + embalses.getConfederacionHidrografica());
				System.out.println("Nivel actual: " + embalses.getNivelActual() + " sobre " + embalses.getCapacidad()
						+ "(" + embalses.getPorcentaje() + "%)\t"
						+ "Variación de la última medida: " + embalses.getVariacionUltimaMedida());
				System.out.println("\n¿Estas seguro de que quieres eliminar el embalse? (Sí / No)");
				String confirmacion = Principal.src.nextLine();

				if (confirmacion.toLowerCase().equalsIgnoreCase("sí")
						|| confirmacion.toLowerCase().equalsIgnoreCase("si")) {
					arrayEmbalse.remove(i);
					escribirFichero();
					mostrarEmbalses();
				} else {
					System.out.println("Se ha cancelado la operación.\n");
					mostrarEmbalses();
				}
			} else {
				System.err.println("No se ha encontrado ningún embalse con ese nombre.\n");
			}
		}
	}

	public void mostrarEmbalsesPorProvincia() {
		ArrayList<Embalse> arrayProvincia = new ArrayList<Embalse>();
		int capacidadTotal = 0;
		int nivelActualTotal = 0;

		System.out.print("Introduce la provincia del embalse: ");
		String provincia = Principal.src.nextLine();

		if (!provincia.equalsIgnoreCase("")) {

			for (int i = 0; i < arrayEmbalse.size(); i++) {
				Embalse embalses = arrayEmbalse.get(i);

				if (embalses.getProvincia().equalsIgnoreCase(provincia)) {
					capacidadTotal += embalses.getCapacidad();
					nivelActualTotal += embalses.getNivelActual();

					arrayProvincia.add(embalses);
				}
			}

		} else {
			System.err.println("No has introducido un nombre.");
		}
		System.out.println("*******************************************************************");
		System.out.println("\nProvincia: " + provincia);
		System.out.println("Capacidad total de sus embalses: " + capacidadTotal + "\tNivel Actual de sus embalses: "
				+ nivelActualTotal);

		System.out.println("Lista de embalses:");

		for (Embalse embalse : arrayProvincia) {
			System.out.println("Nombre: " + embalse.getNombre() + "\tNivel sobre Capacidad " + embalse.getNivelActual()
					+ " sobre " + embalse.getCapacidad() + "(" + embalse.getPorcentaje() + "%)");
		}
		System.out.println("*******************************************************************");
		System.out.println();
	}

	public void mostrarEmbalsesPorConfederacion() {
		ArrayList<Embalse> arrayProvincia = new ArrayList<Embalse>();
		int capacidadTotal = 0;
		int nivelActualTotal = 0;

		System.out.print("Introduce la confederación hidrográfica del embalse: ");
		String confHidrografica = Principal.src.nextLine();

		if (!confHidrografica.equalsIgnoreCase("")) {

			for (int i = 0; i < arrayEmbalse.size(); i++) {
				Embalse embalses = arrayEmbalse.get(i);

				if (embalses.getConfederacionHidrografica().equalsIgnoreCase(confHidrografica)) {
					capacidadTotal += embalses.getCapacidad();
					nivelActualTotal += embalses.getNivelActual();

					arrayProvincia.add(embalses);
				}
			}

		} else {
			System.err.println("No has introducido un nombre.");
		}
		System.out.println("*******************************************************************");
		System.out.println("\nConfederación Hidrográfica: " + confHidrografica);
		System.out.println("Capacidad total de sus embalses: " + capacidadTotal + "\tNivel Actual de sus embalses: "
				+ nivelActualTotal);

		System.out.println("Lista de embalses:");

		for (Embalse embalse : arrayProvincia) {
			System.out.println("Nombre: " + embalse.getNombre() + "\tNivel sobre Capacidad " + embalse.getNivelActual()
					+ " sobre " + embalse.getCapacidad() + "(" + embalse.getPorcentaje() + "%)");
		}
		System.out.println("*******************************************************************");
		System.out.println();
	}

	public void modificarNivelEmbalse() {
		boolean vacio = false;

		System.out.print("Introduce el nombre del embalse que quieres modificar: ");
		String nombre = Principal.src.nextLine();

		while (vacio == false) {
			if (!nombre.equalsIgnoreCase("")) {
				vacio = true;
			} else {
				System.out.print("Tienes que introducir un nombre para el embalse: ");
				nombre = Principal.src.nextLine();
			}
		}

		for (int i = 0; i < arrayEmbalse.size(); i++) {
			Embalse embalses = arrayEmbalse.get(i);
			String busqueda = nombre.toLowerCase();

			if (embalses.getNombre().toLowerCase().contains(busqueda)) {
				System.out.print("Introduce el nuevo nivel del embalse: ");
				int nuevoNivelActual = Principal.src.nextInt();
				Principal.src.nextLine();

				embalses.setNivelActual(nuevoNivelActual);
				escribirFichero();
				System.out.println("Embalse modificado correctamente.\n");

			}
		}
	}
}
