package com.example.tareaud2;

import android.content.ClipData;
import android.content.ClipboardManager;
import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Handler;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;

import java.util.Random;

public class Actividad2 extends AppCompatActivity {
    LinearLayout LinearLayoutApps;
    TextView textViewBienvenida, textViewAppSeleccionada, textViewCodigo;
    ImageButton imageButtonApp1, imageButtonPortapapeles;
    ImageView imageViewAppSeleccionada;
    CheckBox checkBoxCodigo;

    // Handler para programar generar el código aleatorio.
    private final Handler handler = new Handler();
    private final int intervalo = 5000; // Intervalo de 5 segundos.

    Boolean modoOscuro = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad2);

        LinearLayoutApps = findViewById(R.id.LinearLayoutApps);
        textViewBienvenida = findViewById(R.id.textViewBienvenida);
        imageButtonApp1 = findViewById(R.id.imageButtonApp1);
        textViewAppSeleccionada = findViewById(R.id.textViewAppSeleccionada);
        textViewCodigo = findViewById(R.id.textViewCodigo);
        imageViewAppSeleccionada = findViewById(R.id.imageViewAppSeleccionada);
        checkBoxCodigo = findViewById(R.id.checkBoxCodigo);
        imageButtonPortapapeles = findViewById(R.id.imageButtonPortapapeles);

        Bundle extrasMainActivity = getIntent().getExtras();
        String datosUsuario = extrasMainActivity.getString("usuario");
        textViewBienvenida.setText("Bienvenido " + datosUsuario);

        // Un for para recorrer todo el LinearLayout y obtener cuantos elementos tiene.
        for (int i = 0; i < LinearLayoutApps.getChildCount(); i++) {
            View child = LinearLayoutApps.getChildAt(i);

            if (child instanceof ImageButton) {
                final ImageButton imageButton = (ImageButton) child;

                imageButton.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        handler.removeCallbacksAndMessages(null);
                        handler.postDelayed(generarCodigo, intervalo);

                        InsertarImagenAppSeleccionada(imageButton);
                    }
                });
            }
        }

        imageButtonPortapapeles.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Almacena el código del textViewCodigo
                String textoCodigo = (String) textViewCodigo.getText();

                // Almacenar el código en el portapapeles
                ClipboardManager clipboard = (ClipboardManager) getSystemService(Context.CLIPBOARD_SERVICE); // Esto permite interactuar con el portapapeles.
                ClipData clip = ClipData.newPlainText("Código", textoCodigo); // Esto va a contener el código que queremos copiar
                clipboard.setPrimaryClip(clip); // Aquí se establece el clipData anterior como principal en el portapapeles

                Toast.makeText(Actividad2.this, "Texto copiado al portapapeles", Toast.LENGTH_SHORT).show();
            }
        });

        checkBoxCodigo.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (checkBoxCodigo.isChecked()) {
                    textViewCodigo.setVisibility(View.INVISIBLE);
                    checkBoxCodigo.setText("Mostrar código");
                } else {
                    textViewCodigo.setVisibility(View.VISIBLE);
                    checkBoxCodigo.setText("Ocultar código");
                }
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.datos_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.menuCambiarTheme) {
            // FUNCIONA PERO NECESITA HACER 2 CLICKS PARA VOLVER AL TEMA CLARO.
            /*if (!modoOscuro) {
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
                modoOscuro = true;
            } else {
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
                modoOscuro = false;
            }*/

            int temaActual = getResources().getConfiguration().uiMode & Configuration.UI_MODE_NIGHT_MASK; // Obtiene si el tema actual es oscuro o no.
            if (temaActual == Configuration.UI_MODE_NIGHT_NO) { // Si el tema actual no es oscuro lo aplica.
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
            } else { // Si lo es aplica el tema claro.
                AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
            }
            recreate(); // Recreate permite volver a lanzar la pantalla sin necesidad de tener que reiniciar la app para que se aplique el tema.
            checkBoxCodigo.setChecked(true);
            textViewCodigo.setVisibility(View.INVISIBLE);
        } else if (id == R.id.menuAcercaDe) {
            Intent acercaDe = new Intent(this, PantallaAcerdaDe.class);
            startActivity(acercaDe);
        } else if (id == R.id.menuCerrarSesion) {
            finish();
        }

        return true;
    }

    // Runnable para generar números aleatorios
    private final Runnable generarCodigo = new Runnable() {
        @Override
        public void run() {
            // Generar un número aleatorio de 8 dígitos
            String CodigoAleatorio = generarCodigo();

            // Asignar el código al TextView
            textViewCodigo.setText(CodigoAleatorio);

            // Programar la próxima ejecución después de 15 segundos
            handler.postDelayed(this, intervalo); // Esto también permite que se actualice la pantalla y que se muestre el codigo nuevo.
        }
    };

    // Método para generar el código aleatorio.
    private String generarCodigo() {
        Random random = new Random();
        int numeroAleatorio = 10000000 + random.nextInt(90000000);
        return String.valueOf(numeroAleatorio);
    }

    private void InsertarImagenAppSeleccionada(ImageButton imageButton) {
        // Obtener la imagen del ImageButton clicado
        Drawable imagenApp = imageButton.getDrawable();
        // Obtiene el tag del ImageButton clicado
        String nombreApp = (String) imageButton.getTag();

        // Asignar la imagen al ImageView
        imageViewAppSeleccionada.setImageDrawable(imagenApp);

        // Hacer visible el ImageView, TextViews y demás.
        checkBoxCodigo.setVisibility(View.VISIBLE);
        imageViewAppSeleccionada.setVisibility(View.VISIBLE);
        textViewAppSeleccionada.setText("Tu código para " + nombreApp + " es:");
        textViewAppSeleccionada.setVisibility(View.VISIBLE);
        imageButtonPortapapeles.setVisibility(View.VISIBLE);


        if (checkBoxCodigo.isChecked()) {
            textViewCodigo.setVisibility(View.INVISIBLE);
            checkBoxCodigo.setText("Mostrar código");
        } else {
            textViewCodigo.setVisibility(View.VISIBLE);
            checkBoxCodigo.setText("Ocultar código");
        }
    }
}