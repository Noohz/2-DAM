package com.example.tareaud2;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class PantallaCrearUsuario extends AppCompatActivity {

    EditText editTextTextUsuarioCU, editTextTextEmailCU, editTextTextContraseniaCU;
    Button buttonCrearUsuarioCU;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla_crear_usuario);

        editTextTextUsuarioCU = findViewById(R.id.editTextTextUsuarioCU);
        editTextTextEmailCU = findViewById(R.id.editTextTextEmailCU);
        editTextTextContraseniaCU = findViewById(R.id.editTextTextContraseniaCU);
        buttonCrearUsuarioCU = findViewById(R.id.buttonCrearUsuarioCU);

        buttonCrearUsuarioCU.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoCrearUsuario();
            }
        });
    }

    private void EventoCrearUsuario() {
        if (editTextTextUsuarioCU.getText().toString().isEmpty() || editTextTextEmailCU.getText().toString().isEmpty() || editTextTextContraseniaCU.getText().toString().isEmpty()) {
            AlertDialog.Builder not1 = new AlertDialog.Builder(PantallaCrearUsuario.this);
            not1.setTitle("Error");
            not1.setMessage("No puedes dejar vacío ningún campo.");
            not1.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            not1.show();
        } else {
            baseBD = new AccesoDatos(this);
            Usuario usuario = new Usuario(editTextTextUsuarioCU.getText().toString(), editTextTextContraseniaCU.getText().toString() ,editTextTextEmailCU.getText().toString());
            long id = baseBD.MetodoCrearUsuario(usuario);
            finish();
        }
    }
}