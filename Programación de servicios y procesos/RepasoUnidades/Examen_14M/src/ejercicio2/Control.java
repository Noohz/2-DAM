package ejercicio2;

import java.util.ArrayList;

public class Control {
	private String ganador;
	private int numRondas;
	private boolean fin;
	private ArrayList<Integer> numerosGenerados = new ArrayList<>();

	public Control() {

	}

	public Control(String ganador, int numRondas) {
		this.ganador = ganador;
		this.numRondas = numRondas;
	}

	synchronized public boolean comprobarNumero(int num) {
		if (numerosGenerados.contains(num)) {
			return false;
		} else {
			numerosGenerados.add(num);
			return true;
		}
	}

	synchronized public void mostrarNumerosGenerados() {
		System.out.println("Números generados: " + numerosGenerados);
	}

	synchronized void notificarGanador(String nombre, int ronda) {
		if (fin == false) {
			fin = true;
			ganador = nombre;
			numRondas = ronda;
		}
	}

	public String getGanador() {
		return ganador;
	}

	public void setGanador(String ganador) {
		this.ganador = ganador;
	}

	public int getNumRondas() {
		return numRondas;
	}

	public void setNumRondas(int numRondas) {
		this.numRondas = numRondas;
	}

}