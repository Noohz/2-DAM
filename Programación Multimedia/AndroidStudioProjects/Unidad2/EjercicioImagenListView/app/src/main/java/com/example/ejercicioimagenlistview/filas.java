package com.example.ejercicioimagenlistview;

public class filas {
    String titulo;
    String subtitulo;
    int imagen;

    filas(String titulo, String subtitulo, int imagen) {
        this.titulo = titulo;
        this.subtitulo = subtitulo;
        this.imagen = imagen;
    }

    public String getTitulo() {
        return titulo;
    }

    public String getSubtitulo() {
        return subtitulo;
    }

    public int getImagen() {
        return imagen;
    }
}
