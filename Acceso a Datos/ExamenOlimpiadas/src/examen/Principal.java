package examen;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.Scanner;

public class Principal {

	static Connection conexion;
	static Scanner src = new Scanner(System.in);

	public static void main(String[] args) {
		try {
			conexion = DriverManager.getConnection("jdbc:mysql://localhost/skills", "root", "root");

			while (true) {
				System.out.println("#** Menú Principal **#");
				System.out.println("1. Alta alumno / Modalidad");
				System.out.println("2. Crear Prueba");
				System.out.println("3. Registrar Corrección");
				System.out.println("4. Mostrar Ganadores");
				System.out.println("5. Salir");
				System.out.print("Selecciona una opción: ");
				int opcion = src.nextInt();
				src.nextLine();

				switch (opcion) {
				case 1:
					// crearAlumno();
					break;
				case 2:
					crearPrueba();
					break;
				case 3:
					// registrarCorreccion();
					break;
				case 4:
					// mostrarGanadores();
					break;
				case 5:
					break;
				}
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		src.close();
	}

	public static void crearPrueba() {

		mostrarModalidades();

		try {
			System.out.print("Introduce el código de la modalidad: ");
			int codigoModalidad = src.nextInt();
			src.nextLine();

			try {
				CallableStatement cs = conexion.prepareCall("{call obtenerModalidad(?, ?)}");
				cs.setInt(1, codigoModalidad);

				cs.execute();

				String modalidad = cs.getString(2);

				if (modalidad == null) {
					System.err.println("Error: la modalidad no existe.");
					return;
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}

			System.out.print("Introduce la fecha de la prueba: ");
			String fecha = src.nextLine();

			System.out.print("Introduce la descripción: ");
			String descripcion = src.nextLine();

			System.out.print("Introduce la puntuación de la prueba: ");
			int puntuacion = src.nextInt();
			src.nextLine();

			try {
				CallableStatement cs = conexion.prepareCall("{call insertarPrueba(?, ?, ?, ?)}");
				cs.setInt(1, codigoModalidad);
				cs.setString(2, fecha);
				cs.setString(3, descripcion);
				cs.setInt(4, puntuacion);

				cs.executeUpdate();
			} catch (SQLException e) {
				e.printStackTrace();
			}

			try {
				CallableStatement cs = conexion.prepareCall("{call obtenerPruebasModalidad(?)}");
				cs.setInt(1, codigoModalidad);

				ResultSet rs = cs.executeQuery();

				System.out.println("Pruebas de la modalidad:");
				while (rs.next()) {
					System.out.println("ID: " + rs.getInt("id") + ", Descripción: " + rs.getString("descripcion")
							+ ", Puntuación: " + rs.getInt("puntuacion"));
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}

			try {
				CallableStatement cs = conexion.prepareCall("{call obtenerPuntuacionTotalModalidad(?, ?)}");
				cs.setInt(1, codigoModalidad);

				cs.execute();

				int puntuacionTotal = cs.getInt(2);
				System.out.println("Puntuación total de la modalidad: " + puntuacionTotal);
			} catch (SQLException e) {
				e.printStackTrace();
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void mostrarModalidades() {
		System.out.println("#** Modalidades **#");
		
	}
}