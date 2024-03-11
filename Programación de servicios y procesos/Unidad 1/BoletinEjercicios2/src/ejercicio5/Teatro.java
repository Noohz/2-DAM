package ejercicio5;

public class Teatro {
    public static final int FILAS = 25;
    public static final int BUTACAS_POR_FILA = 20;
    private static boolean[][] butacasDisponibles = new boolean[FILAS][BUTACAS_POR_FILA];

    public static synchronized boolean reservarAsiento(int fila, int butaca, int ventanilla) {
        if (!butacasDisponibles[fila][butaca]) {
            butacasDisponibles[fila][butaca] = true;
            System.out.println("Reservada. Ventanilla " + ventanilla + " - Fila " + fila + ", Butaca " + butaca);
            return true;
        }
        return false;
    }
}
