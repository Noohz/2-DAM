package com.example.examenud2;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.TextView;

public class actividadReserva extends AppCompatActivity {

    TextView textViewDatosReserva;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad_reserva);

        textViewDatosReserva = findViewById(R.id.textViewDatosReserva);

        Bundle extras = getIntent().getExtras();
        String l = extras.getString("lugar");
        String p = extras.getString("precio");
        String n = extras.getString("numEntradas");
        String t = extras.getString("turno");

        textViewDatosReserva.setText("Lugar: " +l+ "\nPrecio Entrada: " +p+ "\nNº Entradas Reservadas: " +n+ "\nTurno: " +t);
    }
}