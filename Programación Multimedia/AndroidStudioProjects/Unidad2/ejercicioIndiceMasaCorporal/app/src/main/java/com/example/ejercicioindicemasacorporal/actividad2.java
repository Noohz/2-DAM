// Aitor Ramos Sánchez

package com.example.ejercicioindicemasacorporal;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.TextView;

public class actividad2 extends AppCompatActivity {

    TextView textViewDatos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad2);

        textViewDatos = findViewById(R.id.textViewDatos);

        String pesoIMC;

        Bundle extras = getIntent().getExtras();
        String nomb = extras.getString("nombre");
        String alt = extras.getString("altura");
        String peso = extras.getString("peso");

        double altD = Double.parseDouble(alt);
        double pesoD = Double.parseDouble(peso);
        double calcPesoAltura = pesoD / (altD * altD);

        double IMC = Math.round(calcPesoAltura * 100.0) / 100.0;

        if (IMC < 16.00) {
             pesoIMC = "Infrapeso: Delgadez Severa";
        } else if (IMC >= 16.00 && IMC <= 16.99) {
            pesoIMC = "Infrapeso: Delgadez moderada";
        } else if (IMC >= 17.00 && IMC <= 18.49) {
            pesoIMC = "Infrapeso: Delgadez aceptable";
        } else if (IMC >= 18.50 && IMC <= 24.99) {
            pesoIMC = "Peso Normal";
        } else if (IMC >= 25.00 && IMC <= 29.99) {
            pesoIMC = "Sobrepeso";
        } else if (IMC >= 30.00 && IMC <= 34.99) {
            pesoIMC = "Obeso: Tipo I";
        } else if (IMC >= 35.00 && IMC <= 40.00) {
            pesoIMC = "Obeso: Tipo II";
        } else {
            pesoIMC = "Obeso: Tipo III";
        }

        textViewDatos.setText(nomb+ " tu IMC indica " +pesoIMC+ "\nAltura: " +alt+ "\nPeso: " +peso+ "\nTu IMC es de: " +IMC);

    }
}