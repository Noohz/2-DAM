package ejercicio1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Ejercicio1 {

	public static void main(String[] args) {
		ArrayList<String> cuentasHabilitadas = new ArrayList<String>();		
		
		comandoPowershell(cuentasHabilitadas);
		crearCuentaUsuarios(cuentasHabilitadas);
	}

	private static void crearCuentaUsuarios(ArrayList<String> cuentasHabilitadas) {
		for (String usuario : cuentasHabilitadas) {
			String ruta = "C:\\" + usuario;
			ProcessBuilder pB = new ProcessBuilder("CMD", "/C", "MKDIR", ruta);
			try {
				Process p1 = pB.start();
				int codigo = p1.waitFor();
				
				if (codigo == 0) {
					System.out.println("La carpeta para el usuario " + usuario + " se ha creado correctamente.");
				} else {
					System.err.println("Error, no se ha podido crear la cuenta para el usuario " + usuario);
				}
			} catch (IOException e) {
				e.printStackTrace();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}			
		}		
	}

	private static void comandoPowershell(ArrayList<String> cuentasHabilitadas) {
		ProcessBuilder pB = new ProcessBuilder("powershell", "-Command", "Get-LocalUser");
		try {
			Process p1 = pB.start();
			int codigo = p1.waitFor();

			if (codigo == 0) {
				InputStream inputStream = p1.getInputStream();
				BufferedReader lector = new BufferedReader(new InputStreamReader(inputStream));

				String linea;
				int numLinea = 0;
				while ((linea = lector.readLine()) != null) {
					numLinea++;

					if (numLinea > 3) {
						System.out.println(linea);
						if (linea.length() == 0) {
							break;
						}
						
						if (linea.charAt(19) == 'T') {
							cuentasHabilitadas.add(linea.substring(0, 19).trim());
						}
					}
				}

			} else {
				InputStream errorStream = p1.getErrorStream();
				BufferedReader lectorErrores = new BufferedReader(new InputStreamReader(errorStream));

				String linea;
				while ((linea = lectorErrores.readLine()) != null) {
					System.out.println(linea);
				}
			}

		} catch (IOException e) {
			e.printStackTrace();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}
