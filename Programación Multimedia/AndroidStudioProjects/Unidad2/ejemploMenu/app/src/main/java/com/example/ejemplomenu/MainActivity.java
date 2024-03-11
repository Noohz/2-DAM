package com.example.ejemplomenu;

// Otra opción del menú que te lleve a otra pantalla


import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.SearchManager;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;
import androidx.appcompat.widget.Toolbar;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    @Override
    // Cargar el menú en la actividad.
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.principal, menu);

        return true;
    }

    @Override
    // Programar la opción de cada menú.
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.menuContacto) {
            String msgContacto = "aramoss27@educarex.es";
            Toast.makeText(MainActivity.this, msgContacto, Toast.LENGTH_LONG).show();
        } else if (id == R.id.menuCerrarApp) {
            finish();
        } else if (id == R.id.menuAcercaDe) {
            String msgAcercaDe = "Ejemplo Menú v1.0";
            Toast.makeText(MainActivity.this, msgAcercaDe, Toast.LENGTH_LONG).show();
        } if (id == R.id.menuBusqueda) {
            Intent intento = new Intent(Intent.ACTION_WEB_SEARCH);
            intento.putExtra(SearchManager.QUERY, "https://www.google.es");
            startActivity(intento);
        }

        return true;
    }
}