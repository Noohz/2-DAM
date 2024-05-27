package museo;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Modelo {
	final String URL = "jdbc:postgresql://localhost/Museo";
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

	public boolean crearInventario(Inventario inv) {
		boolean resultado = false;

		try {

			PreparedStatement pS = conexion
					.prepareStatement("INSERT INTO inventario VALUES(default, ?, ?, (?, ?), null)");
			pS.setString(1, inv.getNombre());
			pS.setDate(2, new Date(inv.getFechaAlta().getTime()));
			pS.setString(3, inv.getUbicacion().getSeccion());
			pS.setInt(4, inv.getUbicacion().getPuesto());

			int filas = pS.executeUpdate();

			if (filas == 1) {
				resultado = true;
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Inventario> obtenerInventarios() {
		ArrayList<Inventario> resultado = new ArrayList<Inventario>();
		ArrayList<String[]> datosB = new ArrayList<String[]>();

		try {
			Statement s = conexion.createStatement();

			ResultSet rs = s.executeQuery(
					"SELECT id, nombre, fechaAlta, (ubicacion).seccion, (ubicacion).puesto, carateristicas FROM inventario");
			while (rs.next()) {

				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}

				resultado.add(new Inventario(rs.getInt(1), rs.getString(2), rs.getDate(3),
						new TipoUbicacion(rs.getString(4), rs.getInt(5)), datosB));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Inventario obtenerInventario(int codInv) {
		Inventario resultado = null;
		ArrayList<String[]> datosB = new ArrayList<String[]>();

		try {
			PreparedStatement ps = conexion.prepareStatement(
					"SELECT id, nombre, fechaAlta, (ubicacion).seccion, (ubicacion).puesto, carateristicas FROM inventario WHERE id = ?");
			ps.setInt(1, codInv);
			ResultSet rs = ps.executeQuery();

			if (rs.next()) {
				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}

				resultado = new Inventario(rs.getInt(1), rs.getString(2), rs.getDate(3),
						new TipoUbicacion(rs.getString(4), rs.getInt(5)), datosB);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean modificarUbicacionInventario(Inventario inv) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion.prepareStatement("UPDATE inventario SET ubicacion = (?, ?) WHERE id = ?");
			pS.setString(1, inv.getUbicacion().getSeccion());
			pS.setInt(2, inv.getUbicacion().getPuesto());
			pS.setInt(3, inv.getId());

			if (pS.executeUpdate() == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Inventario> obtenerInventarioUnico(Inventario inv) {
		ArrayList<Inventario> resultado = new ArrayList<Inventario>();
		ArrayList<String[]> datosB = new ArrayList<String[]>();

		try {
			PreparedStatement pS = conexion.prepareStatement(
					"SELECT id, nombre, fechaAlta, (ubicacion).seccion, (ubicacion).puesto, carateristicas FROM inventario WHERE id = ?");
			pS.setInt(1, inv.getId());

			ResultSet rs = pS.executeQuery();

			if (rs.next()) {
				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}

				resultado.add(new Inventario(rs.getInt(1), rs.getString(2), rs.getDate(3),
						new TipoUbicacion(rs.getString(4), rs.getInt(5)), datosB));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean borrarInventario(Inventario inv) {
		boolean resultado = false;
		PreparedStatement ps = null;

		try {
			ps = conexion.prepareStatement("DELETE FROM inventario WHERE id = ?");
			ps.setInt(1, inv.getId());

			if (ps.executeUpdate() == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Inventario> obtenerCaracteristicas(int id) {
		ArrayList<Inventario> resultado = new ArrayList<Inventario>();

		try {
			PreparedStatement ps = conexion.prepareStatement(
					"SELECT id, nombre, fechaAlta, (ubicacion).seccion, (ubicacion).puesto, carateristicas FROM inventario WHERE id = ?");
			ps.setInt(1, id);

			ResultSet rs = ps.executeQuery();

			while (rs.next()) {
				ArrayList<String[]> datosB = new ArrayList<String[]>();

				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}

				resultado.add(new Inventario(rs.getInt(1), rs.getString(2), rs.getDate(3),
						new TipoUbicacion(rs.getString(4), rs.getInt(5)), datosB));

			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

}
