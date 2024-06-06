package ejercicio3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Random;

public class GestorConexion implements Runnable {
    private Socket clienteSocket;
    private PrintWriter salida;
    private BufferedReader entrada;
    private int numeroAdivinar;
    private int intentosMaximos;
    private int intentosRealizados;

    public GestorConexion(Socket clienteSocket) {
        this.clienteSocket = clienteSocket;
        try {
            salida = new PrintWriter(clienteSocket.getOutputStream(), true);
            entrada = new BufferedReader(new InputStreamReader(clienteSocket.getInputStream()));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void run() {
        try {
            salida.println("Va a comenzar la nueva partida.");
            iniciarPartida();
            jugar();
            clienteSocket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void iniciarPartida() throws IOException {
        Random rand = new Random();
        int nivel = Integer.parseInt(entrada.readLine());
        switch (nivel) {
            case 1:
                numeroAdivinar = rand.nextInt(500) + 1;
                break;
            case 2:
                numeroAdivinar = rand.nextInt(50000) + 1;
                break;
            case 3:
                numeroAdivinar = rand.nextInt(1000000) + 1;
                break;
            default:
                salida.println("Nivel de dificultad no válido.");
                clienteSocket.close();
                return;
        }
        intentosMaximos = Integer.parseInt(entrada.readLine());
        intentosRealizados = 0;
        salida.println("Partida iniciada. Adivina el número.");
    }

    private void jugar() throws IOException {
        while (intentosRealizados < intentosMaximos) {
            int intento = Integer.parseInt(entrada.readLine());
            intentosRealizados++;

            if (intento == numeroAdivinar) {
                salida.println("¡Enhorabuena. Has adivinado el número en " + intentosRealizados + " intentos!");
                return;
            } else if (intento < numeroAdivinar) {
                salida.println("El número a adivinar es mayor.");
            } else {
                salida.println("El número a adivinar es menor.");
            }
        }
        salida.println("¡Derrota! Has alcanzado el número máximo de intentos...");
    }
}
