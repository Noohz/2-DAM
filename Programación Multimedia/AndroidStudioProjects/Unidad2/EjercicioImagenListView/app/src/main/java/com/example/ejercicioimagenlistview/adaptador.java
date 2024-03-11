package com.example.ejercicioimagenlistview;

import android.content.Context;
import android.content.res.Resources;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class adaptador extends BaseAdapter {

    ArrayList<filas> lista;

    // Almacenamos el contexto de la aplicación.
    Context contexto;

    // Constructor
    adaptador(Context c) {
        // Recogemos el contexto que nos pasan como parámetro desde la llamada
        contexto = c;

        // Definimos un arraylist donde almacenamos la terna de elementos (objetos de la clase contenedora)
        lista = new ArrayList<filas>();

        // Definimos un objeto Resources para poder acceder a los arrays de strings y a los drawbles
        Resources res = c.getResources();
        String[] titulos = res.getStringArray(R.array.titulos);
        String[] subtitulos = res.getStringArray(R.array.subtitulos);
        int[] imagenes = {R.drawable.whatsapp, R.drawable.facebook, R.drawable.youtube, R.drawable.paypal};

        // Creamos un arraylist de objetos de la clase contenedora a partir de los arrays
        for (int i = 0; i < titulos.length; i++) {
            lista.add(new filas(titulos[i], subtitulos[i], imagenes[i]));
        }
    }

    @Override
    // Método que devuelve el número de elementos
    public int getCount() {
        return lista.size();
    }

    @Override
    // Devuelve el itme indicado por la posición
    public Object getItem(int position) {
        return lista.get(position);
    }

    @Override
    // Devuelve la posición
    public long getItemId(int position) {
        return position;
    }

    @Override
    // Método getView
    public View getView(int position, View converView, ViewGroup parent) {
        // Definimos un LayoutInflater para poder cargar el custom layout de la fila
        LayoutInflater inflar = (LayoutInflater) contexto.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        // Inflamos el custom layout
        View list = inflar.inflate(R.layout.fila, parent, false);

        // Enlazamos a través de la clase R los elementos del custom layout
        TextView titulo = (TextView) list.findViewById(R.id.textViewTitulo);
        TextView subtitulo = (TextView) list.findViewById(R.id.textViewSubtitulos);
        ImageView imagen = (ImageView) list.findViewById(R.id.imageViewImagen);

        // Mostrar el elemento definido en position
        // En un objeto de la clase contenedora recogemos el elemento n
        filas temporal = lista.get(position);

        // Y asignamos su contenido a los elementos del custom layout
        titulo.setText(temporal.titulo);
        subtitulo.setText(temporal.subtitulo);
        imagen.setImageResource(temporal.imagen);

        return list;
    }
}
