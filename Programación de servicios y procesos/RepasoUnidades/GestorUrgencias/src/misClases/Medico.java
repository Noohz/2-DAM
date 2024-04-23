package misClases;

public class Medico extends Thread {

	private int id;
	SalaEspera salaEspera;

	public Medico(int id, SalaEspera salaEspera) {
		this.id = id;
		this.salaEspera = salaEspera;
	}

	@Override
	public void run() {
		
		while (true) {
			// Seleccionamos el paciente que hay que tratar.
			Paciente pacienteTratar = salaEspera.seleccionarPaciente();
		}
		
	}	
}
