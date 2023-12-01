package com.example.ejemplobd;

import android.content.ContentValues;
import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.widget.Toast;

public class AccesoDatos {
    private Context contexto;
    Biblio miBD;

    public AccesoDatos(Context contexto) {
        this.contexto = contexto;
        miBD = new Biblio(contexto);
    }

    public void ejemploMetodoConsultar(){
        SQLiteDatabase accesoLectura = miBD.getReadableDatabase();
        // Hacer consulta selección.
    }

    public void  ejemploMetodoModificacion() {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        // Hacer consulta Inserccion/Modificación/Borrado

        ContentValues registro = new ContentValues();
        registro.put("titulo", "Los Miserables");
        registro.put("autor", "Aitor");
        registro.put("anio", "2000");
        registro.put("prestado" , true);
        long resultado = accesoEscritura.insert("Ejemplares", null, registro);

        if (resultado != -1) {
            Toast.makeText(contexto, "Se ha creado el registro con id" +resultado, Toast.LENGTH_SHORT).show();
        } else {
            Toast.makeText(contexto, "Error de insercción" +resultado, Toast.LENGTH_SHORT).show();
        }
    }
}
