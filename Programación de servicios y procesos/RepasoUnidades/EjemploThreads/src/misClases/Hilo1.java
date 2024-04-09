package misClases;

public class Hilo1 extends Thread {

	Compartida valorReferencia;

	public Hilo1(Compartida valorReferencia) {
		this.valorReferencia = valorReferencia;
	}

	@Override
	public void run() {

		for (int i = 0; i < 100000; i++) {
			
			synchronized (valorReferencia) {
				valorReferencia.setValor(valorReferencia.getValor()+1);
			}
			
			System.out.println(getName() + "-" + valorReferencia.getValor());
		}
	}

}
