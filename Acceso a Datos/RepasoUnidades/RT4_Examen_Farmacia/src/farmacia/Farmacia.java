package farmacia;

import java.util.ArrayList;
import java.util.List;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;

@Entity
@Table
public class Farmacia {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int codigo;

	@Column(nullable = false)
	private String nombre;

	@Column(nullable = false)
	private String cif;

	@Column(nullable = false)
	private String direccion;

	@OneToMany(cascade = CascadeType.ALL, mappedBy = "farmacia")
	private List<Pedido> listaPedidos = new ArrayList<Pedido>();

	public Farmacia() {

	}

	public Farmacia(int codigo, String nombre, String cif, String direccion) {
		this.codigo = codigo;
		this.nombre = nombre;
		this.cif = cif;
		this.direccion = direccion;
	}

	public int getCodigo() {
		return codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getCif() {
		return cif;
	}

	public void setCif(String cif) {
		this.cif = cif;
	}

	public String getDireccion() {
		return direccion;
	}

	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}

	public List<Pedido> getListaPedidos() {
		return listaPedidos;
	}

	public void setListaPedidos(List<Pedido> listaPedidos) {
		this.listaPedidos = listaPedidos;
	}

	@Override
	public String toString() {
		String resultado = "Farmacia [codigo=" + codigo + ", nombre=" + nombre + ", cif=" + cif + ", direccion="
				+ direccion + "]";

		for (Pedido pedido : listaPedidos) {
			resultado += "\n" + pedido;
		}
		return resultado;
	}
}
