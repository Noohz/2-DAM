package MisClases;

import java.util.Scanner;

public class Aplicacion {
	
	static Scanner teclado;
	
	public static void main(String[] args) {
		teclado=new Scanner(System.in);
		
		boolean salir=false;
		while(salir==false) {
			pintoMenu();
			int opcion=teclado.nextInt();
			switch(opcion) {
			case 0:
				salir=true;
				break;
			case 1:
				Ejemplo1 ej1=new Ejemplo1();
				ej1.ejecutar();
				break;
			case 2:
				Ejemplo2 ej2=new Ejemplo2();
				ej2.ejecutar();
				break;
			case 3:
				Ejemplo3 ej3=new Ejemplo3();
				ej3.ejecutar();
				break;
			case 4:
				Ejemplo4 ej4=new Ejemplo4();
				ej4.ejecutar();
				break;
			case 5:
				Ejemplo5 ej5=new Ejemplo5();
				ej5.ejecutar();
				break;
			case 6:
				Ejemplo6 ej6=new Ejemplo6();
				ej6.ejecutar();
				break;
			}
		}
		teclado.close();
	}
	
	public static void pintoMenu() {
		System.out.println("0 - Salir");
		System.out.println("1 - Obtener contenido página HTTP con clases URL y HttpURLConnection");
		System.out.println("2 - Obtener contenido página HTTP con HttpRequest, HttpClient y HttpResponse");
		System.out.println("3 - Procesar web con JSoup (web scraping)");
		System.out.println("4 - API REST (JSON) con clases URL y HttpURLConnection");
		System.out.println("5 - API REST (JSON) con HttpRequest, HttpClient y HttpResponse");
		System.out.println("6 - Procesar web Bolsa");
	
	}
}
