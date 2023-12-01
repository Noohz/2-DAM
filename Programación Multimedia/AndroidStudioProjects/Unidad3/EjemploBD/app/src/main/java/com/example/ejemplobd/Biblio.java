package com.example.ejemplobd;

import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

public class Biblio extends SQLiteOpenHelper {
    Context contexto;

    static String createBDSQL = "CREATE TABLE Ejemplares (_id integer primary key autoincrement, " + "titulo TEXT, autor TEXT, anio TEXT, prestado BOOLEAN)";

    public Biblio(Context context) {
        super(context, "BDBiblioteca", null, 1);
        contexto = context;
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        try {
            sqLiteDatabase.execSQL(createBDSQL);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al crear la base de datos" + e, Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        try {
            sqLiteDatabase.execSQL("DROP TABLE IF EXISTS Ejemplares");
            onCreate(sqLiteDatabase);
        } catch (SQLException e) {
            Toast.makeText(contexto, "Error al actualizar la base de datos" + e, Toast.LENGTH_SHORT).show();
        }
    }
}
