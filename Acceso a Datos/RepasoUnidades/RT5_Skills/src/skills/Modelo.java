package skills;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Modelo {
	final String URL = "jdbc:postgresql://localhost:5432/Skills";
	final String USR = "postgres";
	final String PS = "postgres";

	private Connection conexion = null;

	public Modelo() {
		try {
			Class.forName("org.postgresql.Driver");
			conexion = DriverManager.getConnection(URL, USR, PS);

		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public void cerrar() {
		try {
			conexion.close();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public Connection getConexion() {
		return conexion;
	}

	public void setConexion(Connection conexion) {
		this.conexion = conexion;
	}

	public int obtenerPuntuacion(int id) {
		int resultado = 0;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT SUM(puntuacion) FROM prueba WHERE modalidad = ?");
			pS.setInt(1, id);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = datos.getInt(1);
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		return resultado;
	}

	public boolean crearPrueba(Prueba p) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion.prepareStatement("INSERT INTO prueba VALUES(default, ?, ?, (?, ?), ?)");
			pS.setInt(1, p.getModalidad());
			pS.setDate(2, new Date(p.getFecha().getTime()));
			pS.setString(3, p.getInfo().getTitulo());
			pS.setString(4, p.getInfo().getDescripcion());
			pS.setInt(5, p.getPuntuacion());

			if (pS.executeUpdate() == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Prueba> obtenerPruebas(Modalidad m) {
		ArrayList<Prueba> resultado = new ArrayList<Prueba>();

		try {
			if (m != null) {
				PreparedStatement pS = conexion.prepareStatement(
						"SELECT id, fecha, (info).titulo, (info).descripcion, puntuacion FROM prueba WHERE modalidad = ?");
				pS.setInt(1, m.getId());
				ResultSet datos = pS.executeQuery();

				while (datos.next()) {
					resultado.add(new Prueba(datos.getInt(1), m.getId(), datos.getDate(2),
							new Infoprueba(datos.getString(3), datos.getString(4)), datos.getInt(5)));
				}
			} else {
				Statement s = conexion.createStatement();
				ResultSet datos = s.executeQuery(
						"SELECT id, fecha, (info).titulo, (info).descripcion, puntuacion, modalidad FROM prueba");

				while (datos.next()) {
					resultado.add(new Prueba(datos.getInt(1), datos.getInt(6), datos.getDate(2),
							new Infoprueba(datos.getString(3), datos.getString(4)), datos.getInt(5)));
				}
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
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return resultado;
	}

	public Modalidad obtenerModalidad(int codigo) {
		Modalidad resultado = null;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM modalidad WHERE id = ?");
			pS.setInt(1, codigo);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = new Modalidad(datos.getInt(1), datos.getString(2));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Prueba obtenerPrueba(int codigo) {
		Prueba resultado = null;

		try {
			PreparedStatement pS = conexion.prepareStatement(
					"SELECT id, fecha, (info).titulo, (info).descripcion, puntuacion, modalidad FROM prueba WHERE id = ?");
			pS.setInt(1, codigo);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = new Prueba(datos.getInt(1), datos.getInt(6), datos.getDate(2),
						new Infoprueba(datos.getString(3), datos.getString(4)), datos.getInt(5));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean modificarPrueba(Prueba p) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion.prepareStatement(
					"UPDATE prueba SET(fecha = ?, puntuacion = ?, info = (?, ?)) WHERE id = ?");
			pS.setDate(1, new Date(p.getFecha().getTime()));
			pS.setInt(2, p.getPuntuacion());
			pS.setString(3, p.getInfo().getTitulo());
			pS.setString(4, p.getInfo().getDescripcion());
			pS.setInt(5, p.getId());

			if (pS.executeUpdate() == 1) {
				return true;
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

}
