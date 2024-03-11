package MisClases;

import java.util.Scanner;

public class Aplicacion {

	public static Scanner teclado=new Scanner(System.in);
	
	public static void main(String[] args) {

		GestorS3 gestor=new GestorS3();
		
		boolean salir=false;
		
		while(salir==false) {
			
			System.out.println("---------------------------------");
			if(gestor.nombreBucketTrabajo.equals(""))
				System.out.println("No hay bucket de trabajo seleccionado");
			else System.out.println("Bucket de trabajo seleccionado: " + gestor.nombreBucketTrabajo);
			System.out.println("---------------------------------");
			System.out.println("1 - Crear bucket de trabajo ");
			System.out.println("2 - Establecer bucket de trabajo ");
			System.out.println("3 - Cargar Quijote al bucket desde sistema de archivos local");			
			System.out.println("4 - Crear ficheros fragmentos");	
			System.out.println("5 - Listar ficheros fragmento");	
			System.out.println("6 - Leer fichero fragmento");	
			System.out.println("7 - Borrar fragmento");	
			System.out.println("8 - Borrar carpeta de fragmentos");	
			System.out.println("9 - Salir ");			
			
			int opcion=teclado.nextInt();
			teclado.nextLine();
			switch(opcion) {
			case 1:
				gestor.crearBucketTrabajo();
				break;
			case 2:
				gestor.establecerBucketTrabajo();
				break;
			case 3:
				gestor.copiarQuijoteDesdeLocal();
				break;
			case 4:
				gestor.crearFragmentosQuijote();
				break;
			case 5:
				gestor.listarFragmentos();
				break;
			case 6:
				gestor.leerContenidoFragmento();
				break;
			case 7:
				gestor.borrarFragmento();
				break;
			case 8:
				gestor.borrarCarpetaFragmentos();
				break;
			case 9:
				salir=true;
				break;
			}
			
		}
	}

}
