package ejercicio1;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Scanner;

public class Aplicacion {

	static Scanner teclado = new Scanner(System.in);
	static int cont = 0;
	
	public static void main(String[] args) {
		boolean salir = false;

		while (salir == false) {
			System.out.println("1 - Mostrar estado de los servicios del sistema.");
			System.out.println("2 - Salir.");

			int opcion = teclado.nextInt();
			teclado.nextLine();

			switch (opcion) {
			case 1:
				obtenerEstadoServicios();
				break;
			case 2:
				salir = true;
				break;
			default:
				System.err.println("Opción no válida.");
			}
		}
		teclado.close();
	}

	private static void obtenerEstadoServicios() {
        try {
            ProcessBuilder pB = new ProcessBuilder("powershell.exe", "-Command", "Get-Service | Select-Object -Property Name,Status");
            Process p1 = pB.start();

            InputStream pStream = p1.getInputStream();
            Scanner scanner = new Scanner(new InputStreamReader(pStream));

            int contL = 0;
            while (scanner.hasNextLine()) {
                String linea = scanner.nextLine();
                if (contL >= 3) {
                	if (linea.length() == 0) {
						break;
					}
                } else {
                	contL++;
                }
                System.out.println(linea);
                crearArchivoSegunEstado(linea);
            }
            scanner.close();
            System.err.println("Los ficheros con los servicios se han creado en el propio proyecto.");

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void crearArchivoSegunEstado(String linea) {    	
    	if (cont >= 3) {
    		String[] partes = linea.trim().split("\\s+");
            String nombreServicio = partes[0];
            String estado = partes[1];

            if (estado.equalsIgnoreCase("stopped") || estado.equalsIgnoreCase("running") || estado.equalsIgnoreCase("paused")) {
            	try (BufferedWriter writer = new BufferedWriter(new FileWriter(estado + ".txt", true))) {
                    writer.write(nombreServicio);
                    writer.newLine();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }          
    	} else {
    		cont++;
    	}
    }
}
