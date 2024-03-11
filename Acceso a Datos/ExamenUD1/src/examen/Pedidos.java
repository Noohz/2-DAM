package examen;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Pedidos implements Serializable {
	private static final long serialVersionUID = 2984949755052765388L;

	int codPedido;
	Date fecha;
	int codEmpleado;
	int codProducto;
	int cantidad;
	float precioUdad;

	public Pedidos() {

	}

	public Pedidos(int codPedido, Date fecha, int codEmpleado, int codProducto, int cantidad, float precioUdad) {
		this.codPedido = codPedido;
		this.fecha = fecha;
		this.codEmpleado = codEmpleado;
		this.codProducto = codProducto;
		this.cantidad = cantidad;
		this.precioUdad = precioUdad;
	}

	public int getCodPedido() {
		return codPedido;
	}

	public void setCodPedido(int codPedido) {
		this.codPedido = codPedido;
	}

	public Date getFecha() {
		return fecha;
	}

	public void setFecha(Date fecha) {
		this.fecha = fecha;
	}

	public int getCodEmpleado() {
		return codEmpleado;
	}

	public void setCodEmpleado(int codEmpleado) {
		this.codEmpleado = codEmpleado;
	}

	public int getCodProducto() {
		return codProducto;
	}

	public void setCodProducto(int codProducto) {
		this.codProducto = codProducto;
	}

	public int getCantidad() {
		return cantidad;
	}

	public void setCantidad(int cantidad) {
		this.cantidad = cantidad;
	}

	public float getPrecioUdad() {
		return precioUdad;
	}

	public void setPrecioUdad(float precioUdad) {
		this.precioUdad = precioUdad;
	}

	@Override
	public String toString() {
		SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yy");
		return "Pedidos [codPedido=" + codPedido + ", fecha=" + formato.format(fecha) + ", codEmpleado=" + codEmpleado
				+ ", codProducto=" + codProducto + ", cantidad=" + cantidad + ", precioUdad=" + precioUdad + "]";
	}

}
