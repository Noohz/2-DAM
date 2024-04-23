package misClases;

import java.util.Random;

public class Paciente {
	private int nivelUrgencia;
	private long momentoLlegada;
	
	public Paciente() {
		Random numAleatorio = new Random();
		
		nivelUrgencia = numAleatorio.nextInt(1, 101);
		momentoLlegada = System.currentTimeMillis();
	}

	public int getNivelUrgencia() {
		return nivelUrgencia;
	}

	public void setNivelUrgencia(int nivelUrgencia) {
		this.nivelUrgencia = nivelUrgencia;
	}

	public long getMomentoLlegada() {
		return momentoLlegada;
	}

	public void setMomentoLlegada(long momentoLlegada) {
		this.momentoLlegada = momentoLlegada;
	}
	
	
}
