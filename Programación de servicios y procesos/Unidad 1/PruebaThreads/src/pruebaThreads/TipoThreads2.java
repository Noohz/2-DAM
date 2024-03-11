package pruebaThreads;

public class TipoThreads2 implements Runnable{

	int numIteraciones;
	Contador contador;
	boolean debeIncrementar;
	
	public TipoThreads2(Contador contador, int numIteraciones, boolean debeIncrementar) {
		this.numIteraciones = numIteraciones;
		this.contador = contador;
		this.debeIncrementar = debeIncrementar;
	}
	
	@Override
	public void run() {
		for (int i = 0; i < numIteraciones; i++) {
			
			int numAux = contador.getValor();
			// Hacemos una pausa de x milisegundos.
			
			try {
				Thread.sleep(10);
			} catch (InterruptedException e) {
				// TODO: handle exception
			}
			
			if (debeIncrementar == true) {
				contador.setValor(numAux + 1);
			} else {
				
			}
			
			
			System.out.println("Soy el thread " +Thread.currentThread()+ " y estoy en la iteración " +i);
			
			try {
				Thread.sleep(10);
			} catch (InterruptedException e) {
				
			}
			
		}
	}

}
