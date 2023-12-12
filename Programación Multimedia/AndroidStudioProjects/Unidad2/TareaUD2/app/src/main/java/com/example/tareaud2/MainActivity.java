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

public class MainActivity extends AppCompatActivity {

    EditText editTextTextUsuario, editTextTextContrasenia;
    Button buttonIniciarSesion, buttonCrearUsuario;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editTextTextUsuario = findViewById(R.id.editTextTextUsuario);
        editTextTextContrasenia = findViewById(R.id.editTextTextContrasenia);
        buttonIniciarSesion = findViewById(R.id.buttonIniciarSesion);
        buttonCrearUsuario = findViewById(R.id.buttonCrearUsuario);

        buttonIniciarSesion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoIniciarSesion();
            }
        });

        buttonCrearUsuario.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoCrearUsuario();
            }
        });
    }

    private void EventoCrearUsuario() {
        Intent mostrarCrearUsuario = new Intent(MainActivity.this, PantallaCrearUsuario.class);
        startActivity(mostrarCrearUsuario);
    }

    private void EventoIniciarSesion() {
        baseBD = new AccesoDatos(this);

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
            Usuario usuario = baseBD.buscarUsuario(editTextTextUsuario.getText().toString(), editTextTextContrasenia.getText().toString());

            if (usuario != null) {
                Intent mostrarActividad2 = new Intent(MainActivity.this, Actividad2.class);
                mostrarActividad2.putExtra("usuario", usuario.getNombre());
                mostrarActividad2.putExtra("contrasenia", usuario.getContrasenia());
                mostrarActividad2.putExtra("email", usuario.getEmail());
                startActivity(mostrarActividad2);
            } else {
                AlertDialog.Builder not2 = new AlertDialog.Builder(MainActivity.this);
                not2.setTitle("Credenciales Incorrectas");
                not2.setMessage("El nombre de usuario o la contraseña son incorrectos.");
                not2.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });
                not2.show();
            }
        }
        editTextTextUsuario.setText("");
        editTextTextContrasenia.setText("");
    }
}