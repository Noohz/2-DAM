package farmacia;

import jakarta.persistence.Column;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;

public class ClaveDetallePedido {
	
	@ManyToOne()
	@JoinColumn(name ="pedido",referencedColumnName = "codigo")
	private Pedido pedido;
	
	@Column(nullable = false)
	private int linea;
	
	public ClaveDetallePedido() {
		
	}

	public ClaveDetallePedido(Pedido pedido, int linea) {
		this.pedido = pedido;
		this.linea = linea;
	}

	public Pedido getPedido() {
		return pedido;
	}

	public void setPedido(Pedido pedido) {
		this.pedido = pedido;
	}

	public int getLinea() {
		return linea;
	}

	public void setLinea(int linea) {
		this.linea = linea;
	}

	@Override
	public String toString() {
		return "ClaveDetallePedido [pedido=" + pedido + ", linea=" + linea + "]";
	}
}
