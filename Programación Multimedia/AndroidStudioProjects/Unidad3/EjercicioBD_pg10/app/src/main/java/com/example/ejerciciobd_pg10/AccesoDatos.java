package com.example.ejerciciobd_pg10;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.widget.EditText;
import android.widget.Toast;

import java.util.ArrayList;

public class AccesoDatos {
    private Context contexto;
    BaseDatos miBD;

    public AccesoDatos(Context contexto) {
        this.contexto = contexto;
        miBD = new BaseDatos(contexto);
    }

    public long ejemploMetodoModificacion(Contacto c) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        // Hacer consulta Insercción / Modificación / Borrado

        ContentValues registro = new ContentValues();
        registro.put("nombre", c.getNombre());
        registro.put("telefono", c.getTelefono());
        registro.put("email", c.getEmail());

        long resultado = accesoEscritura.insert("Contactos", null, registro);

        if (resultado != -1) {
            Toast.makeText(contexto, "Contacto creado correctamente", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(contexto, "Error al crear el contacto" +resultado, Toast.LENGTH_SHORT).show();
        }
        return resultado;
    }
    public ArrayList<Contacto> ejemploMetodoConsultar() {
        SQLiteDatabase accesoLectura = miBD.getReadableDatabase();
        String[] campos = new String[] {"_id", "nombre", "telefono", "email"};

        Cursor cursor = accesoLectura.query("Contactos", campos, null, null, null, null, null);

        ArrayList<Contacto> listaContacto = new ArrayList<>();
        if (cursor.moveToFirst()) {
            do {
                int id = cursor.getInt(0);
                String nombre = cursor.getString(1);
                String telefono = cursor.getString(2);
                String email = cursor.getString(3);

                Contacto contacto = new Contacto(id, nombre, telefono, email);
                listaContacto.add(contacto);
            } while (cursor.moveToNext());
        }
        return listaContacto;
    }

    public long metodoModificacion(Contacto c, EditText editTextTextIdMod) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        String[] idContacto = {editTextTextIdMod.getText().toString()};

        ContentValues registro = new ContentValues();
        registro.put("nombre", c.getNombre());
        registro.put("telefono", c.getTelefono());
        registro.put("email", c.getEmail());

        int resultado = accesoEscritura.update("Contactos", registro, "_id = ?", idContacto);

        if (resultado != -1) {
            Toast.makeText(contexto, "Contacto modificado correctamente", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(contexto, "Error al modificar el contacto" +resultado, Toast.LENGTH_SHORT).show();
        }
        return resultado;
    }

    public long metodoBorrado (String idContactoSeleccionado) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        String[] idContactoABorrar = {idContactoSeleccionado};

        long resultado = accesoEscritura.delete("Contactos", "_id = ?", idContactoABorrar);

        return resultado;
    }

}
