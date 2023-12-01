package com.example.ejerciciointent;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

// Aitor Ramos Sánchez
public class MainActivity extends AppCompatActivity {

    TextView textViewNombre, textViewApellidos;
    EditText editTextTextNombre, editTextTextApellidos;
    Button buttonAceptar, buttonSiguiente;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonAceptar = findViewById(R.id.buttonAceptar);
        buttonSiguiente = findViewById(R.id.buttonSiguiente);
        editTextTextNombre = findViewById(R.id.editTextTextNombre);
        editTextTextApellidos = findViewById(R.id.editTextTextApellidos);

        buttonAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                aceptar();

            }
        });

        buttonSiguiente.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                siguiente();
            }
        });
    }

    private void siguiente() {

        Intent intA2Siguiente = new Intent(MainActivity.this, actividad2.class);
        startActivity(intA2Siguiente);
    }

    private void aceptar() {

        Intent intA2Aceptar = new Intent(MainActivity.this, actividad2.class);
        intA2Aceptar.putExtra("nombre", editTextTextNombre.getText().toString());
        intA2Aceptar.putExtra("apellidos", editTextTextApellidos.getText().toString());
        startActivity(intA2Aceptar);

    }
}