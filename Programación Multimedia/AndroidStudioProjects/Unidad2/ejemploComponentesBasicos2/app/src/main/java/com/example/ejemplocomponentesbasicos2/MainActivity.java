package com.example.ejemplocomponentesbasicos2;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    RadioGroup rg1;
    CheckBox cb1, cb2;
    RadioButton php, java, c;
    Button calcular;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        rg1 = findViewById(R.id.radioGroupCurso);
        php = findViewById(R.id.radioButtonPHP);
        java = findViewById(R.id.radioButtonJava);
        c = findViewById(R.id.radioButtonCPlus);

        cb1 = findViewById(R.id.checkBoxFamilia);
        cb2 = findViewById(R.id.checkBoxSocio);

        calcular = findViewById(R.id.buttonCalcular);

        // Botón calcular
        calcular.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                calcular();
            }
        });
    }

    private void calcular() {
        String curso = "";
        float precio = 0;
        float dto1 = 0, dto2 = 0;

        // Calculamos el precio sin descuento.
        if (php.isChecked()) {
            curso = "PHP";
            precio = 120;
        } else if (java.isChecked()) {
            curso = "Java";
            precio = 100;
        } else if (c.isChecked()) {
            curso = "C++";
            precio = 90;
        }

        // Calcular el descuento por família numerosa.
        if (cb1.isChecked()) {
            dto1 = (float) precio * 10/100;
        }

        // Calcular el descuento por socio oro.
        if (cb2.isChecked()) {
            dto2 = (float) precio * 5/100;
        }

        // Precio final
        float total = precio - dto1 - dto2;
        String texto = "Curso: " +curso+ "\nPrecio: " +total;
        String texto2 = "Dto Familia Numerosa: " +dto1+ " €" +"\nDto Socio Oro: " +dto2 + " €";

        // Creamos y mostramos el Toast.
        Toast mensaje;
        Toast.makeText(getApplicationContext(), texto, Toast.LENGTH_LONG).show();
        Toast.makeText(getApplicationContext(), texto2, Toast.LENGTH_SHORT).show();
    }
}