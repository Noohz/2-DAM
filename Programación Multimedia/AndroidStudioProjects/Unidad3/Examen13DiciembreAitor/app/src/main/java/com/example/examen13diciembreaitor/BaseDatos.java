package com.example.examen13diciembreaitor;

import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import androidx.annotation.Nullable;

public class BaseDatos extends SQLiteOpenHelper {
    static String createBDSQL = "CREATE TABLE Paises (_id integer primary key autoincrement, " + "Nombre TEXT, Capital TEXT, Continente TEXT, NumHabitantes INTEGER)";
    Context contexto;

    public BaseDatos(@Nullable Context context) {
        super(context, "Paises", null, 1);
        contexto = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        try {
            db.execSQL(createBDSQL);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al crear la BD" + e, Toast.LENGTH_SHORT).show();
        }

    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        try {
            db.execSQL("DROP TABLE IF EXISTS Paises");
            onCreate(db);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al actualizar la BD" + e, Toast.LENGTH_SHORT).show();
        }
    }
}
