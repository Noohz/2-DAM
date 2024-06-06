package ejercicio3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class Cliente {
    private static final String SERVIDOR = "localhost";
    private static final int PUERTO = 23432; 

    public static void main(String[] args) {
        try {
            Socket socket = new Socket(SERVIDOR, PUERTO);
            BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            PrintWriter salida = new PrintWriter(socket.getOutputStream(), true);
            BufferedReader teclado = new BufferedReader(new InputStreamReader(System.in));
            
            boolean difSeleccionada = false;
        	boolean intentosSeleccionados = false;
            
            System.out.println(entrada.readLine());

            while (true) {
                System.out.println("Elige una opción:");
                System.out.println("1 - Nueva partida");
                System.out.println("2 - Establecer nivel de dificultad");
                System.out.println("3 - Establecer número máximo de intentos");
                System.out.println("4 - Salir");
                int opcion = Integer.parseInt(teclado.readLine());
                salida.println(opcion);

                switch (opcion) {
                    case 1:
					if (difSeleccionada == true && intentosSeleccionados == true) {
                    		jugar(entrada, salida, teclado);
                            break;
                    	} else {
                    		System.err.println("Debes de seleccionar tanto la dificultad como el número de intentos.");
                    		break;
                    	}
                    case 2:
                        System.out.println("Selecciona el nivel de dificultad (1 => Fácil, 2 => Medio, 3 => Difícil):");
                        int nivel = Integer.parseInt(teclado.readLine());
                        salida.println(nivel);
                        difSeleccionada = true;
                        break;
                    case 3:
                        System.out.println("Introduce el número máximo de intentos:");
                        int intentos = Integer.parseInt(teclado.readLine());
                        salida.println(intentos);
                        intentosSeleccionados = true;
                        break;
                    case 4:
                        socket.close();
                        return;
                    default:
                        System.out.println("Opción no válida.");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void jugar(BufferedReader entrada, PrintWriter salida, BufferedReader teclado) throws IOException {
        String respuesta;
        do {
            respuesta = entrada.readLine();
            System.out.println(respuesta);
            if (!respuesta.startsWith("¡Derrota!")) {
                int intento = Integer.parseInt(teclado.readLine());
                salida.println(intento);
            }
        } while (!respuesta.startsWith("¡Enhorabuena"));
    }
}
