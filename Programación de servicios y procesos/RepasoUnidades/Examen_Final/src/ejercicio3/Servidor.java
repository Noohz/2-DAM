package ejercicio3;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {
    private static final int PUERTO = 23432;

    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(PUERTO)) {
            System.out.println("Servidor iniciado. Esperando conexiones...");

            while (true) {
                Socket clienteSocket = serverSocket.accept();
                System.out.println("Nuevo cliente conectado");

                GestorConexion gestor = new GestorConexion(clienteSocket);
                new Thread(gestor).start();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
