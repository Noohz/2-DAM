package com.example.ejercicio2t2;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ToggleButton;

public class MainActivity extends AppCompatActivity {

    boolean img = false;

    Button buttonCambiarImagen;
    ImageView imageView1;
    CheckBox checkBoxDeshabilitarBoton;
    RadioButton radioButtonMostrarImagen, radioButtonOcultarImagen;
    RadioGroup radioGroupBotones;
    ToggleButton toggleButtonCambiarTema;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonCambiarImagen = findViewById(R.id.buttonCambiarImagen);
        imageView1 = findViewById(R.id.imageView1);
        checkBoxDeshabilitarBoton = findViewById(R.id.checkBoxDeshabiliarBoton);
        radioButtonMostrarImagen = findViewById(R.id.radioButtonMostrarImagen);
        radioButtonOcultarImagen = findViewById(R.id.radioButtonOcultarImagen);
        radioGroupBotones = findViewById(R.id.radioGroupBotones);
        toggleButtonCambiarTema = findViewById(R.id.toggleButtonCambiarTema);

        buttonCambiarImagen.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                cambiarImagen();
            }
        });


        // Esto tiene que estar aquí por que si no el Listener no renococe que el botón está marcado por defecto al no interactuar con él.
        if (checkBoxDeshabilitarBoton.isChecked()) {
            checkBoxDeshabilitarBoton.setText("Botón deshabilitado");
            buttonCambiarImagen.setEnabled(false);
        } else {
            checkBoxDeshabilitarBoton.setText("Botón habilitado");
            buttonCambiarImagen.setEnabled(true);
        }

        checkBoxDeshabilitarBoton.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {

                bloquearBoton();

            }
        });

        radioGroupBotones.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup radioGroup, int i) {

                verImagen(radioGroup, i);

            }
        });


        toggleButtonCambiarTema.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                cambiarTema();

            }
        });

    }

    private void cambiarTema() {

        if (toggleButtonCambiarTema.isChecked()) {
            AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
        } else {
            AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
        }

    }

    private void verImagen(RadioGroup radioGroup, int i) {

        final RadioButton rb = (RadioButton) findViewById(i);

        if (rb.getText().toString().equalsIgnoreCase("Mostrar imagen")) {
            imageView1.setVisibility(View.VISIBLE);
        } else  {
            imageView1.setVisibility(View.INVISIBLE);
        }

    }

    private void bloquearBoton() {

        if (checkBoxDeshabilitarBoton.isChecked()) {
            checkBoxDeshabilitarBoton.setText("Botón deshabilitado");
            buttonCambiarImagen.setEnabled(false);
        } else {
            checkBoxDeshabilitarBoton.setText("Botón habilitado");
            buttonCambiarImagen.setEnabled(true);
        }

    }

    private void cambiarImagen() {

        if (!img) {
            imageView1.setImageResource(R.drawable.homer_wall2);
            img = true;
        } else {
            imageView1.setImageResource(R.drawable.homer_ej2t2);
            img = false;
        }

    }
}