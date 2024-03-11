package simonDice;

import java.util.Scanner;

public class Juego {

	static int tiempoEspera = 1000;
	static int contadorAciertos = 0;
	static int ronda = 1;
	static String secuenciaColores = "";

	static Scanner srcPartida = new Scanner(System.in);
	static Scanner srcMod = new Scanner(System.in);

	public static void main(String[] args) {
		Scanner src = new Scanner(System.in);
		int opcion = 0;

		do {
			System.out.println("Selecciona una opción");
			System.out.println("1 - Nueva partida.");
			System.out.println("2 - Modificar tiempo de espera.");
			System.out.println("3 - Ver numero de aciertos.");
			System.out.println("4 - Salir.");

			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				eventoNuevaPartida();
				break;
			case 2:
				eventoModificarTheadSleep();
				System.out.println("¡Tiempo de espera actualizado a " + tiempoEspera + "!");
				break;
			case 3:
				eventoMostrarAciertosTotal();
				break;
			}
		} while (opcion != 4);
		src.close();
		srcPartida.close();
		srcMod.close();
	}

	private static void eventoNuevaPartida() {
		// En vez de usar colores se usarán números.
		// PJ: Rojo = 1 | Amarillo = 2 | Azul = 3 | Verde = 4.

		// Bucle que dependiendo de la ronda actual va a generar X cantidad de números aleatorios y que después se irán guardando.
		for (int i = 0; i < ronda; i++) {
			int numColor = (int) (Math.random() * 4) + 1;

			System.out.print(numColor);

			try {
				Thread.sleep(tiempoEspera);
			} catch (InterruptedException e) {
				System.err.println("Error: " + e);
			}
			System.out.print("\b");

			secuenciaColores += numColor;

			System.out.println("Introduce la secuencia de números que crees que ha aparecido.");
			String numAparecido = srcPartida.nextLine().replaceAll("\\s", "");

			if (numAparecido.equals(secuenciaColores)) {
				contadorAciertos += 1;
				ronda += 1;

				System.out.println("¡Enhorabuena! Has acertado.");
				System.out.println("Número de aciertos actual: " + contadorAciertos);
			} else {
				contadorAciertos = 0;
				ronda = 1;
				secuenciaColores = "";
				System.err.println("¡Error! Has fallado.");
			}
		}
	}

	/**
	 * Llamar automáticamente a este método cuando la partida finalice para mostrar los aciertos al usuario.
	 * 
	 * @param contadorAciertos -> Parámetro que almacena el número de aciertos totales que ha realizado el usuario en la partida actual.
	 */
	private static void eventoMostrarAciertosTotal() {
		System.out.println("Número de aciertos totales: " + contadorAciertos);
	}

	/**
	 * Método que le permite al usuario modificar el tiempo que pasará hasta que se oculte la secuencia.
	 * 
	 * @param tiempoEspera -> Parámetro que almacena el tiempo de espera actual del Thread.Sleep.
	 */
	private static void eventoModificarTheadSleep() {
		System.out.println("Tiempo de espera actual: " + tiempoEspera);
		System.out.println("Introduce el nuevo tiempo de espera.");
		int nuevoTiempo = srcMod.nextInt();
		srcMod.nextLine();

		tiempoEspera = nuevoTiempo;
	}

}
