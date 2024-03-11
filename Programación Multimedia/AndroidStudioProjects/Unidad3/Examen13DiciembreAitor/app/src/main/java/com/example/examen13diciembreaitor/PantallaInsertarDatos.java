package com.example.examen13diciembreaitor;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class PantallaInsertarDatos extends AppCompatActivity {

    EditText editTextTextNombrePais, editTextTextCapital, editTextTextContinente, editTextTextNumHabitantes;
    Button buttonAceptar, buttonCancelar;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla_insertar_datos);

        editTextTextNombrePais = findViewById(R.id.editTextTextNombrePais);
        editTextTextCapital = findViewById(R.id.editTextTextCapital);
        editTextTextContinente = findViewById(R.id.editTextTextContinente);
        editTextTextNumHabitantes = findViewById(R.id.editTextTextNumHabitantes);
        buttonAceptar = findViewById(R.id.buttonAceptar);
        buttonCancelar = findViewById(R.id.buttonCancelar);

        baseBD = new AccesoDatos(this);

        buttonAceptar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoInsertarDatos();
            }
        });

        buttonCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private void EventoInsertarDatos() {

        if (editTextTextNombrePais.getText().toString().isEmpty() || editTextTextCapital.getText().toString().isEmpty() || editTextTextContinente.getText().toString().isEmpty() || editTextTextNumHabitantes.getText().toString().isEmpty()) {
            AlertDialog.Builder error = new AlertDialog.Builder(this);
            error.setTitle("Error");
            error.setMessage("No se puede dejar ningún campo vacío.");
            error.setCancelable(false);
            error.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            error.show();
        } else {
            Pais pais = new Pais(editTextTextNombrePais.getText().toString(), editTextTextCapital.getText().toString(), editTextTextContinente.getText().toString(), Integer.parseInt(editTextTextNumHabitantes.getText().toString()));
            baseBD.InsertarDatosBD(pais);
            finish();
        }
    }
}