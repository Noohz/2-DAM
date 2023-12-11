package com.example.tareaud2;

// Aitor Ramos Sánchez

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;

public class MainActivity extends AppCompatActivity {

    EditText editTextTextUsuario, editTextTextContrasenia;
    Button buttonIniciarSesion;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editTextTextUsuario = findViewById(R.id.editTextTextUsuario);
        editTextTextContrasenia = findViewById(R.id.editTextTextContrasenia);
        buttonIniciarSesion = findViewById(R.id.buttonIniciarSesion);

        buttonIniciarSesion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoIniciarSesion();
            }
        });

    }

    private void EventoIniciarSesion() {

        if (editTextTextUsuario.getText().toString().isEmpty() || editTextTextContrasenia.getText().toString().isEmpty()) {
            AlertDialog.Builder not1 = new AlertDialog.Builder(MainActivity.this);
            not1.setTitle("Error");
            not1.setMessage("Por favor, introduce el usuario y la contraseña");
            not1.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            not1.show();
        } else {
            Intent mostrarActividad2 = new Intent(MainActivity.this, Actividad2.class);
            mostrarActividad2.putExtra("usuario", editTextTextUsuario.getText().toString());
            startActivity(mostrarActividad2);
        }
        editTextTextUsuario.setText("");
        editTextTextContrasenia.setText("");
    }
}