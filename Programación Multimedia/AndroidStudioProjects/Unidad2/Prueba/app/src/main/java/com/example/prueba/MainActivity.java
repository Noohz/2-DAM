package com.example.prueba;

import androidx.annotation.ColorInt;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;

import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.ToggleButton;

public class MainActivity extends AppCompatActivity {

    TextView resultado;
    Button button1;
    ToggleButton toggle1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Asigna el TextView usando su id.
        resultado = findViewById(R.id.texto1);

        // Asigna el Button1 usando su id.
        button1 = findViewById(R.id.button1);

        // Creamos un evento para que al pulsar el boton de apagar cambie el texto del textView.
        button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                resultado.setText("¡Has pulsado el botón de apagar!");
            }
        });

        // Asigna el ToggleButton1 usando su id.
        toggle1 = findViewById(R.id.toggle1);

        // Creamos un evento para que detecte si está pulsado o no y cambie el texto del textView.
        toggle1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (toggle1.isChecked()){ // Como el toggleButton tiene 2 estados usamos el isChecked()
                    resultado.setText("Botón encendido");
                } else
                    resultado.setText("Botón apagado");
            }
        });

    }
}