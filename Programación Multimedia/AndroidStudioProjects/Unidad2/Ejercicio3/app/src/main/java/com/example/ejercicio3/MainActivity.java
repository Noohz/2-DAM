package com.example.ejercicio3;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    EditText editTextNombre, editTextEmail, editTextTlf;
    TextView textViewResultado;
    Button btnMostrar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editTextNombre = findViewById(R.id.editTextNombre);
        editTextEmail = findViewById(R.id.editTextEmail);
        editTextTlf = findViewById(R.id.editTextTlf);

        textViewResultado = findViewById(R.id.textViewResultado);

        btnMostrar = findViewById(R.id.btnMostrar);

        btnMostrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                textViewResultado.setText("Nombre: " + editTextNombre.getText() + "\nEmail: " + editTextEmail.getText() + "\nTeléfono: " + editTextTlf.getText());
            }
        });

    }
}