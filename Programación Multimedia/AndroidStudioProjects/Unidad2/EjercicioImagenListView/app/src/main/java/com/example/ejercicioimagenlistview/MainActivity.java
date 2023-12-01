package com.example.ejercicioimagenlistview;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    ListView lw1;
    Spinner spinnerCiudad;

    boolean boolInicio = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lw1 = (ListView) findViewById(R.id.listv1);
        lw1.setAdapter(new adaptador(this));

        // Responde a las selecciones del usuario. Evento onItemClick
        lw1.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                // getItemAtPosition nos devuelve el objeto de la clase filas de la posición seleccionada
                filas fil = (filas) lw1.getItemAtPosition(position);

                // Con fil podemos sacar el título y el subtítulo
                Toast.makeText(getApplicationContext(), "Título: " + fil.titulo + " \nSubtítulo: " + fil.subtitulo, Toast.LENGTH_LONG).show();
            }
        });

        spinnerCiudad = (Spinner) findViewById(R.id.spinnerCiudad);
        spinnerCiudad.setAdapter(new adaptador2(this));

        spinnerCiudad.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

                if (boolInicio) {
                    boolInicio = false;
                } else {
                    ciudades ciudad = (ciudades) parent.getItemAtPosition(position);
                    String nombreCiudad = ciudad.titulo;
                    Toast.makeText(getApplicationContext(), "Ciudad: " + nombreCiudad, Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
    }
}