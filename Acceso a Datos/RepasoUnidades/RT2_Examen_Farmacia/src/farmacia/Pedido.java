package farmacia;

import java.util.Date;

public class Pedido {
	private int codigo;
	private Date fecha;
	private int codFarmacia;
	private boolean cerrado;
	private int numArt;
	private float total;

	public Pedido() {

	}

	public Pedido(int codigo, Date fecha, int codFarmacia, boolean cerrado, int numArt, float total) {
		this.codigo = codigo;
		this.fecha = fecha;
		this.codFarmacia = codFarmacia;
		this.cerrado = cerrado;
		this.numArt = numArt;
		this.total = total;
	}

	public int getCodigo() {
		return codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public Date getFecha() {
		return fecha;
	}

	public void setFecha(Date fecha) {
		this.fecha = fecha;
	}

	public int getCodFarmacia() {
		return codFarmacia;
	}

	public void setCodFarmacia(int codFarmacia) {
		this.codFarmacia = codFarmacia;
	}

	public boolean isCerrado() {
		return cerrado;
	}

	public void setCerrado(boolean cerrado) {
		this.cerrado = cerrado;
	}

	public int getNumArt() {
		return numArt;
	}

	public void setNumArt(int numArt) {
		this.numArt = numArt;
	}

	public float getTotal() {
		return total;
	}

	public void setTotal(float total) {
		this.total = total;
	}

	@Override
	public String toString() {
		return "Pedido [codigo=" + codigo + ", fecha=" + fecha + ", codFarmacia=" + codFarmacia + ", cerrado=" + cerrado
				+ ", numArt=" + numArt + ", total=" + total + "]";
	}
}
