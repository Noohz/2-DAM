package ejercicio3;

public class Aplicacion {

	public static void main(String[] args) {
		CintaTransportadora cinta = new CintaTransportadora(10);
		Productor productor = new Productor(cinta);
		Consumidor consumidor = new Consumidor(cinta);

		productor.start();
		consumidor.start();
	}

}
