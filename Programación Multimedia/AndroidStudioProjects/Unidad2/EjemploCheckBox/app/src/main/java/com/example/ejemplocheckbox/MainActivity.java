package com.example.ejemplocheckbox;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    CheckBox c1, c2;
    Button btn1;
    TextView resultado, resultado2;
    RadioGroup rg1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        c1 = findViewById(R.id.checkBoxAndroid);
        c2 = findViewById(R.id.checkBoxiPhone);
        btn1 = findViewById(R.id.buttonSeleccionar);
        resultado = findViewById(R.id.textViewResultado);

        rg1 = findViewById(R.id.rg1);
        resultado2 = findViewById(R.id.textViewRadioGroup);

        CheckBox.OnCheckedChangeListener CBCambioListener = new CheckBox.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    resultado.setText("¡Checkbox " + buttonView.getText() + " marcado!");
                } else {
                    resultado.setText("¡Checkbox " + buttonView.getText() + " desmarcado!");
                }
            }
        };

        // Asignamos el evento a los checkbox.
        c1.setOnCheckedChangeListener(CBCambioListener);
        c2.setOnCheckedChangeListener(CBCambioListener);

        // Creamos el evento del boton seleccionar.
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (c1.isChecked() && c2.isChecked()) {
                    resultado.setText("Has seleccionado Android y iPhone");
                } else {
                    if (c1.isChecked()) {
                        resultado.setText("Has seleccionado Android");
                    } else if (c2.isChecked()) {
                        resultado.setText("Has seleccionado iPhone");
                    } else {
                        resultado.setText("No has seleccionado nada");
                    }
                }
            }
        });

        rg1.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup radioGroup, int i) {
                // Obtenemos el RadioButton que está seleccionado usando el ID marcado.
                RadioButton rb;
                rb = findViewById(i);

                resultado2.setText("RadioButton seleccionado: " +rb.getText());
            }
        });

    }
}