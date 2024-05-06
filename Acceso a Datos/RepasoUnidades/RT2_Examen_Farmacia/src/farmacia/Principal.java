package farmacia;

import java.util.ArrayList;
import java.util.Scanner;

public class Principal {

	public static Scanner tec = new Scanner(System.in);
	public static Modelo modelo = new Modelo();

	public static void main(String[] args) {
		int opc = -1;

		if (modelo.getConexion() != null) {
			do {
				System.out.println("---------------MENU--------------");
				System.out.println("0 - Salir del programa.");
				System.out.println("1 - Crear farmacia.");
				System.out.println("2 - Crear pedido.");
				System.out.println("3 - Añadir línea de artículo a pedido.");
				System.out.println("4 - Info pedidos.");
				System.out.println("Seleccione una opción: ");
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
					ejercicio3();
					;
					break;
				case 4:
					ejercicio4();
					break;
				}
			} while (opc != 0);
			modelo.cerrar();
		}

	}

	private static void ejercicio3() {
		System.out.println("#* Pedidos abiertos de hoy *#");
		Pedido p = modelo.obtenerPedidosAbiertos();

		if (p != null) {
			System.out.println(p);

			System.out.println("\n#* Lista de Articulos para incluir en el pedido *#");
			mostrarArticulos();

		} else {
			System.err.println("Error, no hay ningún pedido abierto...");
		}
	}

	private static void mostrarArticulos() {
		ArrayList<Articulo> listaArticulos = modelo.obtenerArticulos();

		for (Articulo articulo : listaArticulos) {
			System.out.println(articulo);
		}
	}

	private static void ejercicio4() {
		mostrarTotalFarmacias();

		System.out.println("Introduce el código de la farmacia que deseas obtener los datos.");
		int codFarmacia = tec.nextInt();
		tec.nextLine();

		if (modelo.comprobarExistenciaFarmaciaCodigo(codFarmacia)) {
			ArrayList<InfoPedidos> p = modelo.infoPedidos(codFarmacia);
			for (InfoPedidos infoPedidos : p) {
				System.out.println("Año: " + infoPedidos.getAnio() + "\tMes: " + infoPedidos.getMes()
						+ "\tNum Articulos: " + infoPedidos.getNumArticulos() + "\tFecha primer pedido: "
						+ infoPedidos.getFechaPrimerPedido() + "\t\tFecha último pedido: "
						+ infoPedidos.getFechaUltimoPedido() + "\t\tImprote Pedido: " + infoPedidos.getImporte());
			}
		} else {
			System.err.println("Error, no existe ninguna farmacia con el código introducido...");
		}

	}

	private static void ejercicio2() {
		mostrarTotalFarmacias();

		System.out.println("Introduce un código de farmacia a la que crear el pedido: ");
		int codFarmacia = tec.nextInt();
		tec.nextLine();

		if (modelo.comprobarExistenciaFarmaciaCodigo(codFarmacia)) {
			Pedido p = modelo.comprobarPedidosFarmacia(codFarmacia);

			if (p != null) {
				System.err.println("Ya existe el pedido nº " + p.getCodigo());
			} else {
				modelo.crearPedido(codFarmacia);
				System.out.println("Pedido creado correctamente.");
				mostrarPedidosFarmacia(codFarmacia);
			}

		} else {
			System.err.println("Error, no existe ninguna farmacia con el código " + codFarmacia + " introducido.");
		}
	}

	private static void mostrarPedidosFarmacia(int codFarmacia) {
		ArrayList<Pedido> listaPedidos = modelo.obtenerPedidoFaramcia(codFarmacia);

		for (Pedido pedido : listaPedidos) {
			System.out.println(pedido);
		}

	}

	private static void ejercicio1() {
		System.out.println("Introduce el CIF para la farmacia: ");
		String cif = tec.nextLine();

		Farmacia farmacia = modelo.comprobarExistenciaFarmaciaCif(cif);

		if (farmacia != null) {
			System.err.println("Ya existe una farmacia con el CIF introducido.");
			System.err.println("#* Farmacia con el CIF " + cif + " *#\n" + farmacia);
		} else {
			System.out.println("Introduce el nombre para la farmacia: ");
			String nombre = tec.nextLine();

			System.out.println("Introduce la direccion para la farmeacia: ");
			String direccion = tec.nextLine();

			farmacia = new Farmacia(0, nombre, cif, direccion);

			if (!modelo.crearFarmacia(farmacia)) {
				System.err.println("Error, no se ha podido crear la farmacia...");
			} else {
				int cod = modelo.obtenerCodigoFarmacia(farmacia);
				System.out.println("Farmacia creada con el código: " + cod);

				System.out.println("#* Farmacias existentes *#");
				mostrarTotalFarmacias();
			}
		}

	}

	private static void mostrarTotalFarmacias() {
		ArrayList<Farmacia> listaFarmacias = modelo.obtenerFarmacias();
		for (Farmacia farmacia : listaFarmacias) {
			System.out.println(farmacia);
		}
	}

}
