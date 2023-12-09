package com.example.tareaud2;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class PantallaModificarUsuario extends AppCompatActivity {

    EditText editTextTextUsuarioMU, editTextTextEmailMU, editTextTextContraseniaMU;
    Button buttonCrearUsuarioMU;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla_modificar_usuario);

        editTextTextUsuarioMU = findViewById(R.id.editTextTextUsuarioMU);
        editTextTextEmailMU = findViewById(R.id.editTextTextEmailMU);
        editTextTextContraseniaMU = findViewById(R.id.editTextTextContraseniaMU);
        buttonCrearUsuarioMU = findViewById(R.id.buttonModificarUsuarioMU);

        Bundle extras = getIntent().getExtras();
        String usr = extras.getString("usuario");
        String pwd = extras.getString("contrasenia");
        String email = extras.getString("email");

        editTextTextUsuarioMU.setText(usr);
        editTextTextEmailMU.setText(email);
        editTextTextContraseniaMU.setText(pwd);

        buttonCrearUsuarioMU.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoModificarUsuario(usr, pwd, email);
            }
        });
    }

    private void EventoModificarUsuario(String usr, String pwd, String email) {
        if (editTextTextUsuarioMU.getText().toString().isEmpty() || editTextTextEmailMU.getText().toString().isEmpty() || editTextTextContraseniaMU.getText().toString().isEmpty()) {
            AlertDialog.Builder error = new AlertDialog.Builder(this);
            error.setTitle("Error al modificar usuario");
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
            Usuario usuario = new Usuario(editTextTextUsuarioMU.getText().toString(), editTextTextContraseniaMU.getText().toString(), editTextTextEmailMU.getText().toString());
            long id = baseBD.ModificarUsuario(usuario, usr, pwd, email);

            if (id != -1) {
                Intent nuevoNombre = new Intent();
                nuevoNombre.putExtra("usuario", editTextTextUsuarioMU.getText().toString());
                nuevoNombre.putExtra("email", editTextTextEmailMU.getText().toString());
                nuevoNombre.putExtra("contrasenia", editTextTextContraseniaMU.getText().toString());
                setResult(RESULT_OK, nuevoNombre);
                editTextTextUsuarioMU.setText("");
                editTextTextEmailMU.setText("");
                editTextTextContraseniaMU.setText("");
                finish();
            }
        }
    }
}