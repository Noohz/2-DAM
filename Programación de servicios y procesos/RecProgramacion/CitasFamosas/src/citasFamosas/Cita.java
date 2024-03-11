package citasFamosas;

import java.io.Serializable;

public class Cita implements Serializable{	
	String autor;
	String cita;
	int idioma;
	
	public Cita() {
		
	}
	
	public Cita(String autor, String cita, int idioma) {
		super();
		this.autor = autor;
		this.cita = cita;
		this.idioma = idioma;
	}

	public String getAutor() {
		return autor;
	}

	public void setAutor(String autor) {
		this.autor = autor;
	}

	public String getCita() {
		return cita;
	}

	public void setCita(String cita) {
		this.cita = cita;
	}

	public int getIdioma() {
		return idioma;
	}

	public void setIdioma(int idioma) {
		this.idioma = idioma;
	}

	/**
	 * toString que luego usaré en el método mostrar para mostrar el contenido del arrayList.
	 */
	@Override
	public String toString() {
		return autor + "\t" + cita + "\t" + idioma;
	}	
}
