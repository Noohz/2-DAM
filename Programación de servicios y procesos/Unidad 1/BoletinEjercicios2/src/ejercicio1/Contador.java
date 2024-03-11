package ejercicio1;

public class Contador {
	private int valor;

	Contador(int valor) {
		this.valor = valor;
	}

	void incrementar() {
		valor++;
	}

	public void setValor(int valor) {
		this.valor = valor;
	}

	public int getValor() {
		return valor;
	}
}
