package com.example.ejerciciobd_pg10;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class ModificarContacto extends AppCompatActivity {

    EditText editTextTextIdMod, editTextTextNombreMod, editTextTextTelefonoMod, editTextTextEmailMod;
    Button buttonModificar, buttonCancelarMod;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_modificar_contacto);

        editTextTextIdMod = findViewById(R.id.editTextTextIdMod);
        editTextTextNombreMod = findViewById(R.id.editTextTextNombreMod);
        editTextTextTelefonoMod = findViewById(R.id.editTextTextTelefonoMod);
        editTextTextEmailMod = findViewById(R.id.editTextTextEmailMod);
        buttonModificar = findViewById(R.id.buttonModificar);
        buttonCancelarMod = findViewById(R.id.buttonCancelarMod);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            int id = extras.getInt("id", 0);
            String nombre = extras.getString("nombre");
            String telefono = extras.getString("telefono");
            String email = extras.getString("email");
            editTextTextIdMod.setText(String.valueOf(id));
            editTextTextNombreMod.setText(nombre);
            editTextTextTelefonoMod.setText(telefono);
            editTextTextEmailMod.setText(email);
        }

        buttonModificar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoModificarContacto();
            }
        });

        buttonCancelarMod.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoBotonCancelar();
            }
        });
    }

    private void EventoModificarContacto() {
        if (editTextTextNombreMod.getText().toString().isEmpty() || editTextTextTelefonoMod.getText().toString().isEmpty() || editTextTextEmailMod.getText().toString().isEmpty()) {
            AlertDialog.Builder error = new AlertDialog.Builder(this);
            error.setTitle("Error al modificar contacto");
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
            Contacto contacto = new Contacto(editTextTextNombreMod.getText().toString(), editTextTextTelefonoMod.getText().toString(), editTextTextEmailMod.getText().toString());
            long id = baseBD.metodoModificacion(contacto, editTextTextIdMod);
            setResult(RESULT_OK);
        }
    }

    private void EventoBotonCancelar() {
        finish();
    }
}