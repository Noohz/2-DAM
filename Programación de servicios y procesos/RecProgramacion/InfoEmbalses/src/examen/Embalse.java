package examen;

import java.io.Serializable;

public class Embalse implements Serializable {

	String nombre;
	int capacidad;
	int nivelActual;
	int variacionUltimaMedida;
	String confederacionHidrografica;
	String provincia;
	double porcentaje;

	public Embalse() {
	}

	public Embalse(String nombre, int capacidad, int nivelActual, int variacionUltimaMedida,
			String confederacionHidrografica, String provincia) {
		this.nombre = nombre;
		this.capacidad = capacidad;
		this.nivelActual = nivelActual;
		this.variacionUltimaMedida = variacionUltimaMedida;
		this.confederacionHidrografica = confederacionHidrografica;
		this.provincia = provincia;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public int getCapacidad() {
		return capacidad;
	}

	public void setCapacidad(int capacidad) {
		this.capacidad = capacidad;
	}

	public int getNivelActual() {
		return nivelActual;
	}

	public void setNivelActual(int nivelActual) {
		this.nivelActual = nivelActual;
	}

	public int getVariacionUltimaMedida() {
		return variacionUltimaMedida = nivelActual - capacidad;
	}

	public void setVariacionUltimaMedida(int variacionUltimaMedida) {
		this.variacionUltimaMedida = variacionUltimaMedida;
	}

	public String getConfederacionHidrografica() {
		return confederacionHidrografica;
	}

	public void setConfederacionHidrografica(String confederacionHidrografica) {
		this.confederacionHidrografica = confederacionHidrografica;
	}

	public String getProvincia() {
		return provincia;
	}

	public void setProvincia(String provincia) {
		this.provincia = provincia;
	}

	public double getPorcentaje() {
		return porcentaje = (((double) nivelActual) / capacidad) * 100;
	}

	public void setPorcentaje(int porcentaje) {
		this.porcentaje = porcentaje;
	}

	@Override
	public String toString() {
		return "Embalse [nombre=" + nombre + ", capacidad=" + capacidad + ", nivelActual=" + nivelActual
				+ ", variacionUltimaMedida=" + variacionUltimaMedida + ", confederacionHidrografica="
				+ confederacionHidrografica + ", provincia=" + provincia + "]";
	}
}
