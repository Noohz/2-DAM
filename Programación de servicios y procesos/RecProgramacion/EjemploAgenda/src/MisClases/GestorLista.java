package MisClases;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;

public class GestorLista implements Serializable {

	ArrayList<EntradaAgenda> lista; // Aquí estaría vacía.

	// La declaramos en el constructor
	public GestorLista() {
		lista = new ArrayList<EntradaAgenda>();
	}

	public void añadirEntrada() {
		// Pedir los datos de la entrada.
		System.out.print("Escribe el nombre: ");
		String nombre = Aplicacion.teclado.nextLine();

		System.out.print("Escribe la dirección: ");
		String direccion = Aplicacion.teclado.nextLine();

		System.out.print("Escribe el email: ");
		String email = Aplicacion.teclado.nextLine();

		System.out.print("Escribe el número fijo: ");
		int numFijo = Aplicacion.teclado.nextInt();
		Aplicacion.teclado.nextLine();

		System.out.print("Escribe el número móvil: ");
		int numMovil = Aplicacion.teclado.nextInt();
		Aplicacion.teclado.nextLine();

		// Crear el objeto de tipo EntradaAgenda
		EntradaAgenda nuevaEntrada = new EntradaAgenda(nombre, direccion, email, numFijo, numMovil);

		// Añadir entrada a la lista
		lista.add(nuevaEntrada);
	}

	public void mostrarContenido() {

		// Recorremos las distintas entradas de la agenda
		for (int i = 0; i < lista.size(); i++) {
			EntradaAgenda entrada = lista.get(i);
			System.out.println(i + entrada.toString());
		}
	}

	public void borrarEntrada() {

		// Le pedimos al usuario el índice de la entrada a borrar.
		System.out.print("Introduce el índice a borrar: ");
		int indice = Aplicacion.teclado.nextInt();
		Aplicacion.teclado.nextLine();

		// Un try-catch para capturar la excepción que puede ocurrir si le indicas un
		// índice fuera del rango.
		try {
			lista.remove(indice);
		} catch (IndexOutOfBoundsException e) {
			System.err.println("No existe ninguna entrada en esa posición: " + e);
		}
	}

	public void modificarEntrada() {

		// Le pedimos al usuario el índice de la entrada a borrar.
		System.out.print("Introduce el índice a modificar: ");
		int indice = Aplicacion.teclado.nextInt();
		Aplicacion.teclado.nextLine();

		// Un try-catch para capturar la excepción que puede ocurrir si le indicas un
		// índice fuera del rango.
		try {
			EntradaAgenda entrada = lista.get(indice);

			// Mostrar los datos que hay en esa entrada
			System.out.print("Escribe el nombre: " + "(" + entrada.getNombre() + ")");
			String nombre = Aplicacion.teclado.nextLine();

			// Si el usuario escribe el nombre se modifica, si no no se hace nada.
			if (!nombre.isEmpty()) {
				entrada.setNombre(nombre);
			}

			System.out.print("Escribe dirección: " + "(" + entrada.getDireccion() + ")");
			String direccion = Aplicacion.teclado.nextLine();

			if (!direccion.isEmpty()) {
				entrada.setDireccion(direccion);
			}

			System.out.print("Escribe el email: " + "(" + entrada.getEmail() + ")");
			String email = Aplicacion.teclado.nextLine();

			if (!email.isEmpty()) {
				entrada.setEmail(email);
			}

			System.out.print("Escribe el número fijo: " + "(" + entrada.getNumFijo() + ")");
			String numFijo = Aplicacion.teclado.nextLine();

			if (!numFijo.isEmpty()) {
				entrada.setNumFijo(Integer.valueOf(numFijo));
			}

			System.out.print("Escribe el número móvil: " + "(" + entrada.getNumMovil() + ")");
			String numMovil = Aplicacion.teclado.nextLine();

			if (!numMovil.isEmpty()) {
				entrada.setNumMovil(Integer.valueOf(numMovil));
			}

		} catch (IndexOutOfBoundsException e) {
			System.err.println("No existe ninguna entrada en esa posición: " + e);
		}
	}

	public void buscarContenido() {
		// Pedimos al usuario que escriba el término de búsqueda
		System.out.print("Escribe el término de búsqueda:");
		String termino = Aplicacion.teclado.nextLine();
		termino = termino.toUpperCase();

		for (int i = 0; i < lista.size(); i++) {
			EntradaAgenda entrada = lista.get(i);

			if (entrada.getNombre().toUpperCase().contains(termino)
					|| entrada.getDireccion().toUpperCase().contains(termino)
					|| entrada.getEmail().toUpperCase().contains(termino)
					|| (entrada.getNumFijo() + "").contains(termino)
					|| (entrada.getNumMovil() + "").toUpperCase().contains(termino)) {

				System.out.println(i + entrada.toString());

			}
		}
	}

	public void leerAgendaDisco() {
		FileInputStream fichero = null;
		ObjectInputStream entradaBytes = null;

		try {
			fichero = new FileInputStream("C:\\Ejemplos\\agenda.dat");

			entradaBytes = new ObjectInputStream(fichero);

			// Serializamos el objeto con la agenda.
			try {
				lista = (ArrayList<EntradaAgenda>) entradaBytes.readObject();
			} catch (ClassNotFoundException e) {

				e.printStackTrace();
			}

		} catch (FileNotFoundException e) {

			
		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			// entradaBytes se encarga de cerrar el fichero por que está vinculado a él.
			if (entradaBytes != null) {
				try {
					entradaBytes.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}
	}

	public void escribirAgendaDisco() {
		FileOutputStream fichero = null;
		ObjectOutputStream salidaBytes = null;

		try {
			fichero = new FileOutputStream("C:\\Ejemplos\\agenda.dat");

			salidaBytes = new ObjectOutputStream(fichero);

			// Serializamos el objeto con la agenda.
			salidaBytes.writeObject(lista);

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			// salidaBytes se encarga de cerrar el fichero por que está vinculado a él.
			if (salidaBytes != null) {
				try {
					salidaBytes.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}
	}
}
