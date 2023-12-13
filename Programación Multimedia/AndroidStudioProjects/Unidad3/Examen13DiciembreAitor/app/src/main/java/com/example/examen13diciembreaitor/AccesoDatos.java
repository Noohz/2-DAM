package com.example.examen13diciembreaitor;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.widget.Toast;

public class AccesoDatos {
    private final Context contexto;
    BaseDatos miBD;

    public AccesoDatos(Context contexto) {
        this.contexto = contexto;
        miBD = new BaseDatos(contexto);
    }

    public void InsertarDatosBD(Pais pais) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();

        ContentValues registro = new ContentValues();
        registro.put("Nombre", pais.nombrePais);
        registro.put("Capital", pais.capital);
        registro.put("Continente", pais.continente);
        registro.put("NumHabitantes", pais.numHabitantes);

        long resultado = accesoEscritura.insert("Paises", null, registro);

        if (resultado != -1) {
            Toast.makeText(contexto, "País insertado correctamente.", Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(contexto, "Erorr a la hora de insertar el país." + resultado, Toast.LENGTH_SHORT).show();
        }
    }

    public void buscarPais(String paisABuscar) {
        SQLiteDatabase accesoLectura = miBD.getReadableDatabase();

        String[] campo = new String[]{"Nombre", "Capital", "Continente", "NumHabitantes"};
        String[] args = new String[]{paisABuscar};

        Cursor cursor = accesoLectura.query("Paises", campo, "Nombre = ?", args, null, null, null);

        while (cursor.moveToFirst()) {
            do {
                cursor.getString(0);
                cursor.getString(1);
                cursor.getString(2);
                cursor.getString(3);
            } while (cursor.moveToNext());
        }
    }
}
