package com.example.ejemplobd;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;

public class MainActivity extends AppCompatActivity {

    AccesoDatos baseBD;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Acceso a la base de datos para su creación
        baseBD = new AccesoDatos(this);
        baseBD.ejemploMetodoConsultar();
        baseBD.ejemploMetodoModificacion();
    }
}