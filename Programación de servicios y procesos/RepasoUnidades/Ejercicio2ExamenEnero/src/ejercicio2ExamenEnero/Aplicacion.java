package ejercicio2ExamenEnero;

public class Aplicacion {

	public static void main(String[] args) {

		final int numHilos=10;
		
		// Creo el array para los hilos
		Hilo[] hilos=new Hilo[numHilos];
		
		Control control = new Control();
		
		// Creamos los hilos y los ponemos en marcha
		for(int i=0;i<numHilos;i++) {
			hilos[i]=new Hilo(control);
			hilos[i].start();
		}

		// Doy la salida oficial
		control.setPuedoComenzar(true); 
		
		// Esperamos a que terminen los hilos
		for(int i=0;i<numHilos;i++) {
			try {
				hilos[i].join();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}	
		
		// Mostramos los datos del ganador
		System.out.println("El ganador es : " +
							control.ganador +
							" con un número de tiradas de "
							+ control.numTiradasGanador);
		
		
	}

}
