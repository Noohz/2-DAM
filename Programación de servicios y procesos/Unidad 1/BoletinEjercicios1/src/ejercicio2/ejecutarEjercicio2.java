package ejercicio2;

public class ejecutarEjercicio2 {

	public static void main(String[] args) {
		try {
			ProcessBuilder pb = new ProcessBuilder("java", "Ejercicio2", "60");
			Process p1 = pb.start();
			int exitCode = p1.waitFor();

			System.out.println("Codigo de salida " +exitCode);
			
			if (exitCode == 0) {
				System.out.println("System.exit = 0");
			} else if (exitCode == 1) {
				System.out.println("System.exit = 1");
			} else if (exitCode == 2) {
				System.out.println("System.exit = 2");
			} else if (exitCode == 3) {
				System.out.println("System.exit = 3");
			} else {
				System.out.println("Error desconocido...");
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
