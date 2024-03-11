package ejercicio4;

import java.util.Random;

public class Caballo extends Thread {
    private String nombre;
    private int distanciaRecorrida;

    public Caballo(String nombre) {
        this.nombre = nombre;
    }

    public String getNombre() {
        return nombre;
    }

    public int getDistanciaRecorrida() {
        return distanciaRecorrida;
    }

    @Override
    public void run() {
        Random random = new Random();

        while (distanciaRecorrida < 50) {
            // Simular el avance del caballo
            int avance = random.nextInt(5) + 1; // Avance aleatorio entre 1 y 5 metros
            distanciaRecorrida += avance;

            // Mostrar el avance en la consola
            synchronized (System.out) {
            	System.out.println("******************************************************************");
                for (int i = 0; i < distanciaRecorrida; i++) {
                    System.out.print("-");
                }
                System.out.println(nombre);
            }

            try {
                Thread.sleep(100); // Hacer pausa para simular el avance en tiempo real
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
