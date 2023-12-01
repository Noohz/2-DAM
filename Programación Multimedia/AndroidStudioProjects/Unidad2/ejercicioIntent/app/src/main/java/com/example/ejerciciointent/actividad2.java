package com.example.ejerciciointent;

import androidx.appcompat.app.AppCompatActivity;


import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class actividad2 extends AppCompatActivity {

    Button buttonAtras;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad2);

        buttonAtras = findViewById(R.id.buttonAtras);



        if (getIntent().hasExtra("nombre") && getIntent().hasExtra("apellidos")) {
            Bundle extras = getIntent().getExtras();
            String textoDatosNombre = extras.getString("nombre");
            String textoDatosApellidos = extras.getString("apellidos");


            String textoDatosMostrar = "Nombre: " +textoDatosNombre+ "\nApellidos: " +textoDatosApellidos;

            Toast.makeText(actividad2.this, textoDatosMostrar, Toast.LENGTH_LONG).show();
        }

        buttonAtras.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                atras();
            }
        });

    }

    private void atras() {
        Intent intA1Atras = new Intent(actividad2.this, MainActivity.class);
        startActivity(intA1Atras);
    }
}