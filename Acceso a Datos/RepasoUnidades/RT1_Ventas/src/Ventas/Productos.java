package Ventas;

public class Productos {

	private int idProducto, stock;
	private String nombre;

	public Productos() {

	}

	public Productos(int idProducto, int stock, String nombre) {
		this.idProducto = idProducto;
		this.stock = stock;
		this.nombre = nombre;
	}

	public int getIdProducto() {
		return idProducto;
	}

	public void setIdProducto(int idProducto) {
		this.idProducto = idProducto;
	}

	public int getStock() {
		return stock;
	}

	public void setStock(int stock) {
		this.stock = stock;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	@Override
	public String toString() {
		return "ID: " + idProducto + " STOCK: " + stock + " NOMBRE: " + nombre;
	}
}
