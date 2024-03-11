package examen;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Modelo {

	private String nombreFichero;
	Boolean logeado = false;

	public Modelo(String nombreFichero) {
		this.nombreFichero = nombreFichero;
	}
	
	public Empleados obtenerEmpleados(String codEmpleadoBuscado, String dniBuscado) {
		Empleados resultado = null;

		BufferedReader f = null;

		try {
			f = new BufferedReader(new FileReader(nombreFichero));

			String linea;
			while ((linea = f.readLine()) != null) {
				String[] arrayL = linea.split(";");
				if (codEmpleadoBuscado.equalsIgnoreCase(arrayL[0]) && dniBuscado.equalsIgnoreCase(arrayL[1])) {
					resultado = new Empleados(arrayL[0], arrayL[1], arrayL[2], arrayL[3],
							Boolean.parseBoolean(arrayL[4]));
					logeado = true;
					return resultado;
				}
			}
		} catch (FileNotFoundException e) {
			System.err.println("El fichero no existe.");
		} catch (IOException e) {
			System.err.println("Error: " + e.getMessage());
		} finally {
			try {
				if (f != null) {
					f.close();
				}
			} catch (IOException e) {
				e.printStackTrace();
			}
		}

		return resultado;
	}
}
