package ejercicio4;

import java.util.ArrayList;
import java.util.List;

public class Aplicacion {

    public static void main(String[] args) {
        int numCaballos = 3; // Número de caballos en la carrera

        List<Caballo> caballos = new ArrayList<>();

        // Crear los caballos y agregarlos a la lista
        for (int i = 1; i <= numCaballos; i++) {
            caballos.add(new Caballo("Caballo " + i));
        }

        // Iniciar la carrera
        System.out.println("¡Comienza la carrera!");

        // Ejecutar los hilos de los caballos
        for (Caballo caballo : caballos) {
            caballo.start();
        }

        // Esperar a que todos los caballos terminen la carrera
        for (Caballo caballo : caballos) {
            try {
                caballo.join();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        // Mostrar los resultados
        System.out.println("\n¡Carrera finalizada!");
        for (Caballo caballo : caballos) {
            System.out.println(caballo.getNombre() + " ha recorrido " + caballo.getDistanciaRecorrida() + " metros.");
        }
    }
}
