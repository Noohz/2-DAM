package misClases;

public class SalaEspera {
	Paciente[] pacientes = new Paciente[15];

	public SalaEspera(int numPacientes) {
		pacientes = new Paciente[numPacientes];
	}

	public synchronized void aniadirPaciente(Paciente nuevoPaciente) {

		for (Paciente paciente : pacientes) {
			if (paciente == null) {
				paciente = nuevoPaciente;
				break;
			}
		}

	}

	public synchronized Paciente seleccionarPaciente() {
		Paciente pacienteSeleccionado = null;

		for (Paciente paciente : pacientes) {
			if (paciente != null) {
				if (pacienteSeleccionado == null
						|| paciente.getNivelUrgencia() > pacienteSeleccionado.getNivelUrgencia()
						|| (paciente.getNivelUrgencia() == pacienteSeleccionado.getNivelUrgencia()
								&& paciente.getMomentoLlegada() < pacienteSeleccionado.getMomentoLlegada())) {
					pacienteSeleccionado = paciente;
				}
			}
		}
		// Sacamos al paciente de la sala de espera.
		eliminarPaciente(pacienteSeleccionado);
		
		return pacienteSeleccionado;
	}

	public synchronized void eliminarPaciente(Paciente pacienteTratado) {
		for (int i = 0; i < pacientes.length; i++) {
			if (pacientes[i] == pacienteTratado) {
				pacientes[i] = null;
				break;
			}
		}

	}
}
