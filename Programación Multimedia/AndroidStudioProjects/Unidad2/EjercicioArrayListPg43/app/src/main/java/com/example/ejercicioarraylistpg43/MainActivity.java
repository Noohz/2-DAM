package com.example.ejercicioarraylistpg43;
// Aitor Ramos Sánchez

import android.content.DialogInterface;
import android.os.Bundle;
import android.util.SparseBooleanArray;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.Arrays;

public class MainActivity extends AppCompatActivity {

    ListView listViewSistemaSolar;
    Button buttonMostrarOpciones;

    ArrayList<String> planetas = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listViewSistemaSolar = findViewById(R.id.listViewSistemaSolar);
        buttonMostrarOpciones = findViewById(R.id.buttonMostrarOpciones);

        // Para utilizar el fichero xml.
        //ArrayAdapter adaptador = ArrayAdapter.createFromResource(MainActivity.this, R.array.sistema_solar, android.R.layout.simple_list_item_multiple_choice);
        //listViewSistemaSolar.setAdapter(adaptador);

        // Para utilizar el array.
        planetas = new ArrayList<>(new ArrayList<>(Arrays.asList(getResources().getStringArray(R.array.sistema_solar)))); // Le asignamos el contenido del xml donde estaban los nombres del listView al Array
        ArrayAdapter<String> adaptadorPlanetas = new ArrayAdapter<>(MainActivity.this, android.R.layout.simple_list_item_multiple_choice, planetas); // Creamos el adaptador y la forma en la que se va a mostrar el contenido del array.
        listViewSistemaSolar.setAdapter(adaptadorPlanetas); // Asignamos el adaptador al listView para que se muestre el contenido.


        listViewSistemaSolar.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                clickListView(parent, position);
            }
        });

        buttonMostrarOpciones.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mostrarOpcionesSeleccionadas();
            }
        });

        listViewSistemaSolar.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {

                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                builder.setMessage("¿Deseas eliminar " + parent.getItemAtPosition(position) + "?");
                builder.setPositiveButton("Sí", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        borrarElementoListView(parent, position, adaptadorPlanetas);
                    }
                });
                builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });
                builder.show();
                return true;
            }
        });
    }

    // Elimina la opción en la que se mantenga el click.
    private void borrarElementoListView(AdapterView<?> parent, int position, ArrayAdapter adaptadorPlanetas) {
        planetas.remove(parent.getItemAtPosition(position));
        adaptadorPlanetas.notifyDataSetChanged();
    }

    // Muestra un toast con las opciones seleccionadas del listView.
    private void mostrarOpcionesSeleccionadas() {
        String opcion = "";
        SparseBooleanArray posSeleccionada = listViewSistemaSolar.getCheckedItemPositions();

        for (int i = 0; i < posSeleccionada.size(); i++) {
            int posAdaptador = posSeleccionada.keyAt(i);

            if (posSeleccionada.get(posAdaptador)) {
                opcion += listViewSistemaSolar.getItemAtPosition(posAdaptador);

                if (i < posSeleccionada.size() - 1) {
                    opcion += ", ";
                }
            }
        }
        Toast.makeText(MainActivity.this, "Se han seleccionado los Sistemas Solares: " + opcion, Toast.LENGTH_LONG).show();
    }

    // Muestra un toast al hacer click en un elemento del listView.
    private void clickListView(AdapterView<?> parent, int position) {
        String sistSolar = parent.getItemAtPosition(position).toString();

        Toast.makeText(MainActivity.this, "Has seleccionado el sistema solar: " + sistSolar, Toast.LENGTH_SHORT).show();
    }
}