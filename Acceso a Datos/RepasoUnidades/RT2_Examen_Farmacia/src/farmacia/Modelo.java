package farmacia;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Modelo {
	private Connection conexion = null;
	private final String URL = "jdbc:mysql://localhost:3307/farmacia";
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

	public Connection getConexion() {
		return conexion;
	}

	public void setConexion(Connection conexion) {
		this.conexion = conexion;
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

	public Farmacia comprobarExistenciaFarmaciaCif(String cif) {
		Farmacia resultado = null;

		PreparedStatement pS;
		try {
			pS = conexion.prepareStatement("SELECT * FROM farmacia WHERE cif = ?");
			pS.setString(1, cif);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = new Farmacia(datos.getInt(1), datos.getString(2), datos.getString(3), datos.getString(4));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean crearFarmacia(Farmacia farmacia) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion.prepareStatement("INSERT INTO farmacia VALUES(default, ?, ?, ?)");
			pS.setString(1, farmacia.getNombre());
			pS.setString(2, farmacia.getCif());
			pS.setString(3, farmacia.getDireccion());
			int filas = pS.executeUpdate();

			if (filas == 1) {
				resultado = true;
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public int obtenerCodigoFarmacia(Farmacia farmacia) {
		int resultado = 0;

		try {
			PreparedStatement pS = conexion
					.prepareStatement("SELECT * FROM farmacia WHERE nombre = ? AND cif = ? AND direccion = ?");
			pS.setString(1, farmacia.getNombre());
			pS.setString(2, farmacia.getCif());
			pS.setString(3, farmacia.getDireccion());
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = datos.getInt(1);
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Farmacia> obtenerFarmacias() {
		ArrayList<Farmacia> resultado = new ArrayList<Farmacia>();

		try {
			Statement s = conexion.createStatement();
			ResultSet datos = s.executeQuery("SELECT * FROM farmacia");

			while (datos.next()) {
				resultado
						.add(new Farmacia(datos.getInt(1), datos.getString(2), datos.getString(3), datos.getString(4)));
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean comprobarExistenciaFarmaciaCodigo(int codigo) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM farmacia WHERE codigo = ?");
			pS.setInt(1, codigo);
			ResultSet datos = pS.executeQuery();

			if (datos.next()) {
				resultado = true;
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Pedido comprobarPedidosFarmacia(int codFarmacia) {
		Pedido resultado = null;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM pedido WHERE farmacia = ? AND cerrado = 0");
			pS.setInt(1, codFarmacia);
			ResultSet datos = pS.executeQuery();

			while (datos.next()) {
				resultado = new Pedido(datos.getInt(1), datos.getDate(2), datos.getInt(3), datos.getBoolean(4),
						datos.getInt(5), datos.getFloat(6));
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean crearPedido(int codFarmacia) {
		boolean resultado = false;

		try {
			PreparedStatement pS = conexion
					.prepareStatement("INSERT INTO pedido VALUES(default, curdate(), ?, ?, default, default)");
			pS.setInt(1, codFarmacia);
			pS.setBoolean(2, false);
			int filas = pS.executeUpdate();

			if (filas == 1) {
				resultado = true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Pedido> obtenerPedidoFaramcia(int codFarmacia) {
		ArrayList<Pedido> resultado = new ArrayList<Pedido>();

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM pedido WHERE farmacia = ?");
			pS.setInt(1, codFarmacia);
			ResultSet datos = pS.executeQuery();

			while (datos.next()) {
				resultado.add(new Pedido(datos.getInt(1), datos.getDate(2), datos.getInt(3), datos.getBoolean(4),
						datos.getInt(5), datos.getFloat(6)));
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<InfoPedidos> infoPedidos(int codFarmacia) {
		ArrayList<InfoPedidos> resultado = new ArrayList<InfoPedidos>();

		try {
			CallableStatement cB = conexion.prepareCall("{call infoPedidos(?)}");
			cB.setInt(1, codFarmacia);
			ResultSet datos = cB.executeQuery();

			while (datos.next()) {
				resultado.add(new InfoPedidos(datos.getInt(1), datos.getInt(2), datos.getInt(3), datos.getDate(4),
						datos.getDate(5), datos.getInt(6)));
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Pedido obtenerPedidosAbiertos() {
		Pedido resultado = null;

		try {
			PreparedStatement pS = conexion.prepareStatement("SELECT * FROM pedido WHERE cerrado = 0");
			ResultSet datos = pS.executeQuery();

			while (datos.next()) {
				resultado = new Pedido(datos.getInt(1), datos.getDate(2), datos.getInt(3), datos.getBoolean(4),
						datos.getInt(5), datos.getFloat(6));
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Articulo> obtenerArticulos() {
		ArrayList<Articulo> resultado = new ArrayList<Articulo>();
		
		try {
			Statement s = conexion.createStatement();
			ResultSet datos = s.executeQuery("SELECT * FROM articulo");
			
			while (datos.next()) {
				resultado.add(new Articulo(datos.getInt(1), datos.getString(2), datos.getFloat(3)));				
			}
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

}
