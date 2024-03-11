package ejercicio5;

public class Principal {

	public static void main(String[] args) {
        Thread[] ventanillas = new Thread[Ventanilla.NUM_VENTANILLAS];
        for (int i = 0; i < Ventanilla.NUM_VENTANILLAS; i++) {
            ventanillas[i] = new Thread(new Ventanilla(i + 1));
            ventanillas[i].start();
        }

        // Esperar a que todas las ventanillas terminen
        try {
            for (Thread ventanilla : ventanillas) {
                ventanilla.join();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Todas las entradas han sido vendidas.");
    }

}
