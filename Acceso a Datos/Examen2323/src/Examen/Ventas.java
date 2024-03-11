package Examen;

public class Ventas {
	private int idProducto,cantidadVendida;
	private float importeRecaudado;
	public Ventas() {
		
	}
	public Ventas(int idProducto, int cantidadVedidad, float importeRecaudado) {
		this.idProducto = idProducto;
		this.cantidadVendida = cantidadVedidad;
		this.importeRecaudado = importeRecaudado;
	}
	public int getIdProducto() {
		return idProducto;
	}
	public void setIdProducto(int idProducto) {
		this.idProducto = idProducto;
	}
	public int getCantidadVendida() {
		return cantidadVendida;
	}
	public void setCantidadVendida(int cantidadVedidad) {
		this.cantidadVendida = cantidadVedidad;
	}
	public float getImporteRecaudado() {
		return importeRecaudado;
	}
	public void setImporteRecaudado(float importeRecaudado) {
		this.importeRecaudado = importeRecaudado;
	}
	@Override
	public String toString() {
		return "Ventas [idProducto=" + idProducto + ", cantidadVedidad=" + cantidadVendida + ", importeRecaudado="
				+ importeRecaudado + "]";
	}
	
	
}