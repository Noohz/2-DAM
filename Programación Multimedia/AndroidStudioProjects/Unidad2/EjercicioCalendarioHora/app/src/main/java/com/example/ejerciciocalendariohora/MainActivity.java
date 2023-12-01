package com.example.ejerciciocalendariohora;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TimePicker;

import java.util.Calendar;

public class MainActivity extends AppCompatActivity {

    EditText editTextTextCalendario, editTextTextHora;
    ImageButton imageButtonCalendario, imageButtonHora;
    Button buttonACalendario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        editTextTextCalendario = findViewById(R.id.editTextTextCalendario);
        imageButtonCalendario = findViewById(R.id.imageButtonCalendario);
        editTextTextHora = findViewById(R.id.editTextTextHora);
        imageButtonHora = findViewById(R.id.imageButtonHora);
        buttonACalendario = findViewById(R.id.buttonACalendario);

        imageButtonCalendario.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                calendario();
            }
        });

        imageButtonHora.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Hora();
            }
        });

        buttonACalendario.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                calendarioPantallaDos();
            }
        });

    }

    private void calendarioPantallaDos() {

        Intent iT = new Intent(this, PantallaCalendario.class);
        startActivity(iT);

    }

    private void Hora() {

        Calendar cal = Calendar.getInstance();
        int hora = cal.get(Calendar.HOUR_OF_DAY);
        int minutos = cal.get(Calendar.MINUTE);

        TimePickerDialog tPD = new TimePickerDialog(MainActivity.this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker timePicker, int hora, int minutos) {
                editTextTextHora.setText(hora+ ":" +minutos);
            }
        }, hora, minutos, true);
        tPD.show();
    }

    private void calendario() {

        Calendar cal = Calendar.getInstance();
        int anio = cal.get(Calendar.YEAR);
        int mes = cal.get(Calendar.MONTH);
        int diaMes = cal.get(Calendar.DAY_OF_MONTH);

        DatePickerDialog d = new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker datePicker, int anio, int mes, int diaMes) {
                editTextTextCalendario.setText(diaMes+ "/" +(mes +1) + "/" +anio);
            }
        }, anio, mes, diaMes);
        d.show();

    }
}