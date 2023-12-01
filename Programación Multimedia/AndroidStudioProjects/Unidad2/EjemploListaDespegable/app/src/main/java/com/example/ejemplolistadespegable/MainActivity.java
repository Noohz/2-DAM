package com.example.ejemplolistadespegable;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    TextView textViewTexto;
    Spinner spinnerColores, spinnerMeses;

    ArrayList<String> arrayMeses = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textViewTexto = findViewById(R.id.textViewTexto);
        spinnerColores = findViewById(R.id.spinnerColores);
        spinnerMeses = findViewById(R.id.spinnerMeses);

        ArrayAdapter adaptador = ArrayAdapter.createFromResource(MainActivity.this, R.array.colores, android.R.layout.simple_spinner_dropdown_item);
        spinnerColores.setAdapter(adaptador);

        spinnerColores.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String color = parent.getItemAtPosition(position).toString();

                if (color.equals("Rojo")) {
                    textViewTexto.setTextColor(Color.RED);
                    textViewTexto.setText("Texto de color rojo");
                }

                if (color.equals("Verde")) {
                    textViewTexto.setTextColor(Color.GREEN);
                    textViewTexto.setText("Texto de color verde");
                }

                if (color.equals("Azul")) {
                    textViewTexto.setTextColor(Color.BLUE);
                    textViewTexto.setText("Texto de color azul");
                }

                if (color.equals("Naranja")) {
                    textViewTexto.setTextColor(Color.rgb(255, 117, 20));
                    textViewTexto.setText("Texto de color naranja");
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        arrayMeses.add("Enero"); arrayMeses.add("Febrero"); arrayMeses.add("Marzo"); arrayMeses.add("Abril"); arrayMeses.add("Mayo"); arrayMeses.add("Junio"); arrayMeses.add("Julio"); arrayMeses.add("Agosto"); arrayMeses.add("Septiembre"); arrayMeses.add("Octubre"); arrayMeses.add("Noviembre"); arrayMeses.add("Diciembre");
        ArrayAdapter<String> adaptadorMeses = new ArrayAdapter<>(MainActivity.this, android.R.layout.simple_spinner_dropdown_item, arrayMeses);
        spinnerMeses.setAdapter(adaptadorMeses);

        spinnerMeses.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Toast.makeText(MainActivity.this, "Has seleccionado: " +parent.getItemAtPosition(position), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
    }
}