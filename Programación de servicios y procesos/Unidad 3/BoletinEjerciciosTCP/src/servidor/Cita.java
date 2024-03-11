package servidor;

public class Cita {
	private String autor;
    private String texto;
    private int idioma;

    public Cita(String autor, String texto, int idioma) {
        this.autor = autor;
        this.texto = texto;
        this.idioma = idioma;
    }

    public String getAutor() {
        return autor;
    }

    public String getTexto() {
        return texto;
    }

    public int getIdioma() {
        return idioma;
    }
}
