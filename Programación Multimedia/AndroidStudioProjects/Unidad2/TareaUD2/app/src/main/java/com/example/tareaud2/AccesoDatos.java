package com.example.tareaud2;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.widget.EditText;
import android.widget.Toast;

public class AccesoDatos {
    private final Context contexto;
    BaseDatos miBD;

    public AccesoDatos(Context contexto) {
        this.contexto = contexto;
        miBD = new BaseDatos(contexto);
    }

    // Método para crear el usuario.
    public long MetodoCrearUsuario(Usuario u) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        // Hacer consulta Insercción

        ContentValues registro = new ContentValues();
        registro.put("nombre", u.getNombre());
        registro.put("contrasenia", u.getContrasenia());
        registro.put("email", u.getEmail());

        long resultado = accesoEscritura.insert("Usuarios", null, registro);

        if (resultado != -1) {
            Toast.makeText(contexto, "Usuario creado correctamente", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(contexto, "Error al crear el usuario" + resultado, Toast.LENGTH_SHORT).show();
        }
        return resultado;
    }

    // Método para buscar los usuarios de la bd y comprobar si coinciden con lo que se le pasa por el editText.
    public Usuario buscarUsuario(String editTextTextUsuario, String editTextTextContrasenia) {
        SQLiteDatabase accesoLectura = miBD.getReadableDatabase();
        String[] campos = new String[]{"_id", "nombre", "contrasenia", "email"};

        Cursor cursor = accesoLectura.query("Usuarios", campos, null, null, null, null, null);

        Usuario usuario = null;
        if (cursor.moveToFirst()) {
            do {
                String nombre = cursor.getString(1);
                String contrasenia = cursor.getString(2);
                String email = cursor.getString(3);

                if (nombre.equalsIgnoreCase(String.valueOf(editTextTextUsuario)) && contrasenia.equalsIgnoreCase(String.valueOf(editTextTextContrasenia))) {
                    usuario = new Usuario(nombre, contrasenia, email);
                    break;
                }

            } while (cursor.moveToNext());
        }
        return usuario;
    }

    // Método para borrar un usuario.
    public long BorrarUsuario(String datosUsuario, String contraUsuario) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        String[] idUsuarioABorrar = {datosUsuario, contraUsuario};

        long resultado = accesoEscritura.delete("Usuarios", "nombre = ? AND contrasenia = ?", idUsuarioABorrar);

        if (resultado != -1) {
            Toast.makeText(contexto, "Usuario eliminado con éxito", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(contexto, "Error al eliminar el usuario" + resultado, Toast.LENGTH_SHORT).show();
        }
        return resultado;
    }

    // Método para modificar un usuario.
    public long ModificarUsuario(Usuario u, String usr, String pwd, String email) {
        SQLiteDatabase accesoEscritura = miBD.getWritableDatabase();
        String[] idUsuarioAModificar = {usr, pwd, email};

        ContentValues registro = new ContentValues();
        registro.put("nombre", u.getNombre());
        registro.put("contrasenia", u.getContrasenia());
        registro.put("email", u.getEmail());

        int resultado = accesoEscritura.update("Usuarios", registro, "nombre = ? AND contrasenia = ? AND email = ?", idUsuarioAModificar);

        if (resultado != -1) {
            Toast.makeText(contexto, "Contacto modificado correctamente", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(contexto, "Error al modificar el contacto" +resultado, Toast.LENGTH_SHORT).show();
        }

        return resultado;
    }
}
