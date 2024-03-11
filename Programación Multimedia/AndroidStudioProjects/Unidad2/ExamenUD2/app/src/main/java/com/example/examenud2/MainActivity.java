package com.example.examenud2;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.SearchManager;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    Spinner spinnerLugares;
    Button buttonVerLocalizacion;
    EditText editTextTextPrecioEntrada, editTextTextCorreo, editTextTextNumeroEntradasReservar;
    RadioGroup radioGroupTurno;
    CheckBox checkBoxCorreoConfirmacion;

    String turno = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        spinnerLugares = findViewById(R.id.spinnerLugares);
        buttonVerLocalizacion = findViewById(R.id.buttonVerLocalizacion);
        editTextTextPrecioEntrada = findViewById(R.id.editTextTextPrecioEntrada);
        radioGroupTurno = findViewById(R.id.radioGroupTurno);
        checkBoxCorreoConfirmacion = findViewById(R.id.checkBoxCorreoConfirmacion);
        editTextTextCorreo = findViewById(R.id.editTextTextCorreo);
        editTextTextNumeroEntradasReservar = findViewById(R.id.editTextTextNumeroEntradasReservar);


        // Creación del adaptador del spinner y su asignación.
        ArrayAdapter adaptadorLugares = ArrayAdapter.createFromResource(MainActivity.this, R.array.arrayLugares, android.R.layout.simple_list_item_1);
        spinnerLugares.setAdapter(adaptadorLugares);

        // Array con los precios para el editText editTextTextPrecioEntrada.
        ArrayList<Integer> arrayPrecios = new ArrayList<>();
        arrayPrecios.add(20);
        arrayPrecios.add(3);

        // Evento que salta cuando se selecciona una opción de la lista del spinner y cambia el precio del editTextTextPrecioEntrada.
        spinnerLugares.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                if (parent.getItemAtPosition(position).equals("Teatro del Mercado")) {
                    editTextTextPrecioEntrada.setText(arrayPrecios.get(0).toString());
                } else if (parent.getItemAtPosition(position).equals("Piscina Climatizada")) {
                    editTextTextPrecioEntrada.setText(arrayPrecios.get(1).toString());
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        buttonVerLocalizacion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EventoVerLocalizacion();
            }
        });

        // Evento que salta cuando se selecciona uno de los Radio Button y que muestra un toast con el turno elegido.
        radioGroupTurno.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                RadioButton rb = findViewById(checkedId);
                Toast.makeText(MainActivity.this, "Has seleccionado el turno de "+rb.getText(), Toast.LENGTH_SHORT).show();
                turno = (String) rb.getText();
            }
        });

        // Evento que salta cuando se selecciona la casilla y decide si permite o no escribir en el editText.
        checkBoxCorreoConfirmacion.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                EventoRecibirCorreo();
            }
        });

    }

    // Configuración del Menú
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();
        String localizacion = spinnerLugares.getSelectedItem().toString();


        if (id == R.id.menuReservar) {
            Intent int1 = new Intent(this, actividadReserva.class);
            int1.putExtra("lugar", localizacion);
            int1.putExtra("precio", editTextTextPrecioEntrada.getText().toString());
            int1.putExtra("numEntradas", editTextTextNumeroEntradasReservar.getText().toString());
            int1.putExtra("turno", turno);
            startActivity(int1);
        } else if (id == R.id.menuCancelar) {
            
        }
        return super.onOptionsItemSelected(item);
    }

    private void EventoRecibirCorreo() {
        if (checkBoxCorreoConfirmacion.isChecked()) {
            editTextTextCorreo.setEnabled(true);
        } else {
            editTextTextCorreo.setEnabled(false);
        }
    }

    private void EventoVerLocalizacion() {
        String localizacion = spinnerLugares.getSelectedItem().toString();
        Intent intentLocalizacion = new Intent(Intent.ACTION_WEB_SEARCH);
        intentLocalizacion.putExtra(SearchManager.QUERY, "Navalmoral De La Mata " + localizacion);
        startActivity(intentLocalizacion);
    }
}