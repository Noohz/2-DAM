package serviHogar;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Modelo {
	final String URL = "jdbc:postgresql://localhost/ServiHogar";
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

	public boolean crearPresupuesto(Presupuesto p, String descServ, int numHorasServ, float importeServ) {
		boolean resultado = false;
		
		try {
			PreparedStatement pS = conexion.prepareStatement("INSERT INTO presupuesto VALUES(default, ?, (?, ?, ?), servicios = array[array[?,?,?]])");
			pS.setDate(1, new Date((p.getFecha().getTime())));
			pS.setString(2, p.getDatosCliente().getDni());
			pS.setString(3, p.getDatosCliente().getNombre());
			pS.setString(4, p.getDatosCliente().getTelefono());
			pS.setString(5, descServ);
			pS.setString(6, String.valueOf(numHorasServ));
			pS.setString(7, String.valueOf(importeServ));
			
			int filas = pS.executeUpdate();
			if (filas == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	public ArrayList<Presupuesto> obtenerPresupuestos() {
		ArrayList<Presupuesto> resultado = new ArrayList<Presupuesto>();
		ArrayList<String[]> datosB = new ArrayList<String[]>();
		
		try {
			Statement s = conexion.createStatement();
			ResultSet rs = s.executeQuery("SELECT id, fecha, (cliente).dni, (cliente).nombre, (cliente).telefono, servicios FROM presupuesto ORDER BY fecha DESC");
			
			while (rs.next()) {

				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}

				resultado.add(new Presupuesto(rs.getInt(1), rs.getDate(2), new Cliente(rs.getString(3), rs.getString(4), rs.getString(5)), datosB));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	public Presupuesto obtenerPresupuesto(int id) {
		Presupuesto resultado = null;
		try {
			PreparedStatement ps = conexion.prepareStatement("SELECT id, fecha, (cliente).dni, (cliente).nombre, (cliente).telefono, servicios FROM presupuesto WHERE id = ?");
			ps.setInt(1, id);
			
			ResultSet rs = ps.executeQuery();
			if (rs.next()) {
				ArrayList<String[]> datosB = new ArrayList<String[]>();

				if (rs.getArray(6) != null) {
					String[][] datos = (String[][]) rs.getArray(6).getArray();

					datosB = new ArrayList<String[]>();
					for (String[] c : datos) {
						datosB.add(c);
					}
				}
				resultado = new Presupuesto(rs.getInt(1), rs.getDate(2), new Cliente(rs.getString(3), rs.getString(4), rs.getString(5)), datosB);
			}
		} catch (SQLException e) {
			
			e.printStackTrace();
		}
		return resultado;
	}

	
	public boolean aniadirServicio(Presupuesto p, String descServ, int numHServ, float importServicio) {
		boolean resultado = false;
		
		try {
			PreparedStatement pS = conexion.prepareStatement("UPDATE presupuesto SET servicios = array_cat(servicios, array[?,?,?]::text[][]) WHERE id = ?");
			pS.setString(1, descServ);
			pS.setString(2, String.valueOf(numHServ));
			pS.setString(3, String.valueOf(importServicio));
			pS.setInt(4, p.getId());
			
			int filas = pS.executeUpdate();
			if (filas == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return resultado;
	}
}
