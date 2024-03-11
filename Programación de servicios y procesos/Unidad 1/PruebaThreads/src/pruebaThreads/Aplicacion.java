package pruebaThreads;

public class Aplicacion {

	public static void main(String[] args) {
		
		TipoThreads1 th1 = new TipoThreads1(25);
		th1.setName("Thread1");
		
		TipoThreads2 tAux = new TipoThreads2("Threads2", 25);
		Thread th2 = new Thread(tAux);
		
		th1.start();
		th2.start();
		
	}

}
