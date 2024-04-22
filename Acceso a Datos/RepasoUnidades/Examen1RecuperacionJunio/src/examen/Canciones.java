package examen;

public class Canciones {

	private int codigo; // 4B
	private int artista; // 4B
	private String titulo; // 100B
	private int duracion; // 4B

	public Canciones() {

	}

	public Canciones(int codigo, int artista, String titulo, int duracion) {
		this.codigo = codigo;
		this.artista = artista;
		this.titulo = titulo;
		this.duracion = duracion;
	}

	public int getCodigo() {
		return codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public int getArtista() {
		return artista;
	}

	public void setArtista(int artista) {
		this.artista = artista;
	}

	public String getTitulo() {
		return titulo;
	}

	public void setTitulo(String titulo) {
		this.titulo = titulo;
	}

	public int getDuracion() {
		return duracion;
	}

	public void setDuracion(int duracion) {
		this.duracion = duracion;
	}

	@Override
	public String toString() {
		return "Canciones [codigo=" + codigo + ", artista=" + artista + ", titulo=" + titulo + ", duracion=" + duracion
				+ "]";
	}
}
