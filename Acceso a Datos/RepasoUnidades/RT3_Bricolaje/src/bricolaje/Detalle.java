package bricolaje;

public class Detalle {
	private String producto;
	private int cantidad;
	private double precio;

	public Detalle() {

	}

	public Detalle(String producto, int cantidad, double precio) {
		this.producto = producto;
		this.cantidad = cantidad;
		this.precio = precio;
	}

	public String getProducto() {
		return producto;
	}

	public void setProducto(String producto) {
		this.producto = producto;
	}

	public int getCantidad() {
		return cantidad;
	}

	public void setCantidad(int cantidad) {
		this.cantidad = cantidad;
	}

	public double getPrecio() {
		return precio;
	}

	public void setPrecio(double precio) {
		this.precio = precio;
	}

	@Override
	public String toString() {
		return "Detalle [producto=" + producto + ", cantidad=" + cantidad + ", precio=" + precio + "]";
	}
}
