package ClaseFile;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class Ejercicio1 {

	// Ruta de la carpeta
	public static String rutaCarpeta = "aitor";
	
	static Scanner t = new Scanner (System.in);
	
	static SimpleDateFormat formatoFecha = new SimpleDateFormat("dd/MM/yyyy hh:mm");
	
	public static void main(String[] args) {		
		
		int opcion = 0;
		
		do {
			
			System.out.println("* - MENU - *");
			
			System.out.println("Selecciona la opción deseada");
			System.out.println("0- Salir");
			System.out.println("1- Info miCarpeta");
			System.out.println("2- Mostrar contenido");
			System.out.println("3- Crear fichero o carpeta");
			System.out.println("4- Renombrar fichero");
			System.out.println("5- Borrar fichero");
			System.out.println("6- Mostrar contenido de miCarpeta recursivo");
			
			opcion = t.nextInt();
			t.nextLine();
			System.out.println("\n");
			
			switch (opcion) {
				
				case 1:
					info();
					break;
				case 2:
					mostrarContenido();
					break;
				case 3:
					crearObjeto();
					break;
				case 4:
					renombrarFichero();
					break;
				case 5:
					borrarObjeto();
					break;
				case 6:
					mostrarContenidoRecursivo(rutaCarpeta, 0);
					break;
			}
			
		} while (opcion != 0);
	}

	private static void mostrarContenidoRecursivo(String ruta, int numTab) {
		// Declaramos el objeto File a la carpeta.
		File f = new File(ruta);
		
		// Obtener el contenido.
		File[] contenido = f.listFiles();
		
		// Recorremos el contenido para mostrar.
		for (File c:contenido) {
			// Pintar tabulaciones
			for (int i = 0; i < numTab; i++) {
				System.out.print("\t");
			}
			
			System.out.println("Nombre : " +c.getName());
			
			if (c.isDirectory()) {
				mostrarContenidoRecursivo(c.getAbsolutePath(), numTab + 1);
			}
		}
	}

	private static void borrarObjeto() {
		mostrarContenido();
		System.out.println("Introduce el nombre del objeto a borrar: ");
		String nombre = t.nextLine();
		
		// Comprobar que existe.
		File f = new File(rutaCarpeta + File.separator + nombre);
		
		if (f.exists()) {
			if(f.delete()) {
				System.out.println("Objeto borrado.");
			} else {
				System.err.println("Error al borra el objeto.");
			}
		}
		
	}

	private static void renombrarFichero() {
		
		mostrarContenido();
		System.out.println("Introduce el nombre del fichero a renombrar.");
		String nombre = t.nextLine();
		nombre = rutaCarpeta + File.separator + nombre;
		
		// Comprobar que exixte y es fichero.
		File f = new File(nombre);
		if (f.exists() && f.isFile()) {
			System.out.println("Introduce el nuevo nombre: ");
			String nuevoNombre = t.nextLine();
			nuevoNombre = rutaCarpeta + File.separator + nuevoNombre;
			
			// Comprobar que no existe el fichero con el nuevo nombre.
			File f2 = new File(nuevoNombre);
			
			if (!f2.exists()) {
				
				// Ya se puede renombrar
				if(f.renameTo(f2)){
					System.out.println("Fichero renombrado.");
					mostrarContenido();
				} else {
					System.err.println("Error al renombrar el fichero.");
				}
				
			} else {
				System.err.println("Error, ya existe un fichero con ese nombre.");
			}
		} else {
			System.err.println("Error, no existe el fichero.");
		}
	}

	private static void crearObjeto() {
		
		
		try {
			
			System.out.println("Introduce el nombre del objeto a crear: ");
			String nombre = t.nextLine();
			nombre = rutaCarpeta + File.pathSeparator +nombre;
			
			// Comprobar que no existe antes de seguir.
			File f = new File(nombre);
			if (f.exists()) {
				System.err.println("Error, ya existe el objeto.");
			} else {
				// Pedir tipo
				System.out.println("Introduce tipo (f - Fichero / c - Carpeta) :");
				String tipo = t.nextLine();
				
				if (tipo.equalsIgnoreCase("f")) {
					if(f.createNewFile()) {
						System.out.println("Fichero creado.");
						mostrarContenido();
					}						
				} else {
					if(f.mkdir()) {
						System.out.println("Carpeta creada.");
						mostrarContenido();
					}
				}
			}	
			
		}
		catch (IOException e) {
			
			System.err.println("Error: Se ha producido un error al crear el objeto. ");
			e.printStackTrace();
		}
	}

	private static void mostrarContenido() {
		
		
		// Declaramos el objeto File a la carpeta.
		File f = new File(rutaCarpeta);
		
		// Obtener el contenido.
		File[] contenido = f.listFiles();
		
		// Recorremos el contenido para mostrar.
		for (File c:contenido) {
			
			// Obtener tipo "F" si es fichero "C" si es carpeta.
			String tipo;
				if (c.isDirectory()) {
					tipo = "c";
				} else {
					tipo = "f";
				}
			
			// Obtener permisos.
			String permisos;
			if (c.canRead()) {
				permisos = "r";
			} else {
				permisos = "-";
			}
			
			if (c.canWrite()) {
				permisos += "w";
			} else {
				permisos += "-";
			}
			
			if (c.canExecute()) {
				permisos += "x";
			} else {
				permisos += "-";
			}
				
			System.out.println("Nombre : " +c.getName() + "\t" +c.length() + "\t" +tipo + 
					"\t" +formatoFecha.format(new Date(f.lastModified()))+ "\t" +permisos);
		}
		
		System.out.println("\n");
	}

	private static void info() {
		// Declara un objeto File que apunte a nuestra carpeta.
		File miCarpeta = new File(rutaCarpeta);
		
		// Mostrar si existe o no.
		System.out.println("Existe: " +miCarpeta.exists());
		// Mostrar si es carpeta.
		System.out.println("Es carpeta: " +miCarpeta.isDirectory());
		// Mostrar si es fichero.
		System.out.println("Es fichero: " +miCarpeta.isFile());
		// Mostrar el nombre
		System.out.println("Ruta: " +miCarpeta.getAbsolutePath());
		// Mostrar la fecha de modificiación.
		Date fecha = new Date(miCarpeta.lastModified());
		System.out.println("Fecha Modificación: " +fecha);
		// Mostrar la fecha con formato dd/mm/yyyy hh:mm.
		// Tenemos que declarar un objeto que represente el formato deseado.
		
		System.out.println("Fecha Modificación: " +formatoFecha.format(fecha));
		
		System.out.println("\n");
	}
	
	
}
