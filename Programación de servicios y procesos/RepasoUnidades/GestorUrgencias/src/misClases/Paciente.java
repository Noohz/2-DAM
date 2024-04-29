package misClases;

import java.util.Random;

public class Paciente {
	private int nivelUrgencia;
	private long momentoLlegada;
	private int idPaciente;

	public Paciente(int idPaciente) {
		Random numAleatorio = new Random();

		this.idPaciente = idPaciente;

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

	public int getIdPaciente() {
		return idPaciente;
	}

	public void setIdPaciente(int idPaciente) {
		this.idPaciente = idPaciente;
	}

	public void setMomentoLlegada(long momentoLlegada) {
		this.momentoLlegada = momentoLlegada;
	}

}
