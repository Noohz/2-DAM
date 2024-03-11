package com.example.ejerciciointentimplicitos;

import static android.Manifest.permission.CALL_PHONE;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.app.SearchManager;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    Button buttonAbrirPaginaWeb, buttonBuscarIES, buttonMostrarContactos, buttonMarcarNumero, buttonLlamarPorTlf, buttonIniciarMapa, buttonIniciarCamara, buttonEnviarSMS;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonAbrirPaginaWeb = findViewById(R.id.buttonAbrirPaginaWeb);
        buttonBuscarIES = findViewById(R.id.buttonBuscarIES);
        buttonMostrarContactos = findViewById(R.id.buttonMostrarContactos);
        buttonMarcarNumero = findViewById(R.id.buttonMarcarNumero);
        buttonLlamarPorTlf = findViewById(R.id.buttonLlamarPorTlf);
        buttonIniciarMapa = findViewById(R.id.buttonIniciarMapa);
        buttonIniciarCamara = findViewById(R.id.buttonIniciarCamara);
        buttonEnviarSMS = findViewById(R.id.buttonEnviarSMS);

        buttonAbrirPaginaWeb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                abrirGoogle();
            }
        });

        buttonBuscarIES.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                buscarIES();
            }
        });

        buttonMostrarContactos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mostrarContactos();
            }
        });

        buttonMarcarNumero.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                marcarNumero();
            }
        });

        buttonLlamarPorTlf.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                llamarNumero();
            }
        });

        buttonIniciarCamara.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                abrirCamara();
            }
        });

        buttonEnviarSMS.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                enviarSMS();
            }
        });

        buttonIniciarMapa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                abrirMapa();
            }
        });
    }

    private void abrirMapa() {
        String latitud = "0";
        String longitud = "0";
        String uri = "geo:" +latitud+ "," +longitud+ "?q=71, Antonio Concha, Navalmoral de la Mata";

        Intent abrirGoogleMaps = new Intent(Intent.ACTION_VIEW, Uri.parse(uri));
        startActivity(abrirGoogleMaps);
    }

    private void enviarSMS() {
        Intent enviarSMS = new Intent(Intent.ACTION_SENDTO, Uri.parse("smsto:1234424"));
        enviarSMS.putExtra("sms_body", "Buenos días");
        startActivity(enviarSMS);
    }

    private void abrirCamara() {
        Intent abrirCamara = new Intent ("android.media.action.IMAGE_CAPTURE");
        startActivity(abrirCamara);
    }

    private void llamarNumero() {
        Intent llamarNumero = new Intent(Intent.ACTION_CALL);
        llamarNumero.setData(Uri.parse("tel:123456789"));

        if (ContextCompat.checkSelfPermission(MainActivity.this, CALL_PHONE) == PackageManager.PERMISSION_GRANTED) {
            startActivity(llamarNumero); // Si el if devuelve que tiene permiso inicia la llamda.
        } else {
            requestPermissions(new String[]{CALL_PHONE}, 1); // Si el if devuelve que no tiene permisos muestra al usuario un dialogo para que otorgue o no permisos.
        }
    }

    private void marcarNumero() {
        Intent marcarNumero = new Intent(Intent.ACTION_VIEW, Uri.parse("tel:123456789"));
        startActivity(marcarNumero);
    }

    private void mostrarContactos() {
        Intent mostrarContactos = new Intent(Intent.ACTION_VIEW, Uri.parse("content://contacts/people"));
        startActivity(mostrarContactos);
    }

    private void buscarIES() {
        Intent ies = new Intent(Intent.ACTION_WEB_SEARCH);
        ies.putExtra(SearchManager.QUERY, "IES Augustobriga");
        startActivity(ies);
    }

    private void abrirGoogle() {
        Intent google = new Intent(Intent.ACTION_VIEW, Uri.parse("https://www.google.com/intl/es/gmail/about/"));
        startActivity(google);
    }
}