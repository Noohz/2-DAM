package examen;

import java.text.SimpleDateFormat;
import java.util.Scanner;

public class Principal {

	public static Scanner t = new Scanner(System.in);

	public static Modelo empL = new Modelo("empleados.txt");
	
	public static void main(String[] args) {
		int opcion = 0;
		do {
			System.out.println("Selecciona una opción");
			System.out.println("0- Salir");
			System.out.println("1- Login");
			System.out.println("2- Registrar pedido");
			System.out.println("3- Modificar pedido");
			System.out.println("4- Cerrar caja");
			opcion = t.nextInt();
			t.nextLine();

			switch (opcion) {
			case 1:
				login();
				break;
			case 2:
				registrarPedido();
				break;
			}
		} while (opcion != 0);
	}

	private static void registrarPedido() {
		if (empL.logeado == true) {
			SimpleDateFormat formatoFecha = new SimpleDateFormat("dd/MM/yyyy");
			Pedidos p = new Pedidos();
			p.getCodPedido();
			
		} else {
			System.err.println("Error, no has iniciado sesión.");
		}

	}

	private static void login() {

		// Pedir el codEmpleado
		System.out.println("\nCódigo Empleado:");
		String codEmpleadoL = t.nextLine();
		
		// Pedir el dni
		System.out.println("DNI:");
		String dniL = t.nextLine();

		Empleados l = empL.obtenerEmpleados(codEmpleadoL, dniL);
		
		// Comprobamos si existe y si está activo.
		if (l != null && l.activo == true) {
			// El usuario queda logeado.
			System.out.println("Se ha iniciaro sesión correctamente.");
		} else {
			System.err.println("Error al intentar iniciar sesión.\nComprueba el código de empleado y DNI.\n");
		}
	}
}
