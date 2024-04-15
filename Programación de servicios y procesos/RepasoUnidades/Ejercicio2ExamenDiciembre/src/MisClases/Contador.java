package MisClases;

public class Contador {
	int contador;

	public Contador() {
		contador = 0;
	}

	public int getContador() {
		return contador;
	}

	public synchronized void incrementarContador() {
		contador++;
	}
}
