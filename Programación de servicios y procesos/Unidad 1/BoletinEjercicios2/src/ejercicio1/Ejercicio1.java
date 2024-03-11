package ejercicio1;

public class Ejercicio1 {

	public static void main(String[] args) {

		Hilo hilo1 = new Hilo(1);
		Hilo hilo2 = new Hilo(2);
		Hilo hilo3 = new Hilo(3);

		hilo1.start();
		hilo2.start();
		hilo3.start();

	}

}
