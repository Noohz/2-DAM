// Aitor Ramos Sánchez

package com.example.ejercicioindicemasacorporal;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    EditText editTextTextNombre, editTextTextAltura, editTextTextPeso;
    Button buttonCalcularIMC;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editTextTextNombre = findViewById(R.id.editTextTextNombre);
        editTextTextAltura = findViewById(R.id.editTextTextAltura);
        editTextTextPeso = findViewById(R.id.editTextTextPeso);
        buttonCalcularIMC = findViewById(R.id.buttonCalcularIMC);

        buttonCalcularIMC.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(MainActivity.this, actividad2.class);
                i.putExtra("nombre", editTextTextNombre.getText().toString());
                i.putExtra("altura", editTextTextAltura.getText().toString());
                i.putExtra("peso", editTextTextPeso.getText().toString());

                startActivity(i);
            }
        });

    }
}