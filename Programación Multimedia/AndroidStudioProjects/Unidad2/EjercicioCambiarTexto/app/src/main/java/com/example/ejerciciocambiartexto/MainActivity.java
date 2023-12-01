package com.example.ejerciciocambiartexto;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContract;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    TextView textViewTextoModificado;
    Button buttonCambiarTexto;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textViewTextoModificado = findViewById(R.id.textViewTextoModificado);
        buttonCambiarTexto = findViewById(R.id.buttonCambiarTexto);

        buttonCambiarTexto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent1 = new Intent(MainActivity.this, Pantalla2CambiarTexto.class);
                intent1.putExtra("texto", textViewTextoModificado.getText().toString()); // Opcional?
                startActivityForResult(intent1, 1);

            }
        });
    }

    protected void onActivityResult (int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 1) {
            if (resultCode == RESULT_OK) {
                Bundle datos = data.getExtras();

                if (datos != null) {
                    textViewTextoModificado.setText(datos.getString("nuevoTexto"));
                }

            }
        }
    }

}