package misClases;

public class Hilo2 implements Runnable {

	int contador = 0;
	String name;

	public Hilo2(String name) {
		this.name = name;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Override
	public void run() {

		for (contador = 0; contador < 1000; contador++) {
			System.out.println(getName() + contador); // La interfaz Runnable no tiene el método getName() así
														// tendríamos que crearlo nosotros.
		}
	}

}
