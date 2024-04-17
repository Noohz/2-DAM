package McBurguer;

import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

public class Principal {

	public static Scanner tec = new Scanner(System.in);
	public static Modelo modelo = new Modelo();
	public static Empleado e = null; // Objeto que va a almacenar los datos del empleado logeado.

	public static void main(String[] args) {

		int opc = -1;

		do {
			System.out.println("---------------MENU--------------");
			System.out.println("0 - Salir del programa");
			System.out.println("1 - Login");
			System.out.println("2 - Registrar pedido");
			System.out.println("3 - Modificar pedido");
			System.out.println("4 - Cerrar caja");
			System.out.println("Selepcione una opcion: ");
			opc = tec.nextInt();
			tec.nextLine();
			System.out.println("---------------------------------");

			switch (opc) {
			case 1:
				ejercicio1();
				break;
			case 2:
				ejercicio2();
				break;
			case 3:
				;
				break;
			case 4:
				;
				break;
			}
		} while (opc != 0);

	}

	private static void ejercicio2() { // EJ2: Registrar pedido.

		if (e != null) {
			Pedido p = new Pedido();
			p.setCodigo(modelo.obtenerCodigoPedido());
			p.setFecha(new Date());
			p.setCodEmp(e.getCodigoEmpleado());

			int opcion = 0;

			do {

				mostrarProductos();

				System.out.println("Introduce un código del producto: ");
				Producto prod = modelo.obtenerProducto(tec.nextInt());
				tec.nextLine();

				if (prod != null) {
					System.out.println("Introduce la cantidad: ");
					p.setCantidad(tec.nextInt());
					tec.nextLine();

					p.setCodProd(prod.getId());
					p.setPrecio(prod.getPrecio());

					if (modelo.registrarPedido(p)) {
						System.out.println("Producto añadido al pedido.");
					} else {
						System.err.println("Error, no se ha podido añadir el producto al pedido.");
					}

				} else {
					System.err.println("Error, el producto no existe.");
				}

				System.out.println("¿Más productos? - 0 = No | 1 = Si");
				opcion = tec.nextInt();
				tec.nextLine();

			} while (opcion != 0);
			
			ArrayList<Pedido> pedidoActual = modelo.obtenerPedido(p.getCodigo()); 
			
			for (Pedido pedido : pedidoActual) {
				System.out.println(pedido);
			}			
			
		} else {
			System.err.println("Error, no has iniciado sesión.");
		}

	}

	private static void mostrarProductos() {
		ArrayList<Producto> productos = modelo.obtenerProductos();
		
		for (Producto producto : productos) {
			System.out.println(producto);
		}
		
	}

	private static void ejercicio1() { // EJ1: Login.
		System.out.println("Introduce tu código de empleado: ");
		int codEmp = tec.nextInt();
		tec.nextLine();

		System.out.println("Introduce tu contraseña: ");
		String ps = tec.nextLine();

		e = modelo.obtenerEmpleado(codEmp, ps);

		if (e == null) {
			System.err.println("Tus datos de inicio de sesión son incorrectos.");
		} else {
			System.out.println("Empleado logeado.\n");
		}

	}

}
