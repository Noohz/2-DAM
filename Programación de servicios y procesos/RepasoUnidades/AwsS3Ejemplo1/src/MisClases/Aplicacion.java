package MisClases;

import java.util.Scanner;

public class Aplicacion {

	public static Scanner teclado=new Scanner(System.in);
	
	public static void main(String[] args) {

		GestorS3 gestor=new GestorS3();
		
		boolean salir=false;
		
		while(salir==false) {
			System.out.println("1 - Listar contenido bucket ");
			System.out.println("2 - Crear bucket ");			
			System.out.println("3 - Borrar contenido bucket ");	
			System.out.println("4 - Leer contenido fichero texto ");	
			System.out.println("5 - Generar contenido ficheros texto ");	
			System.out.println("6 - Leer contenido desde API REST de S3");	

			System.out.println("9 - Salir ");			
			
			int opcion=teclado.nextInt();
			teclado.nextLine();
			switch(opcion) {
			case 1:
				gestor.listarContenidoBucket();
				break;
			case 2:
				gestor.crearBucket();
				break;
			case 3:
				gestor.borrarContenidoBucket();
				break;
			case 4:
				gestor.leerContenidoObjetoTexto();
				break;
			case 5:
				gestor.generarContenidoFicherosTexto();
				break;
			case 6:
				gestor.leerContenidoApiRest();
				break;
			case 9:
				salir=true;
				break;
			}
			
		}
	}

}
