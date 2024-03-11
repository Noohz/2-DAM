package ejercicio6;

public class EjecutarEjercicio6 {
	public static void main(String[] args) {
		String[] appArguments = { "Ejercicio6", "10" };

		// Ejecutar la aplicación XxxXxx con diferentes argumentos
		for (int i = 0; i < 5; i++) {
			try {
				Process process = Runtime.getRuntime().exec("java Ejercicio6 " + appArguments[0] + " " + appArguments[1]);
				int exitCode = process.waitFor();
				if (exitCode == 0) {
					System.out.println("La aplicación se ejecutó con éxito.");
				} else {
					System.err.println("La aplicación finalizó con un código de salida no nulo: " + exitCode);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
}
