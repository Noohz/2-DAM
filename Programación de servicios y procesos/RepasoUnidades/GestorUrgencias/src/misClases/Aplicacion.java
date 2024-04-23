package misClases;

import java.util.concurrent.Semaphore;

public class Aplicacion {

	public static void main(String[] args) {
		final int CAPACIDAD_SALA = 15;
		final int NUM_MEDICOS = 2;
		
		// Creamos la sala de espera.
		SalaEspera salaEspera = new SalaEspera(CAPACIDAD_SALA);
		
		// Creamos los médicos y los ponemos a trabajar.
		Medico[] medicos = new Medico[NUM_MEDICOS];
		for (int i = 0; i < NUM_MEDICOS; i++) {
			medicos[i] = new Medico(i, salaEspera);
			medicos[i].start();
		}

		// Nos creamos un semáforo para controlar el acceso a la sala de espera.
		Semaphore semaforo = new Semaphore(CAPACIDAD_SALA);
		
		while (true) {
			// Llega un paciente.
			
			
			try {
				// Esperamos a que pueda entrar a la sala.
				semaforo.acquire();
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
			
			// Creamos un nuevo objeto paciente.
			Paciente nuevoPaciente = new Paciente();
			
			// Le asignamos una posición en la sala de espera.
			salaEspera.aniadirPaciente(nuevoPaciente);
		}
		
	}

}
