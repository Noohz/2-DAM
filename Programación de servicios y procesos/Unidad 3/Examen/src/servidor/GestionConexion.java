package servidor;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Random;

public class GestionConexion extends Thread {

	private Socket cliente;
	private String palabraSeleccionada;
	private char[] estadoPalabra;
	private int numFallos;
	private int numLetrasPendientes;

	public GestionConexion(Socket cliente) {
		this.cliente = cliente;
	}

	@Override
	public void run() {
		try {
			// Inicializar variables
			numFallos = 0;
			palabraSeleccionada = Aplicacion.PALABRAS[new Random().nextInt(Aplicacion.PALABRAS.length)];
			estadoPalabra = new char[palabraSeleccionada.length()];
			for (int i = 0; i < estadoPalabra.length; i++) {
				estadoPalabra[i] = '_';
			}
			numLetrasPendientes = estadoPalabra.length;

			// Enviar trama inicial
			enviarTrama("Inicio", numFallos, estadoPalabra);

			// Bucle del juego
			while (numFallos < 7 && numLetrasPendientes > 0) {
				String tramaRecibida = recibirTrama();
				String[] partesTrama = tramaRecibida.split("\t");

				switch (partesTrama[0]) {
				case "Letra":
					char letra = partesTrama[1].charAt(0);
					boolean acierto = false;
					for (int i = 0; i < palabraSeleccionada.length(); i++) {
						if (palabraSeleccionada.charAt(i) == letra) {
							estadoPalabra[i] = letra;
							acierto = true;
						}
					}
					if (acierto) {
						numLetrasPendientes--;
						enviarTrama("Aciertos", numFallos, estadoPalabra);
					} else {
						numFallos++;
						enviarTrama("Fallos", numFallos, estadoPalabra);
					}
					break;
				case "Palabra":
					String palabra = partesTrama[1];
					if (palabra.equals(palabraSeleccionada)) {
						enviarTrama("Triunfo", numFallos, estadoPalabra);
					} else {
						numFallos++;
						enviarTrama("Fallos", numFallos, estadoPalabra);
					}
					break;
				case "Final":
					cliente.close();
					break;
				}
			}

			// Enviar trama final
			if (numFallos == 7) {
				enviarTrama("Derrota", numFallos, palabraSeleccionada.toCharArray());
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				cliente.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	private void enviarTrama(String tipo, int numFallos, char[] estadoPalabra) throws IOException {
	    StringBuilder trama = new StringBuilder();
	    trama.append(tipo).append("\t").append(numFallos).append("\t");
	    for (char c : estadoPalabra) {
	        trama.append(c);
	    }
	    trama.append("\n");

	    DataOutputStream out = new DataOutputStream(cliente.getOutputStream());
	    out.writeUTF(trama.toString());
	}

	private String recibirTrama() throws IOException {
		DataInputStream in = new DataInputStream(cliente.getInputStream());
		return in.readUTF();
	}
}