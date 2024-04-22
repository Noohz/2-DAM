package examen;

import java.util.ArrayList;
import java.util.Scanner;

public class Principal {

	public static Scanner tec = new Scanner(System.in);
	public static Modelo mod = new Modelo();

	public static void main(String[] args) {

		int opc = -1;

		do {
			System.out.println("---------------MENU--------------");
			System.out.println("0 - Salir del programa");
			System.out.println("1 - Crear cancion");
			System.out.println("2 - Modificar duración");
			System.out.println("3 - ");
			System.out.println("Seleccione una opcion: ");
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
				break;
			}
		} while (opc != 0);

	}

	private static void ejercicio2() { // EJ2: Modificar duración.
		mostrarCanciones();
		
		System.out.println("Introduce el id de la canción a modificar: ");
		Canciones c = mod.obtenerCancion(tec.nextInt());
		tec.nextLine();
		
		if (c != null) {
			System.out.println("Introduce la nueva duración: ");
			c.setDuracion(tec.nextInt());
			tec.nextLine();
			
			if (mod.modificarCancion(c)) {
				System.out.println("La duración de la canción se ha modificado.");
				mostrarCanciones();
			} else {
				System.err.println("Error al modificar la duración de la canción.");
			}
		}
	}

	private static void mostrarCanciones() {
		ArrayList<Canciones> cancionesTotales = mod.obtenerTodasLasCanciones();
		
		for (Canciones canciones : cancionesTotales) {
			System.out.println(canciones + "\n");
		}
	}

	private static void ejercicio1() { // EJ1: Crear canción.
		Artista artistaBuscado = null;

		System.out.println("#** INFORMACIÓN DE LOS ARTISTAS **#");
		mostrarArtistas();

		System.out.println("Introduce el código del artista que deseas crear el album: ");
		int codArtista = tec.nextInt();
		tec.nextLine();

		artistaBuscado = mod.buscarArtista(codArtista);

		if (artistaBuscado != null) {
			System.out.println("Vas a crear una canción para el siguiente artista: " + artistaBuscado.toString());

			Canciones c = new Canciones();

			c.setCodigo(c.getCodigo() + 1);

			c.setArtista(codArtista);

			System.out.println("Introduce el título de la canción: ");
			c.setTitulo(tec.nextLine());

			System.out.println("Introduce la duración que tiene la canción (Segundos): ");
			c.setDuracion(tec.nextInt());
			tec.nextLine();

			if (mod.crearCancion(c)) {
				System.out.println("Canción creada correctamente.");
				mostrarCancionesDelArtista(c);
			} else {
				System.err.println("Error al crear la canción.");
			}
		}
	}

	private static void mostrarCancionesDelArtista(Canciones c2) {
		ArrayList<Canciones> canciones = mod.obtenerCancionesDelArtista(c2);

		System.out.println("# Canciones del artista #");

		for (Canciones c : canciones) {
			System.out.println(c);
		}

	}

	private static void mostrarArtistas() {
		ArrayList<Artista> artistas = mod.obtenerArtistasTxt();

		for (Artista artista : artistas) {
			System.out.println(artista + "\n");
		}
	}

}
