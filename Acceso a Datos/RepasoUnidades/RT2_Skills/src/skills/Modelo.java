package skills;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Modelo {
	private Connection conexion = null;
	private final String URL = "jdbc:mysql://localhost:3307/skills";
	private final String US = "root";
	private final String PS = "root";

	public Modelo() {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			conexion = DriverManager.getConnection(URL, US, PS);

		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		} catch (SQLException e) {

			e.printStackTrace();
		}
	}

	public void cerrar() {
		if (conexion != null) {
			try {
				conexion.close();
			} catch (SQLException e) {

				e.printStackTrace();
			}
		}
	}

	public Connection getConexion() {
		return conexion;
	}

	public void setConexion(Connection conexion) {
		this.conexion = conexion;
	}

	public Alumno obtenerAlumno(String dni) {
		Alumno resultado = null;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM alumno AS AL INNER JOIN modalidad AS MOD "
					+ "ON AL.modalidad = MOD.id " + "WHERE dni = ?");
			pS.setString(1, dni);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = new Alumno(datos.getInt(1), dni, datos.getInt(4), datos.getBoolean(5),
						new Modalidad(datos.getInt(3), datos.getString(7)));
			}

		} catch (SQLException e) {

			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Modalidad> obtenerModalidades() {
		ArrayList<Modalidad> resultado = new ArrayList<Modalidad>();
		
		try {
			Statement s = conexion.createStatement();
			ResultSet datos = s.executeQuery("SELECT * FROM modalidad");
			
			while (datos.next()) {
				resultado.add(new Modalidad(datos.getInt(1), datos.getString(2)));
			}
			
		} catch (SQLException e) {
			
			e.printStackTrace();
		}
		
		return resultado;
	}

}
