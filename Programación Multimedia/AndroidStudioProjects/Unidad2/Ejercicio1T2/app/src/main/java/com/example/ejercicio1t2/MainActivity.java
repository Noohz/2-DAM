package com.example.ejercicio1t2;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    EditText usuario, clave;
    CheckBox recordarUsuario;
    Button enviar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        usuario = findViewById(R.id.editTextTextUsuario);
        clave = findViewById(R.id.editTextTextClave);

        recordarUsuario = findViewById(R.id.checkBoxRUser);

        enviar = findViewById(R.id.buttonEnviar);

        recordarUsuario.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() { // Un evento que se ejecuta cuando se interactua con el checkbox Recordar Usuario.
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {

                marcarCB();

            }
        });

        enviar.setOnClickListener(new View.OnClickListener() { // Un evento que se ejecuta cuando se interactua con el button enviar.
            @Override
            public void onClick(View view) {

                btnEnviar();

            }
        });

    }

    private void btnEnviar() {

        if (usuario.getText().toString().isEmpty()) {

            String texto2 = "Datos no introducidos \nNo se han enviado los datos...";
            Toast.makeText(getApplicationContext(), texto2, Toast.LENGTH_LONG).show();

        } else {

            String texto = "Usuario: " +usuario.getText()+ "\nEnviando datos...";
            Toast.makeText(getApplicationContext(), texto, Toast.LENGTH_LONG).show();

        }

        //AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES); - Para que cambie el tema a oscuro cuando se presiona el boton

    }

    private void marcarCB() {

        if (recordarUsuario.isChecked()) {
            String textoMarcado = "Opción 'Recordar Usuario' marcada.";
            Toast.makeText(getApplicationContext(), textoMarcado, Toast.LENGTH_SHORT).show();
        } else {
            String textoDesmarcado = "Opción 'Recordar Usuario' desmarcada'.";
            Toast.makeText(getApplicationContext(), textoDesmarcado, Toast.LENGTH_SHORT).show();
        }

    }
}