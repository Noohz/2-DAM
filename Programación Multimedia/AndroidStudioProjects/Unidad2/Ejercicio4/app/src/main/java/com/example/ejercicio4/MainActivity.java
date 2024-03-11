package com.example.ejercicio4;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    Button btnSuma, btnResta, btnMultiplicacion, btnDivision;
    TextView tVResultado;
    EditText eT1, eT2;
    int num1, num2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnSuma = findViewById(R.id.btnSuma);
        btnResta = findViewById(R.id.btnResta);
        btnMultiplicacion = findViewById(R.id.btnMultiplicacion);
        btnDivision = findViewById(R.id.btnDivision);
        tVResultado = findViewById(R.id.tVResultado);
        eT1 = findViewById(R.id.eT1);
        eT2 = findViewById(R.id.eT2);


        btnSuma.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                suma(view);
            }
        });

    }

    private void suma(View control) {

        num1 = Integer.parseInt((eT1.getText().toString()));
        num2 = Integer.parseInt((eT2.getText().toString()));

        int suma = num1 + num2;

        tVResultado.setText("La suma de " +eT1.getText()+ " y " +eT2.getText()+ " es: " +String.valueOf(suma));
    }
}