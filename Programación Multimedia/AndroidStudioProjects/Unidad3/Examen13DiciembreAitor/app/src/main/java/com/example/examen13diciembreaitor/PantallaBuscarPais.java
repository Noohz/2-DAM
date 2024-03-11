package com.example.examen13diciembreaitor;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class PantallaBuscarPais extends AppCompatActivity {

    EditText editTextTextBuscarPais;
    Button buttonBuscar, buttonVolver;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla_buscar_pais);

        editTextTextBuscarPais = findViewById(R.id.editTextTextBuscarPais);
        buttonBuscar = findViewById(R.id.buttonBuscar);
        buttonVolver = findViewById(R.id.buttonVolver);

        buttonBuscar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoBuscarPais();
            }
        });

        buttonVolver.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private void EventoBuscarPais() {

        if (editTextTextBuscarPais.getText().toString().isEmpty()) {
            AlertDialog.Builder error = new AlertDialog.Builder(this);
            error.setTitle("Error");
            error.setMessage("El campo no puede estar vacío.");
            error.setCancelable(false);
            error.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            error.show();
        } else {
            String paisABuscar = editTextTextBuscarPais.getText().toString();
            baseBD.buscarPais(paisABuscar);
        }
    }
}