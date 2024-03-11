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
			teclado.nextLine();
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
			}
		}
		teclado.close();
	}
	
	public static void pintoMenu() {
		System.out.println("0 - Salir");
		System.out.println("1 - Enviar email. Sólo texto");
		System.out.println("2 - Enviar email con ficheros adjuntos");
		System.out.println("3 - Lectura de correos electrónicos en servidor IMAP");
	}
}
