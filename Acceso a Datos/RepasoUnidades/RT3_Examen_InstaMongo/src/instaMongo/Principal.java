package instaMongo;

import java.util.ArrayList;
import java.util.Date;
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
				System.out.println("1 - Registro");
				System.out.println("2 - Subir foto");
				System.out.println("3 - Ver fotos de un amigo");

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
				}

			} while (opcion != 0);
		} else {
			System.out.println("Error de conexión");
		}
	}

	private static void ejercicio3() {
		mostrarUsuarios();

		System.out.println("Introduce el ID del usuario que va a ver las fotos: ");
		int idObservador = t.nextInt();
		t.nextLine();

		Usuario observador = bd.comprobarUsuario(idObservador);
		if (observador != null) {
			
			System.out.println("Introduce el ID del usuario que deseas ver las fotos: ");
			int idObservado = t.nextInt();
			t.nextLine();
			
			Usuario observado = bd.comprobarUsuario(idObservado);
			if (observado != null && idObservado != idObservador) {
				mostrarFotosObservado(observador, observado);
				
				System.out.println("Introduce el ID de la foto de " + observado.getNombre() + " que deseas ver: ");
				int idFotoObservado = t.nextInt();
				t.nextLine();
				
				Foto f = bd.comprobarFoto(idFotoObservado);
				
				if (f != null) {
					boolean leGusta;
					do {
						System.out.println("Indica si la foto te ha gustado (Si/No): ");
						String meGusta = t.nextLine();
						
						if (meGusta.equalsIgnoreCase("Si")) {
							leGusta = true;
							break;
						} else if (meGusta.equalsIgnoreCase("No")){
							leGusta = false;
							break;
						}
					} while (true);
					
					Visualizacion v = new Visualizacion(idObservador, leGusta);
					f.getVisualizaciones().add(v);
					
					if (bd.aniadirVisualizacion(f, leGusta)) {
						mostrarFotosObservador(observador);
					} else {
						System.err.println("Error, no se ha podido añadir la visualización...");
					}
				} else {
					System.err.println("Error, no existe ningúna foto con el ID indicado o ya la has visualizado...");
				}
			}

		} else {
			System.err.println("Error, no existe ningún usuario con el id especificado...");
		}
	}

	private static void mostrarFotosObservador(Usuario observador) {
		ArrayList<Foto> listaFotosObservador = bd.obtenerFotosObservador(observador);
		
		System.out.println("#** Fotos vistas por " + observador.getNombre() + " **#");
		for (Foto foto : listaFotosObservador) {
			System.out.println(foto);
		}
		
	}

	private static void mostrarFotosObservado(Usuario observador, Usuario observado) {
		ArrayList<Foto> listaFotosObservado = bd.obtenerFotosObservado(observador, observado);
		
		System.out.println("#** Fotos del Usuario " + observado.getNombre() + " **#");
		for (Foto foto : listaFotosObservado) {
			System.out.println(foto);
		}
	}

	private static void ejercicio2() {
		mostrarUsuarios();

		System.out.println("Introduce el id del usuario que publicará la foto:");
		int idUsr = t.nextInt();
		t.nextLine();

		Usuario usr = bd.comprobarUsuario(idUsr);

		if (usr != null) {
			Foto f = new Foto();

			System.out.println("Introduce la URL de la foto a subir: ");
			f.setUrl(t.nextLine());
			f.setFecha(new Date());
			f.setId(bd.obtenerUltimoIDFoto());
			f.setPropietario(usr.getId());

			if (bd.crearFoto(f)) {
				if (!bd.actualizarFotosPublicadas(usr)) {
					System.err.println("Error, no se ha podido actualizar el número de fotos publicadas...");
				} else {
					mostrarFotosUsuario(usr);
				}
			} else {
				System.err.println("Error, no se ha podido crear la foto...");
			}

		} else {
			System.err.println("Error, no existe ningún usuario con el id especificado...");
		}

	}

	private static void mostrarFotosUsuario(Usuario usr) {
		ArrayList<Foto> listaFotos = bd.obtenerFotos(usr);

		for (Foto foto : listaFotos) {
			System.out.println(foto);
		}

	}

	private static void ejercicio1() {
		System.out.println("Introduce tu dirección de email: ");
		String email = t.nextLine();

		Usuario usr = bd.comprobarCorreo(email);

		if (usr == null) {
			usr = new Usuario();
			usr.setEmail(email);

			System.out.println("Introduce tu nombre de usuario: ");
			usr.setNombre(t.nextLine());

			usr.setId(bd.obtenerUltimoID());
			usr.setNumPublicaciones(0);

			if (bd.crearUsuario(usr)) {
				mostrarUsuarios();
			} else {
				System.err.println("Error, no se ha podido crear el usuario...");
			}
		} else {
			System.err.println("Error, ya existe un usuario con esa dirección de correo...");
		}
	}

	private static void mostrarUsuarios() {
		ArrayList<Usuario> listaUsuarios = bd.obtenerUsuarios();

		for (Usuario usuario : listaUsuarios) {
			System.out.println(usuario);
		}
	}
}