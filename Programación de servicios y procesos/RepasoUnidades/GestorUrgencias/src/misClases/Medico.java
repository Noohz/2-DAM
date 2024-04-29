package misClases;

import java.util.concurrent.Semaphore;

public class Medico extends Thread {

	private int id;
	SalaEspera salaEspera;
	Semaphore semaforoPacientes;

	public Medico(int id, SalaEspera salaEspera, Semaphore semaforoPacientes) {
		this.id = id;
		this.salaEspera = salaEspera;
		this.semaforoPacientes = semaforoPacientes;
	}

	@Override
	public void run() {

		while (true) {
			// Hacemos una pausa para fácilitar la visualización.
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) {

				e.printStackTrace();
			}

			// Seleccionamos el paciente que hay que tratar.
			Paciente pacienteTratado = salaEspera.seleccionarPaciente();

			if (pacienteTratado != null) {
				semaforoPacientes.release();

				System.out.println("El médico " + id + " está atendiendo al paciente " + pacienteTratado.getIdPaciente() + " que tiene un nivel de urgencia de " + pacienteTratado.getNivelUrgencia());

				// Hacemos una pausa para simular la atención.
				try {
					Thread.sleep(Aplicacion.numAleatorio.nextInt(1000, 3000));

				} catch (InterruptedException e) {

					e.printStackTrace();
				}

				System.out.println("El médico " + id + " ha atendido al paciente " + pacienteTratado.getIdPaciente());
			}
		}

	}
}
