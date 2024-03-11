package ejercicio2;

import java.util.Random;

public class Hilo implements Runnable{
	
	int numIteracciones;
	Contador contador;
	boolean incrementar;
	boolean empezar;

	public Hilo(int numIteracciones, Contador contador, boolean incrementar, boolean empezar) {
        this.numIteracciones = numIteracciones;
        this.contador = contador;
        this.incrementar = incrementar;
        this.empezar = empezar;
    }

	public void run() {
		while (!empezar) {
            // Esperar a que el hilo principal dé la orden de salida
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        int numTiradas = 0;
        int numSeisesConsecutivos = 0;

        Random random = new Random();

        while (numSeisesConsecutivos < 9 && numTiradas < numIteracciones) {
            if (incrementar) {
                contador.incrementar();
            } else {
                contador.decrementar();
            }

            numTiradas++;

            int resultado = random.nextInt(6) + 1;
            if (resultado == 6) {
                numSeisesConsecutivos++;
            } else {
                numSeisesConsecutivos = 0;
            }

            System.out.println(Thread.currentThread().getName() + ": Tirada " + numTiradas + ", Seises consecutivos: " + numSeisesConsecutivos);
        }

        System.out.println("Hilo terminado: " + Thread.currentThread().getName() + ", Tiradas: " + numTiradas);
    }
}
