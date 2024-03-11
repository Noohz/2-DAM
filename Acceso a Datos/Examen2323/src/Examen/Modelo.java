package Examen;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.ArrayList;

public class Modelo {
	final String NOMBRE_FT = "ventas.txt";

	public ArrayList<Ventas> obtenerVentasTXT() {
		// TODO Auto-generated method stub

		ArrayList<Ventas> resultado = new ArrayList();

		BufferedReader f = null;
		try {
			f = new BufferedReader(new FileReader(NOMBRE_FT));
			String linea;

			while ((linea = f.readLine()) != null) {
				String[] campos = linea.split(";");
				Ventas v = new Ventas(Integer.parseInt(campos[0]), Integer.parseInt(campos[2]),
						Float.parseFloat(campos[3]));
				resultado.add(v);
			}

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			if (f != null) {
				try {
					f.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public Ventas obtenerVentaOBJ(int idProducto) {
		Ventas resultado = null;

		ObjectInputStream f = null;
		try {
			f = new ObjectInputStream(new FileInputStream(NOMBRE_FT));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return resultado;
	}

}