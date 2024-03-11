package com.example.ejemplocuadrodialogo;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Información");
        builder.setMessage("Prueba de cuadro de diálogo");
        builder.create();
        builder.show();

        AlertDialog.Builder dialogo1 = new AlertDialog.Builder(MainActivity.this);
        dialogo1.setTitle("Mensaje de Confirmación");
        dialogo1.setMessage("¿Está seguro de que desea borrar el producto?");
        dialogo1.setCancelable(false);
        dialogo1.setPositiveButton("Borrar", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                BotonAceptar();
            }
        });

        dialogo1.setNeutralButton("Cancelar", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                BotonCancelar();
            }
        });
        dialogo1.show();
    }

    private void BotonCancelar() {
        finish();
    }

    private void BotonAceptar() {
        Toast.makeText(MainActivity.this, "Producto borrado", Toast.LENGTH_SHORT).show();
    }
}