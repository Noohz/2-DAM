package McBurguer;

import java.util.ArrayList;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementWrapper;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement
@XmlType (propOrder = {"anio", "mes", "listaProductos"})
public class McBurgerXML {
	private int anio;
	private int mes;
	private ArrayList<Producto> listaProductos;

	public McBurgerXML() {

	}

	public McBurgerXML(int anio, int mes, ArrayList<Producto> listaProductos) {
		this.anio = anio;
		this.mes = mes;
		this.listaProductos = listaProductos;
	}

	@XmlElement (name = "año")
	public int getAnio() {
		return anio;
	}

	public void setAnio(int anio) {
		this.anio = anio;
	}

	@XmlElement
	public int getMes() {
		return mes;
	}

	public void setMes(int mes) {
		this.mes = mes;
	}

	@XmlElementWrapper (name = "listaProductos")
	@XmlElement (name = "producto")
	public ArrayList<Producto> getListaProductos() {
		return listaProductos;
	}

	public void setListaProductos(ArrayList<Producto> listaProductos) {
		this.listaProductos = listaProductos;
	}

}
