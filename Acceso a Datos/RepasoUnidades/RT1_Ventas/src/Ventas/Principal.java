package Ventas;

import java.util.ArrayList;
import java.util.Scanner;

public class Principal {

	public static Scanner tec = new Scanner(System.in);
	public static Modelo mod = new Modelo();

	public static void main(String[] args) {

		int opc = -1;

		do {
			System.out.println("---------------MENU--------------");
			System.out.println("0 - Salir del programa");
			System.out.println("1 - Crear fichero de objetos");
			System.out.println("2 - Crear fichero binario");
			System.out.println("3 - Modificar stock");
			System.out.println("4 - Generar Xml");
			System.out.println("Selepcione una opcion: ");
			opc = tec.nextInt();
			tec.nextLine();
			System.out.println("---------------------------------");

			switch (opc) {
			case 1:
				ejercico1();
				break;
			case 2:
				ejercicio2();
				break;
			case 3:
				ejercicio3();
				break;
			case 4:
				ejercicio4();
				break;
			}
		} while (opc != 0);
	}

	private static void ejercicio4() { // EJ4: Generar xml con los datos de un producto.
		mostrarStock();
		
		System.out.println("Introduce el código del producto a generar el XML: ");
		Productos p = mod.obtenerProducto(tec.nextInt());
		tec.nextLine();

		if (p != null) {
			
			Info i = new Info();
			
			i.setId(p.getIdProducto());
			i.setNombre(p.getNombre());
			i.setStock(p.getStock());
			
			VentasObj v = mod.obtenerVentaObj(p.getIdProducto());		
			
			i.setVendido(v.getCantidad());
			i.setRecaudado(v.getImporte());
			
			if (mod.marshal(i)) {
				System.out.println("Fichero creado.");
				
			} else {
				
			}
			
		} else {
			System.err.println("El código introducido no existe.");
		}
	}

	private static void ejercicio3() { // EJ3: Modificar Stock
		mostrarStock();

		System.out.println("Introduce un codigo de producto a modificar: ");
		Productos p = mod.obtenerProducto(tec.nextInt());
		tec.nextLine();

		if (p != null) {
			System.out.println("Introduce el nuevo stock: ");
			
			p.setStock(tec.nextInt());
			tec.nextLine();
			
			if (mod.modificarProducto(p)) {
				System.out.println("Producto modificado.");
				mostrarStock();
			} else {
				System.err.println("Error al modificar el stock del producto.");
			}
			
		} else {
			System.err.println("El código introducido no existe.");
		}
	}

	private static void ejercicio2() { // EJ2: Crear fichero binario.
		ArrayList<VentasObj> vObj = mod.obtenerVentasObj();

		for (VentasObj ventasObj : vObj) {
			Productos p = new Productos();
			p.setIdProducto(ventasObj.getProducto());

			System.out.println("Introduce el nombre del producto " + ventasObj.getProducto() + ":");
			p.setNombre(tec.nextLine());

			System.out.println("Introduce el stock del producto " + p.getIdProducto() + ":");
			p.setStock(tec.nextInt());
			tec.nextLine();

			if (mod.crearProducto(p)) {
				System.out.println("Producto creado correctamente.");
			} else {
				System.err.println("Error al crear el producto.");
			}
		}
		mostrarStock();
	}

	private static void mostrarStock() {
		ArrayList<Productos> pStock = mod.obtenerProductos();

		System.out.println("# Datos de los productos #");

		for (Productos productos : pStock) {
			System.out.println(productos);
		}

	}

	private static void ejercico1() { // EJ1: Crear fichero de objetos.

		ArrayList<VentasTxt> listVenTxt = mod.obtenerVentasTxt();

		for (VentasTxt vTxt : listVenTxt) {

			VentasObj vObj = mod.obtenerVentaObj(vTxt.getProducto());

			if (vObj != null) { // Al ser distinto de null ya existe una venta en vObj, por lo que hay que
								// modificarla.
				vObj.setCantidad(vObj.getCantidad() + vTxt.getCantidad());
				vObj.setImporte(vObj.getImporte() + vTxt.getImporte());

				if (mod.modificarVenta(vObj)) { // Se le pasa por parámetro el vObj con los datos modificados.
					System.out.println("Venta modificada.");
				} else {
					System.err.println("Erorr al modificar la venta.");
				}

			} else {
				vObj = new VentasObj(vTxt.getProducto(), vTxt.getCantidad(), vTxt.getImporte());

				if (mod.crearVenta(vObj)) { // Como FOBJ no contiene el producto se creará.
					System.out.println("Venta insertada.");
				} else {
					System.err.println("Error al insertar la venta.");
				}
			}
		}
		mostrarVentasObj();

	}

	private static void mostrarVentasObj() {
		ArrayList<VentasObj> ventas = mod.obtenerVentasObj();

		for (VentasObj v : ventas) {
			System.out.println(v + "\n");
		}

	}
}
