package farmacia;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

@Entity
@Table
public class Pedido {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int codigo;
	
	@Column(nullable = false)
	@Temporal(TemporalType.DATE)
	private Date fecha;
	
	@ManyToOne
	@JoinColumn(name ="farmacia",referencedColumnName = "codigo")
	private Farmacia farmacia;
	
	@Column(nullable = false)
	private boolean cerrado;
	
	@Column(nullable = false)
	private int numArt;
	
	@Column(nullable = false)
	private float total;

	@OneToMany(cascade = CascadeType.ALL, mappedBy = "claveDetallePedido.pedido")
	private List<Detallepedido> listaDetallePedido = new ArrayList<Detallepedido>();
	
	public Pedido() {

	}

	public Pedido(int codigo, Date fecha, Farmacia farmacia, boolean cerrado, int numArt, float total) {
		this.codigo = codigo;
		this.fecha = fecha;
		this.farmacia = farmacia;
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

	public Farmacia getFarmacia() {
		return farmacia;
	}

	public void setFarmacia(Farmacia farmacia) {
		this.farmacia = farmacia;
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

	public List<Detallepedido> getListaDetallePedido() {
		return listaDetallePedido;
	}

	public void setListaDetallePedido(List<Detallepedido> listaDetallePedido) {
		this.listaDetallePedido = listaDetallePedido;
	}

	@Override
	public String toString() {
		return "Pedido [codigo=" + codigo + ", fecha=" + fecha + ", farmacia=" + farmacia + ", cerrado=" + cerrado
				+ ", numArt=" + numArt + ", total=" + total + "]";
		
		
	}
}
