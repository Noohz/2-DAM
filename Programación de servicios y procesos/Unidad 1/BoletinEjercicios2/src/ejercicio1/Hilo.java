package ejercicio1;

public class Hilo extends Thread {

	private static int valorActual = 0;
	private int id;

	public Hilo(int id) {
		this.id = id;
	}

	@Override
	public void run() {
		while (valorActual < 100) {
            synchronized (Hilo.class) {
            	valorActual++;
                System.out.println("Soy el hilo Nº" + id + ": " + valorActual);
            }
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
	}

}
