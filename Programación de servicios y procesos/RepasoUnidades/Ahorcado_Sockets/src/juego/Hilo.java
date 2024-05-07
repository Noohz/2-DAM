package juego;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Arrays;
import java.util.Random;

public class Hilo extends Thread {
	Random numAleatorio = new Random();

	private static final String[] palabras = { "carroza", "puerta", "musculo", "tibia", "nariz", "pierna" };
	private static final int NUM_FALLOS = 6;
	
	private Socket socketCliente;
	private String palabraElegida;
	private char[] estadoPalabra;
	private int numFallos;
	private int letrasPendientes;

	public Hilo(Socket socketCliente) {
		this.socketCliente = socketCliente;
	}

	@Override
	public void run() {
		BufferedReader in = null;
		PrintWriter out = null;

		try {
			in = new BufferedReader(new InputStreamReader(socketCliente.getInputStream()));
			out = new PrintWriter(socketCliente.getOutputStream(), true);

			// Inicializo los atributos con los que voy a jugar
			inicializar();

			// Mando al cliente la trama inicial
			out.println("Inicio \t" + numFallos + "\t" + new String(estadoPalabra) + "\n");

			// Espero el mensaje de respuesta del cliente.
			String mensaje;
			while ((mensaje = in.readLine()) != null) {
				String[] trama = mensaje.split("\t");
				String opcionTrama = trama[0];

				switch (opcionTrama) {
				case "Letra":
					comprobarLetra(trama[1]);
					break;
				case "Palabra":
					break;
				case "Final":
					out.println("Terminando la partida...");
					break;
				default:
					out.println("Has introducido una opción incorrecta...");
					break;
				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (in != null)
				try {
					in.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			if (out != null)
				out.close();
			if (socketCliente != null) {
				try {
					socketCliente.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}

	private void comprobarLetra(String letraCliente) {
		boolean acierto = false;
		
		char letra = letraCliente.charAt(0); // Almaceno en la variable la letra que ha enviado el cliente.
		// Uso un for para recorrer la palabra elegida y compruebo si la letra que ha enviado el cliente está en ella.
		for (int i = 0; i < palabraElegida.length(); i++) {
			if (palabraElegida.charAt(i) == letra && estadoPalabra[i] == '-') {
				acierto = true;
				estadoPalabra[i] = letra;
				letrasPendientes--;
			}
		}
		
		// Si el jugador ha acertado la letra:
		if (acierto) {
			if (letrasPendientes == 0) {
				try {
					System.out.println("Triunfo \t" + numFallos + "\t" + palabraElegida + "\n"); // Envio la trama de que el jugador a completado la palabra correctamente.
					socketCliente.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			} else {
				System.out.println("Aciertos \t" + (palabraElegida.length() - letrasPendientes) + "\t" + numFallos + "\t" + new String(estadoPalabra) + "\n");
			}
		// Si el jugador no ha acertado la letra:
		} else {
			numFallos++;
			if (numFallos >= NUM_FALLOS) {
			// PENDIENTE.	
			}
		}
		
	}

	private void inicializar() {
		palabraElegida = palabras[numAleatorio.nextInt(palabras.length)]; // Elige una palabra aleatoria entre 1 y la longitud del array.
		estadoPalabra = new char[palabraElegida.length()]; // Inicializo el array de char con la longitud de la palabra elegida.

		for (int i = 0; i < estadoPalabra.length; i++) {
			estadoPalabra[i] = '-';
		}

		numFallos = 0; // Inicializo el número de fallos a 0.
		letrasPendientes = palabraElegida.length(); // Inicializo la cantidad de letras pendientes a la longitud de la palabra elegida.
	}
}
