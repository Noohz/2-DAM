package com.example.ejerciciobd_pg10;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;

import java.util.ArrayList;

public class NuevoContacto extends AppCompatActivity {

    Button buttonCrear, buttonCancelar;
    EditText editTextTextNombre, editTextTextTelefono, editTextTextEmail;
    AccesoDatos baseBD;
    MainActivity mA;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nuevo_contacto);

        // findViewByIds
        buttonCrear = findViewById(R.id.buttonCrear);
        buttonCancelar = findViewById(R.id.buttonCancelar);
        editTextTextNombre = findViewById(R.id.editTextTextNombre);
        editTextTextTelefono = findViewById(R.id.editTextTextTelefono);
        editTextTextEmail = findViewById(R.id.editTextTextEmail);

        // Evento boton crear
        buttonCrear.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoCrearContacto();
            }
        });

        buttonCancelar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoBotonCancelar();
            }
        });
    }
    private void EventoBotonCancelar() {
        finish();
    }

    private void EventoCrearContacto() {
        if (editTextTextNombre.getText().toString().isEmpty() || editTextTextTelefono.getText().toString().isEmpty() || editTextTextEmail.getText().toString().isEmpty()) {
            AlertDialog.Builder error = new AlertDialog.Builder(this);
            error.setTitle("Error al crear contacto");
            error.setMessage("No puedes dejar ningún campo vacío");
            error.setCancelable(false);
            error.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            error.show();
        } else {
            baseBD = new AccesoDatos(this);
            Contacto contacto = new Contacto(editTextTextNombre.getText().toString(), editTextTextTelefono.getText().toString(), editTextTextEmail.getText().toString());
            long id = baseBD.ejemploMetodoModificacion(contacto);
            editTextTextNombre.setText("");
            editTextTextTelefono.setText("");
            editTextTextEmail.setText("");
            setResult(RESULT_OK);
        }
    }
}