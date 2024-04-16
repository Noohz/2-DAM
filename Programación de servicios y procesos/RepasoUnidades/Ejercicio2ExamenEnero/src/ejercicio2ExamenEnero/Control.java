package ejercicio2ExamenEnero;

public class Control {
	
	boolean puedoComenzar;
	boolean haTerminado;
	String ganador;
	int numTiradasGanador;

	Control(){
		puedoComenzar=false;
		haTerminado=false;
		ganador=null;
		numTiradasGanador=0;
	}
	
	void setPuedoComenzar(boolean valor) {
		puedoComenzar=valor;
	}
	
	boolean gePuedoComenzar() {
		return puedoComenzar;
	}
	
	 synchronized void notificarGanador(String hilo, int numTiradas) {
		if(haTerminado==false) {
			haTerminado=true;
			ganador=hilo;
			numTiradasGanador=numTiradas;
		}
	 }
	 
	 boolean hayGanador() {
		 return haTerminado;
	 }

}
