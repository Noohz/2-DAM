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

public class adaptador2 extends BaseAdapter {

    ArrayList<ciudades> lista;

    Context contexto;

    adaptador2(Context c) {
        contexto = c;

        lista = new ArrayList<ciudades>();

        Resources res = c.getResources();
        String[] titulos = res.getStringArray(R.array.ciudades);
        int[] imagenes = {R.drawable.madrid, R.drawable.bilbao, R.drawable.sevilla, R.drawable.valencia};

        for (int i = 0; i < titulos.length; i++) {
            lista.add(new ciudades(titulos[i], imagenes[i]));
        }
    }

    @Override
    public int getCount() {
        return lista.size();
    }

    @Override
    public Object getItem(int position) {
        return lista.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflar = (LayoutInflater) contexto.getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        View list = inflar.inflate(R.layout.ciudades, parent, false);

        TextView titulo = (TextView) list.findViewById(R.id.textViewNombre);
        ImageView imagen = (ImageView) list.findViewById(R.id.imageViewCiudad);

        ciudades temporal = lista.get(position);

        titulo.setText(temporal.titulo);
        imagen.setImageResource(temporal.imagen);

        return list;
    }
}
