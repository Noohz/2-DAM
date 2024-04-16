package ejercicio2ExamenEnero;

import java.util.Random;

public class Hilo extends Thread {
	Control control;
	
	Hilo(Control control) {
		this.control=control;
	}
	
	@Override
	public void run() {
		// Me quedo esperando hasta que se dé la salida
		while(control.gePuedoComenzar()==false) {
				
		}
			
		Random numAleatorio=new Random();
		int contador=0;
		int contadorSeises=0;
		while(contadorSeises<9 && control.hayGanador()==false) {
			// Tiro el dado
			int resultado=numAleatorio.nextInt(1,7);
			contador++;
			if(resultado==6)
				contadorSeises++;
			else contadorSeises=0;
		}
		
		// He terminado. Se lo notifico al controlador del ganador
		control.notificarGanador(getName(), contador);
			
		// Muestro el número de tiradas con las que termina el hilo
		System.out.println(getName() + " - " + contador);
	}

}
