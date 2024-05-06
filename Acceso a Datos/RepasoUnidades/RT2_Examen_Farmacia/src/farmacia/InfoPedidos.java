package farmacia;

import java.util.Date;

public class InfoPedidos {
	private int anio;
	private int mes;
	private int numArticulos;
	private Date fechaPrimerPedido;
	private Date fechaUltimoPedido;
	private int importe;

	public InfoPedidos() {

	}

	public InfoPedidos(int anio, int mes, int numArticulos, Date fechaPrimerPedido, Date fechaUltimoPedido,
			int importe) {
		this.anio = anio;
		this.mes = mes;
		this.numArticulos = numArticulos;
		this.fechaPrimerPedido = fechaPrimerPedido;
		this.fechaUltimoPedido = fechaUltimoPedido;
		this.importe = importe;
	}

	public int getAnio() {
		return anio;
	}

	public void setAnio(int anio) {
		this.anio = anio;
	}

	public int getMes() {
		return mes;
	}

	public void setMes(int mes) {
		this.mes = mes;
	}

	public int getNumArticulos() {
		return numArticulos;
	}

	public void setNumArticulos(int numArticulos) {
		this.numArticulos = numArticulos;
	}

	public Date getFechaPrimerPedido() {
		return fechaPrimerPedido;
	}

	public void setFechaPrimerPedido(Date fechaPrimerPedido) {
		this.fechaPrimerPedido = fechaPrimerPedido;
	}

	public Date getFechaUltimoPedido() {
		return fechaUltimoPedido;
	}

	public void setFechaUltimoPedido(Date fechaUltimoPedido) {
		this.fechaUltimoPedido = fechaUltimoPedido;
	}

	public int getImporte() {
		return importe;
	}

	public void setImporte(int importe) {
		this.importe = importe;
	}

	@Override
	public String toString() {
		return "InfoPedidos [anio=" + anio + ", mes=" + mes + ", numArticulos=" + numArticulos + ", fechaPrimerPedido="
				+ fechaPrimerPedido + ", fechaUltimoPedido=" + fechaUltimoPedido + ", importe=" + importe + "]";
	}

}
