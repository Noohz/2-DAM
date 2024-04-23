package misClases;

public class SalaEspera {
	Paciente[] pacientes = new Paciente[15];

	public SalaEspera(int numPacientes) {
		pacientes = new Paciente[numPacientes];
	}

	public void aniadirPaciente(Paciente nuevoPaciente) {

		for (Paciente paciente : pacientes) {
			if (paciente == null) {
				paciente = nuevoPaciente;
				break;
			}
		}

	}

	public Paciente seleccionarPaciente() {
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

		return pacienteSeleccionado;
	}
}
