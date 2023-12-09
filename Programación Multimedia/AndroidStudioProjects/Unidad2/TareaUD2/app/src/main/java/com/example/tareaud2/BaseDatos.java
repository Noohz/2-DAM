package com.example.tareaud2;

import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import androidx.annotation.Nullable;

public class BaseDatos extends SQLiteOpenHelper {
    //Sentencia SQL
    static String createBDSQL = "CREATE TABLE Usuarios (_id integer primary key autoincrement, " + "nombre VARCHAR, contrasenia INTEGER, email VARCHAR)";
    Context contexto;

    public BaseDatos(@Nullable Context context) {
        super(context, "BDUsuarios", null, 1);
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
