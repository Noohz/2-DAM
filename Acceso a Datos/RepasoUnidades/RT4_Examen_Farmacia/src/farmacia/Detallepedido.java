package farmacia;

import java.util.ArrayList;
import java.util.List;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.EmbeddedId;
import jakarta.persistence.Entity;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;

@Entity
@Table
public class Detallepedido {
	@EmbeddedId
	private ClaveDetallePedido claveDetallePedido;

	@ManyToOne
	@JoinColumn(name = "articulo", referencedColumnName = "codigo")
	private Articulo articulo;

	@Column(nullable = false)
	private float precioUdad;

	@Column(nullable = false)
	private int cantidad;

	@OneToMany(cascade = CascadeType.ALL, mappedBy = "codigo")
	private List<Articulo> listaArticulos = new ArrayList<Articulo>();
	
	public Detallepedido() {

	}

	public Detallepedido(ClaveDetallePedido claveDetallePedido, Articulo articulo, float precioUdad, int cantidad) {
		this.claveDetallePedido = claveDetallePedido;
		this.articulo = articulo;
		this.precioUdad = precioUdad;
		this.cantidad = cantidad;
	}

	public ClaveDetallePedido getClaveDetallePedido() {
		return claveDetallePedido;
	}

	public void setClaveDetallePedido(ClaveDetallePedido claveDetallePedido) {
		this.claveDetallePedido = claveDetallePedido;
	}

	public Articulo getArticulo() {
		return articulo;
	}

	public void setArticulo(Articulo articulo) {
		this.articulo = articulo;
	}

	public float getPrecioUdad() {
		return precioUdad;
	}

	public void setPrecioUdad(float precioUdad) {
		this.precioUdad = precioUdad;
	}

	public int getCantidad() {
		return cantidad;
	}

	public void setCantidad(int cantidad) {
		this.cantidad = cantidad;
	}

	@Override
	public String toString() {
		return "Detallepedido [claveDetallePedido=" + claveDetallePedido + ", articulo=" + articulo + ", precioUdad="
				+ precioUdad + ", cantidad=" + cantidad + "]";
	}
}
