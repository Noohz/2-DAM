package serviHogar;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.Scanner;

public class Principal {

	public static Scanner t = new Scanner(System.in);
	public static Modelo bd = new Modelo();
	public static SimpleDateFormat formato = new SimpleDateFormat("ddMMyyyy");

	public static void main(String[] args) {
		if (bd.getConexion() != null) {
			int opcion = 0;
			do {
				System.out.println("Selecciona una opción");
				System.out.println("0 - Salir");
				System.out.println("3 - Crear presupuesto");
				System.out.println("4 - Añadir servicio");
				opcion = t.nextInt();
				t.nextLine();
				switch (opcion) {
				case 3:
					ejercicio3();
					break;
				case 4:
					ejercicio4();
					break;
				}

			} while (opcion != 0);
			bd.cerrar();
		} else {
			System.out.println("Error de conexión");
		}
	}

	private static void ejercicio4() {
		mostrarPresupuestos();

		System.out.println("Introduce un id del presupuesto: ");
		Presupuesto p = bd.obtenerPresupuesto(t.nextInt());
		t.nextLine();
		
		if (p != null) {
			System.out.println("Introduce la nueva descripción del servicio: ");	
			String descServ = t.nextLine();
			
			System.out.println("Introduce el número de horas del servicio: ");
			int numHServ = t.nextInt();
			t.nextLine();
			
			System.out.println("Introduce el importe del servicio: ");
			float importServicio = t.nextFloat();
			t.nextLine();
			
			if (bd.aniadirServicio(p, descServ, numHServ, importServicio)) {
				mostrarPresupuestos();
			} else {
				System.err.println("Error, no se ha podido añadir el servicio...");
			}
		}
		
	}

	private static void ejercicio3() {
		Presupuesto p = new Presupuesto();
		String[] s = new String[3];

		System.out.println("Introduce tu DNI: ");
		String dni = t.nextLine();
		System.out.println("Introduce tu nombre: ");
		String nombre = t.nextLine();
		System.out.println("Introduce tu número de teléfono: ");
		String tlf = t.nextLine();
		
		p.setDatosCliente(new Cliente(dni, nombre, tlf));

		p.setFecha(new Date());

		System.out.println("Introduce la descripción del servicio: ");
		String descServ = t.nextLine();
		System.out.println("Introduce el número de horas del servicio: ");
		int numHorasServ = t.nextInt(); 
		t.nextLine();
		System.out.println("Introduce el importe del servicio: ");
		float importeServ = t.nextFloat();
		t.nextLine();


		if (bd.crearPresupuesto(p, descServ, numHorasServ, importeServ)) {
			mostrarPresupuestos();
		} else {
			System.err.println("Error, no se ha podido crear el presupuesto...");
		}
	}

	private static void mostrarPresupuestos() {
		ArrayList<Presupuesto> listaPresupuestos = bd.obtenerPresupuestos();

		for (Presupuesto p : listaPresupuestos) {
			System.out.println(p);
		}
	}
}
