package MisClases;

public class ContadorMaximo {
	int maximo;

	public ContadorMaximo() {
		maximo = 0;
	}

	public int getMaximo() {
		return maximo;
	}

	public void setMaximo(int valor) {
		synchronized (this) {
			if (valor > maximo) {
				this.maximo = valor;
			}
		}
	}

}
