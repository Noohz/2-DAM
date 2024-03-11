package com.example.ejercicio2cambiartexto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class ejercicio2Actividad2CambarTexto extends AppCompatActivity {

    EditText editTextTextNombre, editTextTextApellidos;
    Button buttonAceptar, buttonCancelar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ejercicio2_actividad2_cambar_texto);

        editTextTextNombre = findViewById(R.id.editTextTextNombre);
        editTextTextApellidos = findViewById(R.id.editTextTextApellidos);
        buttonAceptar = findViewById(R.id.buttonAceptar);
        buttonCancelar = findViewById(R.id.buttonCancelar);

        buttonAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                enviarDatosContacto();
            }
        });

        buttonCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                cancelarProceso();
            }
        });
    }

    private void cancelarProceso() {

        finish();

    }

    private void enviarDatosContacto() {

        String nombre = editTextTextNombre.getText().toString();
        String apellidos = editTextTextApellidos.getText().toString();

        if (editTextTextNombre.getText().toString().isEmpty() && editTextTextApellidos.getText().toString().isEmpty()) {
            Toast msgError = Toast.makeText(ejercicio2Actividad2CambarTexto.this, "Error, no puedes dejar ningún campo vacio", Toast.LENGTH_LONG);
            msgError.show();
        } else if (!nombre.matches("^[a-zA-Z]+$") || !apellidos.matches("^[a-zA-Z]+$")) {
            Toast msgError = Toast.makeText(ejercicio2Actividad2CambarTexto.this, "Error, los campos solo deben contener letras", Toast.LENGTH_LONG);
            msgError.show();
        } else {
            Intent pantalla2 = new Intent();
            pantalla2.putExtra("nombre", nombre);
            pantalla2.putExtra("apellidos", apellidos);

            setResult(RESULT_OK, pantalla2);
            finish();
        }

    }
}