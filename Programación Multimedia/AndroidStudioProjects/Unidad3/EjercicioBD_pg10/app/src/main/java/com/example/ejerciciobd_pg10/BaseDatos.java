package com.example.ejerciciobd_pg10;

import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

public class BaseDatos extends SQLiteOpenHelper {
    Context contexto;

    // Sentencia SQL para crear el contacto.
    static String createBDSQL = "CREATE TABLE Contactos (_id integer primary key autoincrement, " + "nombre VARCHAR, telefono INTEGER, email VARCHAR)";

    public BaseDatos(Context context) {
        super (context, "BDContactos", null, 1);
        contexto = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        try {
            db.execSQL(createBDSQL);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al crear la base de datos" + e, Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        try {
            db.execSQL("DROP TABLE IF EXISTS Contactos");
            onCreate(db);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al actualizar la base de datos" + e, Toast.LENGTH_SHORT).show();
        }
    }
}
