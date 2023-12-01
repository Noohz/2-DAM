package com.example.ejerciciocalendariohora;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.CalendarView;
import android.widget.Toast;

import java.util.Calendar;

public class PantallaCalendario extends AppCompatActivity {

    CalendarView calendarView1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pantalla_calendario);


        calendarView1 = findViewById(R.id.calendarView1);

        calendarView1.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView calendarView, int anio, int mes, int diaMes) {
                String fecha = diaMes+ "/" +(mes +1) + "/" +anio;
                Toast.makeText(PantallaCalendario.this, fecha, Toast.LENGTH_LONG).show();
            }
        });

    }
}