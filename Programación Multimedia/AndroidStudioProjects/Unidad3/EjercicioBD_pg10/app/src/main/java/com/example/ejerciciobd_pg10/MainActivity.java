package com.example.ejerciciobd_pg10;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private static final int ACTUALIZAR = 1; // Código para realizar la petición de actualización.
    ListView listViewContactos;
    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listViewContactos = findViewById(R.id.listViewContactos);
        baseBD = new AccesoDatos(this);
        baseBD.ejemploMetodoConsultar();
        ArrayList<Contacto> listaContactos = baseBD.ejemploMetodoConsultar();
        ArrayAdapter<Contacto> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listaContactos);
        listViewContactos.setAdapter(adapter);

        listViewContactos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                EventoModificarContacto(listaContactos, position);
            }
        });

        listViewContactos.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                EventoEliminarContacto(listaContactos, position);
                return true;
            }
        });
    }

    // Método para eliminar un contacto del listView.
    private void EventoEliminarContacto(ArrayList<Contacto> listaContactos, int position) {
        Contacto contactoSeleccionado = listaContactos.get(position);
        String idContactoSeleccionado = String.valueOf(contactoSeleccionado.getId());

        AlertDialog.Builder borrar = new AlertDialog.Builder(this);
        borrar.setTitle("Eliminar contacto");
        borrar.setMessage("¿Deseas eliminar el contacto?");
        borrar.setCancelable(false);
        borrar.setPositiveButton("Sí", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                baseBD.metodoBorrado(idContactoSeleccionado);
                recreate();
            }
        });
        borrar.setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
            }
        });
        borrar.show();
    }

    // Evento para modificar un contacto del listView.
    private void EventoModificarContacto(ArrayList<Contacto> listaContactos, int position) {
        Contacto contactoSeleccionado = listaContactos.get(position);
        Intent modContacto = new Intent(this, ModificarContacto.class);
        modContacto.putExtra("id", contactoSeleccionado.getId());
        modContacto.putExtra("nombre", contactoSeleccionado.getNombre());
        modContacto.putExtra("telefono", contactoSeleccionado.getTelefono());
        modContacto.putExtra("email", contactoSeleccionado.getEmail());
        startActivityForResult(modContacto, ACTUALIZAR);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();
        if (id == R.id.menuAdd) {
            Intent contacto = new Intent(this, NuevoContacto.class);
            startActivityForResult(contacto, ACTUALIZAR);
        }
        return true;
    }

    // Método para actualizar la lista después de crear un contacto.
    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == ACTUALIZAR && resultCode == RESULT_OK) { // Comprueba si el codigo solicitado coincide con el que hemos introducido y además también se comprueba si la otra actividad ha devuelto OK
            ArrayList<Contacto> listaContactos = baseBD.ejemploMetodoConsultar();
            ArrayAdapter<Contacto> actualizar = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, listaContactos);
            listViewContactos.setAdapter(actualizar);
            actualizar.notifyDataSetChanged();
            recreate();
        }
    }
}