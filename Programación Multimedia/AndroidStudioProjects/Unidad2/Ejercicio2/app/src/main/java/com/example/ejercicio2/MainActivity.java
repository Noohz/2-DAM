package com.example.ejercicio2;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.ToggleButton;

public class MainActivity extends AppCompatActivity {

    ToggleButton tB1;
    ImageView img1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tB1 = findViewById(R.id.btnToggle);
        img1 = findViewById(R.id.imgView1);

        tB1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (tB1.isChecked()){
                    img1.setVisibility(View.VISIBLE);
                } else {
                    img1.setVisibility(View.INVISIBLE);
                }
            }
        });

    }
}