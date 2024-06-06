package ejercicio2;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Control {
	private int numeroSecreto;
	private List<Integer> numerosAdivinados;
	private int turnoActual;
	private final int totalThreads;

	public Control(int totalThreads) {
		this.totalThreads = totalThreads;
		this.numerosAdivinados = new ArrayList<>();
		this.turnoActual = new Random().nextInt(totalThreads);
	}

	public synchronized boolean adivinarNumero(int numero, int idHilo) {
		if (numerosAdivinados.contains(numero)) {
			return false;
		}
		numerosAdivinados.add(numero);
		System.out.println("El Hilo " + idHilo + " ha elegido el número: " + numero);
		
		if (numero == numeroSecreto) {
			System.out.println("El Hilo " + idHilo + " ha conseguido adivinar el número secreto...");
			return true;
		} else if (numero < numeroSecreto) {
			System.err.println("El número " + numero + " del hilo " + idHilo + " era menor que el secreto...");
		} else if (numero > numeroSecreto) {
			System.err.println("El número " + numero + " del hilo " + idHilo + " era mayor que el secreto...");
		}
		turnoActual = (turnoActual + 1) % totalThreads;
		return false;
	}

	public synchronized int getTurnoActual() {
		return turnoActual;
	}

	public synchronized void setNumeroSecreto(int numeroSecreto) {
		this.numeroSecreto = numeroSecreto;
	}
}
