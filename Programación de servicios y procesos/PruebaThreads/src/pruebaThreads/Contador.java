package pruebaThreads;

public class Contador {

	private int valor;
	
	Contador (int valor){
		this.valor = valor;
	}
	
	void incrementar () {
		valor++;
	}
	
	void decrementar () {
		valor--;
	}

	public void setValor(int valor) {
		this.valor = valor;
	}

	public int getValor() {
		return valor;
	}
	
}
