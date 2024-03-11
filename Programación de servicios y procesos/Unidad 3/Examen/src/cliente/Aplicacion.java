package cliente;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Aplicacion {

	private static final int PUERTO = 23432;
    private static final String HOST = "localhost";

    public static void main(String[] args) throws IOException {
        Socket cliente = new Socket(HOST, PUERTO);

        Scanner scanner = new Scanner(System.in);

        while (true) {
            // Mostrar mensaje del servidor
            System.out.println(recibirMensaje(cliente));

            // Mostrar opciones
            System.out.println("1 - Adivinar letra");
            System.out.println("2 - Adivinar palabra");
            System.out.println("3 - Salir");

            // Leer opción del usuario
            int opcion = scanner.nextInt();

            // Enviar mensaje al servidor
            switch (opcion) {
            case 1:
                System.out.println("Introduce una letra: ");
                char letra = scanner.next().charAt(0);
                enviarMensaje(cliente, "Letra\t" + letra);
                break;
            case 2:
                System.out.println("Introduce una palabra: ");
                String palabra = scanner.next();
                enviarMensaje(cliente, "Palabra\t" + palabra);
                break;
            case 3:
                enviarMensaje(cliente, "Final");
                break;
        }

            // Salir si el usuario elige salir
            if (opcion == 3) {
                break;
            }
        }

        cliente.close();
    }

    private static String recibirMensaje(Socket cliente) throws IOException {
        DataInputStream in = new DataInputStream(cliente.getInputStream());
        return in.readUTF();
    }

    private static void enviarMensaje(Socket cliente, String mensaje) throws IOException {
        DataOutputStream out = new DataOutputStream(cliente.getOutputStream());
        out.writeUTF(mensaje);
    }
}