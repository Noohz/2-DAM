package conecta4;

import java.util.Scanner;
import java.util.Random;

public class Conecta4 {

	static Scanner src = new Scanner(System.in);
	static Random random = new Random();

	static char[][] tablero = new char[6][7]; // Tablero de 6 filas y 7 columnas.

	public static void main(String[] args) {
		int opcion = 0;

		do {
			System.out.println("Selecciona una opción");
			System.out.println("1 - Nueva partida.");
			System.out.println("2 - Salir.");

			opcion = src.nextInt();
			src.nextLine();

			switch (opcion) {
			case 1:
				iniciarPartida();
				break;
			case 2:
				break;
			}
		} while (opcion != 2);
		src.close();
	}

	private static void iniciarPartida() {

		// 2 bucles para recorrer tanto las filas como las columnas.
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 7; j++) {
				tablero[i][j] = '-';
			}
		}

		// Asignar el jugador que empezará la partida.
		char jugadorActual = (random.nextBoolean()) ? 'X' : 'O';
		System.out.println("¡El primer jugador será: " + jugadorActual + "!");

		mostrarTablero();

		while (true) {
			int columna;

			// Pedir al jugador que escoja donde va a poner su ficha.
			do {
				System.out.print("Elige una columna (0-6): ");
				columna = src.nextInt();
			} while (columna < 0 || columna >= 7 || tablero[6 - 1][columna] != '-');

			for (int i = 0; i < 6; i++) {
				if (tablero[i][columna] == '-') {
					tablero[i][columna] = jugadorActual;
					break;
				}
			}

			mostrarTablero();

			if (comprobarGanador(jugadorActual)) {
				System.out.println("¡El jugador " + jugadorActual + " ha ganado!");
				break;
			} else if (tableroCompleto()) {
				System.out.println("¡El tablero está lleno! Esto acaba en empate.");
				break;
			}

			jugadorActual = (jugadorActual == 'X') ? 'O' : 'X';
		}
	}
	
	/**
	 * Método para comprobar si el jugador cumple con algúno de los 4 requerimientos para ganar la partida.
	 * @param jugadorActual -> Variable que almacena quien es el jugador actual (X o Y).
	 * @return true / false -> Dependiendo de si se cumple alguno de los requisitos.
	 */
	private static boolean comprobarGanador(char jugadorActual) {
		// Comprobar si hay 4 fichas en horizontal.
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j <= 7 - 4; j++) {
				if (tablero[i][j] == jugadorActual && tablero[i][j + 1] == jugadorActual
						&& tablero[i][j + 2] == jugadorActual && tablero[i][j + 3] == jugadorActual) {
					return true;
				}
			}
		}

		// Comprobar si hay 4 fichas en vertical.
		for (int i = 0; i <= 6 - 4; i++) {
			for (int j = 0; j < 7; j++) {
				if (tablero[i][j] == jugadorActual && tablero[i + 1][j] == jugadorActual
						&& tablero[i + 2][j] == jugadorActual && tablero[i + 3][j] == jugadorActual) {
					return true;
				}
			}
		}

		// Comprobar si hay 4 fichas en diagonal ascendente.
		for (int i = 3; i < 6; i++) {
			for (int j = 0; j <= 7 - 4; j++) {
				if (tablero[i][j] == jugadorActual && tablero[i - 1][j + 1] == jugadorActual
						&& tablero[i - 2][j + 2] == jugadorActual && tablero[i - 3][j + 3] == jugadorActual) {
					return true;
				}
			}
		}

		// Comprobar si hay 4 fichas en diagonal descendente.
		for (int i = 0; i <= 6 - 4; i++) {
			for (int j = 0; j <= 7 - 4; j++) {
				if (tablero[i][j] == jugadorActual && tablero[i + 1][j + 1] == jugadorActual
						&& tablero[i + 2][j + 2] == jugadorActual && tablero[i + 3][j + 3] == jugadorActual) {
					return true;
				}
			}
		}

		return false;
	}

	/**
	 * Método para comprobar si el tablero está completo.
	 * @return true / false -> Dependiendo del estado del tablero.
	 */
	private static boolean tableroCompleto() {
		for (int i = 0; i < 7; i++) {
			if (tablero[6 - 1][i] == '-') {
				return false;
			}
		}
		return true;
	}

	/**
	 * Método para mostrar el estado del tablero en la consola.
	 */
	private static void mostrarTablero() {
		System.out.println(" 0 1 2 3 4 5 6");
		for (int i = 6 - 1; i >= 0; i--) {
			System.out.print(i + " ");
			for (int j = 0; j < 7; j++) {
				System.out.print(tablero[i][j] + " ");
			}
			System.out.println();
		}
	}
}
