package ejercicio2;

public class Ejercicio2 {

    public static void main(String[] args) {
        if (args.length < 1) {
            System.exit(1);
        } else {
            for (int i = 0; i < args.length; i++) {
                try {
                    int numero = Integer.parseInt(args[i]);
                    if (numero < 0) {
                        System.exit(3);
                    }
                } catch (NumberFormatException e) {
                    System.exit(2);
                }
            }
        }
    }
}
