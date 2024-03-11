package citasFamosas;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;

public class GestorCitas implements Serializable {

	ArrayList<Cita> arrayCitas = new ArrayList<Cita>();

	/**
	 * Método cargarFichero.
	 * Uso un FileInputStream que inicializo con la ruta del fichero a cargar y un ObjectInputStream que inicializo con la variable que almacena el fichero cargado.
	 * Después uso el arrayCitas para escribir el contenido del fichero casteandolo a un arrayList.
	 * Por último uso un finally para cerrar el ObjectInputStream.
	 */
	public void cargarFichero() {
		FileInputStream fichero;
		ObjectInputStream entradaDatos = null;

		try {
			fichero = new FileInputStream(
					"C:\\GitHub\\2-DAM\\Programación de servicios y procesos\\RecProgramacion\\CitasFamosas\\citas.dat");
			entradaDatos = new ObjectInputStream(fichero);

			arrayCitas = (ArrayList<Cita>) entradaDatos.readObject();

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

	/**
	 * Método escribirFichero.
	 * Uso un FileOutputStream que inicializo con la ruta del fichero a escribir y un ObjectOutputStream que inicializo con la variable que almacena el fichero donde se van a escribir los datos.
	 * Después con el ObjectOutputStream escribo el contenido que hay en el arrayCitas hacia el fichero.
	 * Por último uso un finally para cerrar el ObjectOutputStream.
	 */
	public void escribirFichero() {
		FileOutputStream fichero;
		ObjectOutputStream salidaBytes = null;

		try {
			fichero = new FileOutputStream(
					"C:\\GitHub\\2-DAM\\Programación de servicios y procesos\\RecProgramacion\\CitasFamosas\\citas.dat");

			salidaBytes = new ObjectOutputStream(fichero);

			salidaBytes.writeObject(arrayCitas);

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

	/**
	 * Método mostrarCitas.
	 * Utilizo un for para ir recorriendo el arrayCitas, mientras voy almacenando el índice en la variable citas para poder usarlo en el Syso y mostrar el contenido.
	 * NOTA: Se podría usar un for-each si no fuese necesario mostrar el índice al usuario.
	 */
	public void mostrarCitas() {
		for (int i = 0; i < arrayCitas.size(); i++) {
			Cita citas = arrayCitas.get(i);
			System.out.println("Nodo: " + i + "\t" + citas.toString());
		}
	}

	/**
	 * Método añadirCita.
	 * Le vamos pidiendo los datos al usuario (Si el usuario no introduce ningún autor este se rellenará como null).
	 * Después llamamos al constructor parametrizado de la clase Cita con las variables que ha introducido el usuario para crear una nueva cita.
	 * Llamo al método escribirFichero para guardar la cita en el fichero y muestro todas las citas que hay actualmente.
	 */
	public void aniadirCita() {
		boolean salir = false;
		int idioma = 0;

		System.out.print("Introduce el autor de la cita: ");
		String autor = CitasFamosas.src.nextLine();

		if (autor.equalsIgnoreCase("")) {
			autor = "null";
		}

		System.out.print("Introduce la cita: ");
		String cita = CitasFamosas.src.nextLine();

		while (salir == false) {
			System.out.println("Introduce el idioma de la cita (1 -> Español | 2 -> Ingles)");
			idioma = CitasFamosas.src.nextInt();
			CitasFamosas.src.nextLine();

			if (idioma >= 1 && idioma <= 2) {
				salir = true;
			} else {
				System.err.println("Solo puedes introducir 1 o 2...");
			}
		}

		Cita nuevaCita = new Cita(autor, cita, idioma);
		arrayCitas.add(nuevaCita);
		escribirFichero();
		System.out.println("Cita añadida correctamente.");
		mostrarCitas();
	}

	/**
	 * Método modificarCita.
	 * Pido al usuario el nodo de la cita a modificar, si este existe le pregunto si quiere modificarlo o no.
	 * Si el usuario introduce que sí se le ira mostrando la información de la cita que ha pedido modificar.
	 * Después uso un if para comprobar si alguno de los datos que ha tenido que introducir están vacios, de ser así no se modificarán.
	 * Por último, llamo al método escribirFichero para guardar los cambios.
	 */
	public void modificarCita() {

		try {
			System.out.print("Introduce el nodo de la cita a modificar: ");
			String nodo = CitasFamosas.src.nextLine();

			if (nodo != null) {
				Cita citas = arrayCitas.get(Integer.valueOf(nodo));

				System.out.println("¿Estás seguro de que quieres modificar la siguiente cita? (Sí/No)");
				System.out.println("Nodo: " + nodo + "\t" + citas.toString());
				String confirmacion = CitasFamosas.src.nextLine();

				if (confirmacion.toLowerCase().equalsIgnoreCase("sí")
						|| confirmacion.toLowerCase().equalsIgnoreCase("si")) {

					System.out.println("Autor actual de la cita: " + citas.getAutor());
					System.out.print("Introduce el nuevo autor: ");
					String nAutor = CitasFamosas.src.nextLine();

					System.out.println("Cita actual: " + citas.getCita());
					System.out.print("Introduce la nueva cita: ");
					String nCita = CitasFamosas.src.nextLine();

					System.out.println("Idioma actual de la cita: " + citas.getIdioma());
					System.out.print("Introduce el nuevo idioma (1 -> Español | 2 -> Ingles): ");
					String nIdioma = CitasFamosas.src.nextLine();

					if (!nAutor.isEmpty() || !nCita.isEmpty() || !nIdioma.isEmpty()) {
						if (!nAutor.isEmpty())
							citas.setAutor(nAutor);
						if (!nCita.isEmpty())
							citas.setCita(nCita);
						if (!nIdioma.isEmpty())
							citas.setIdioma(Integer.valueOf(nIdioma));
					}
					escribirFichero();
					System.out.println("Cita modificada correctamente.");

				} else {
					System.out.println("Se ha cancelado la operación.");
					mostrarCitas();
				}
			}
		} catch (IndexOutOfBoundsException e) {
			System.err.println("No existe ningúna cita con el nodo introducido.");
		}
		mostrarCitas();
	}

	/**
	 * Método borrarCita.
	 * Pido al usuario el nodo de la cita a modificar, si este existe le pregunto si quiere eliminarlo o no.
	 * Si el usuario introduce que sí se eliminará la cita que esté en el nodo introducido.
	 * Por último, llamo al método escribirFichero para guardar los cambios y luego muestro todas las citas actuales.
	 */
	public void borrarCita() {

		try {
			System.out.print("Introduce el nodo de la cita a eliminar: ");
			String nodo = CitasFamosas.src.nextLine();

			if (nodo != null) {
				Cita citas = arrayCitas.get(Integer.valueOf(nodo));

				System.out.println("¿Estás seguro de que quieres eliminar la siguiente cita? (Sí/No)");
				System.out.println("Nodo: " + nodo + "\t" + citas.toString());
				String confirmacion = CitasFamosas.src.nextLine();
				int nodoEliminar = Integer.valueOf(nodo);

				if (confirmacion.toLowerCase().equalsIgnoreCase("sí")
						|| confirmacion.toLowerCase().equalsIgnoreCase("si")) {
					arrayCitas.remove(nodoEliminar);
					escribirFichero();
					mostrarCitas();
				} else {
					System.out.println("Se ha cancelado la operación.");
					mostrarCitas();
				}
			}

		} catch (IndexOutOfBoundsException e) {
			System.err.println("No existe ningúna cita con el nodo introducido.");
		}
	}

	/**
	 * Método buscarCita.
	 * Le pido al usuario el termino de la busqueda a realizar (Puede ser un autor o algo que esté en la descripción de la cita).
	 * Uso un bucle while para que el usuario solo pueda introducir 1 o 2 dependiendo del idioma.
	 * Después con un for recorro el array y voy almacenando el índice de la cita para luego usar otro if y comparar si coincide el autor o la descripción de la cita con el termino a buscar.
	 * Todas las citas que coincidan se irán mostrando.
	 */
	public void buscarCita() {
		boolean salir = false;
		int idioma = 0;

		System.out.print("Introduce el término de búsqueda: ");
		String termino = CitasFamosas.src.nextLine().toLowerCase();

		while (salir == false) {
			System.out.println("Introduce el idioma de la cita (1 -> Español | 2 -> Ingles)");
			idioma = CitasFamosas.src.nextInt();
			CitasFamosas.src.nextLine();

			if (idioma >= 1 && idioma <= 2) {
				salir = true;
			} else {
				System.err.println("Solo puedes introducir 1 o 2...");
			}
		}

		for (int i = 0; i < arrayCitas.size(); i++) {
			Cita citas = arrayCitas.get(i);

			if (citas.getAutor().toLowerCase().contains(termino)
					|| citas.getCita().toLowerCase().contains(termino) && citas.getIdioma() == idioma) {
				System.out.println("Nodo: " + i + "\t" + citas.toString());
			}
		}

	}
}