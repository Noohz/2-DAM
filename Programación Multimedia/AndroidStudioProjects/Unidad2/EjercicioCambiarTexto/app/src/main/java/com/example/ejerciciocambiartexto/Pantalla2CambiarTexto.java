package com.example.ejerciciocambiartexto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class Pantalla2CambiarTexto extends AppCompatActivity {

    EditText editTextTextCambiarTexto;
    Button buttonModificar, buttonCancelar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla2_cambiar_texto);

        editTextTextCambiarTexto = findViewById(R.id.editTextTextCambiarTexto);
        buttonModificar = findViewById(R.id.buttonModificar);
        buttonCancelar = findViewById(R.id.buttonCancelar);

        Bundle datos  = getIntent().getExtras();
        editTextTextCambiarTexto.setText(datos.getString("texto"));

        buttonModificar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                modificar();
            }
        });

        buttonCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cancelar();
            }
        });

    }

    private void cancelar() {

        Intent miIntent = new Intent(getApplicationContext(), MainActivity.class);
        setResult(RESULT_CANCELED, miIntent);
        finish();

    }

    private void modificar() {

        Intent miIntent = new Intent(getApplicationContext(), MainActivity.class);
        miIntent.putExtra("nuevoTexto", editTextTextCambiarTexto.getText().toString());
        setResult(RESULT_OK, miIntent);
        finish();

    }
}