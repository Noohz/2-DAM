package com.example.ejercicio2cambiartexto;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    Button buttonCambiarTexto;
    TextView textViewContactosTotal;

    ActivityResultLauncher<Intent> someActivityResultLauncher;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonCambiarTexto = findViewById(R.id.buttonCambiarTexto);
        textViewContactosTotal = findViewById(R.id.textViewContactosTotal);

        someActivityResultLauncher = registerForActivityResult(new ActivityResultContracts.StartActivityForResult(), new ActivityResultCallback<ActivityResult>() {
            @Override
            public void onActivityResult(ActivityResult o) {
                if (o.getResultCode() == Activity.RESULT_OK) {

                    Intent data = o.getData();
                    String nombre = data.getExtras().getString("nombre");
                    String apellidos = data.getExtras().getString("apellidos");

                    String contactos = textViewContactosTotal.getText().toString();
                    String contactoTotales = contactos + nombre + " " + apellidos + "\n";

                    textViewContactosTotal.setText(contactoTotales);
                }

            }
        });

        buttonCambiarTexto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                altaContacto();
            }
        });

    }

    private void altaContacto() {

        Intent pantalla1 = new Intent(MainActivity.this, ejercicio2Actividad2CambarTexto.class);
        someActivityResultLauncher.launch(pantalla1);
    }
}