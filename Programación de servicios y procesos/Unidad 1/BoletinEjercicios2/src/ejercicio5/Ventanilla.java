package ejercicio5;

import java.util.Random;

public class Ventanilla implements Runnable {
    public static final int NUM_VENTANILLAS = 2;
    private final int numeroVentanilla;

    public Ventanilla(int numeroVentanilla) {
        this.numeroVentanilla = numeroVentanilla;
    }

    @Override
    public void run() {
        Random rand = new Random();
        for (int i = 0; i < Teatro.FILAS; i++) {
            for (int j = 0; j < Teatro.BUTACAS_POR_FILA; j++) {
                // Simulamos la venta de una entrada
                if (Teatro.reservarAsiento(i, j, numeroVentanilla)) {
                    try {
                        Thread.sleep(rand.nextInt(500) + 500); // Pausa aleatoria entre 500ms y 1000ms
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
    }
}
