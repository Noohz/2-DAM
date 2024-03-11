package servidor;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Random;

public class GestionConexion extends Thread {

	private Socket cliente;
	BufferedReader entrada;
	PrintWriter salida;

	public GestionConexion(Socket cliente) {
		this.cliente = cliente;

		try {
			entrada = new BufferedReader(new InputStreamReader(cliente.getInputStream()));
			salida = new PrintWriter(cliente.getOutputStream(), true);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Override
	public void run() {
		try {
			String mensaje;
			while ((mensaje = entrada.readLine()) != null) {

				if (mensaje.startsWith("Lineas")) {
					String[] partes = mensaje.split("/");
					int numLineaInicial = Integer.parseInt(partes[1]);
					int numLineas = Integer.parseInt(partes[2]);
					enviarLineas(numLineaInicial, numLineas);

				} else if (mensaje.startsWith("NumVecesPalabra")) {
					
				} else {
					int numeroLinea = Integer.parseInt(mensaje);
					String respuesta = obtenerLinea(numeroLinea);

					if (respuesta != null) {
						salida.println("Resultado\t" + numeroLinea + "\t" + respuesta);
					} else {
						salida.println("Error\t" + numeroLinea);
					}
				}
			}
			cliente.close();
		} catch (IOException e) {
			System.err.println("La conexión con el cliente ha terminado: " + e);
		}
	}

	public String obtenerLinea(int numeroLinea) {
		if (numeroLinea == -1) {
			Random numAleatorio = new Random();
			return Aplicacion.arrayAlicia.get(numAleatorio.nextInt(Aplicacion.arrayAlicia.size()));
		} else if (numeroLinea >= 0 && numeroLinea < Aplicacion.arrayAlicia.size()) {
			return Aplicacion.arrayAlicia.get(numeroLinea);
		} else {
			return null;
		}
	}

	public void enviarLineas(int lineaInicial, int lineaFinal) {
		if (lineaInicial < 0 || lineaInicial >= Aplicacion.arrayAlicia.size()
				|| lineaInicial + lineaFinal > Aplicacion.arrayAlicia.size()) {
			salida.println("Error\t" + lineaInicial);
			return;
		}

		for (int i = lineaInicial; i < lineaInicial + lineaFinal; i++) {
			String linea = Aplicacion.arrayAlicia.get(i);
			salida.println("Resultado\t" + i + "\t" + linea);
		}
		salida.println("FinalEnvio");
	}

	public void contarPalabras(String palabraABuscar) {

	}

}
