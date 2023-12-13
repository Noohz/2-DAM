package com.example.examen13diciembreaitor;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflate = getMenuInflater();
        inflate.inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.menuInsertarDatos) {
            Intent pantallaInsD = new Intent(MainActivity.this, PantallaInsertarDatos.class);
            startActivity(pantallaInsD);
        }

        if (id == R.id.menuBuscar) {
            Intent pantallaBuscarP = new Intent(MainActivity.this, PantallaBuscarPais.class);
            startActivity(pantallaBuscarP);
        }

        if (id == R.id.menuCerrarApp) {
            AlertDialog.Builder cerrarApp = new AlertDialog.Builder(this);
            cerrarApp.setTitle("Cerrar Aplicación");
            cerrarApp.setMessage("¿Deseas cerrar la aplicación?");
            cerrarApp.setCancelable(false);
            cerrarApp.setPositiveButton("Sí", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    finish();
                }
            });
            cerrarApp.setNegativeButton("No", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            cerrarApp.show();
        }
        return true;
    }
}