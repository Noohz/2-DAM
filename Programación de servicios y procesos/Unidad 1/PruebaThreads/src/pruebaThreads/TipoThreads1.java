package pruebaThreads;

public class TipoThreads1 extends Thread{
	int numIteraciones;
	Contador contador;
	boolean debeIncrementar;
	
	public TipoThreads1(Contador contador, int numIteraciones, boolean debeIncrementar) {
		this.numIteraciones = numIteraciones;
		this.contador = contador;
		this.debeIncrementar = debeIncrementar;
	}
	
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
				contador.incrementar();
			} else {
				contador.decrementar();
			}
			
			
			System.out.println("Soy el thread " +this.getName()+ " y estoy en la iteración " +i);
			
			try {
				Thread.sleep(10);
			} catch (InterruptedException e) {
				
			}
			
		}
	}
	
}
