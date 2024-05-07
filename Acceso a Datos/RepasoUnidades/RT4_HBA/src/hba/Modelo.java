package hba;

import java.util.ArrayList;
import java.util.List;

import jakarta.persistence.EntityManager;
import jakarta.persistence.Persistence;
import jakarta.persistence.Query;

public class Modelo {
	private EntityManager conexion = null;

	public Modelo() {
		try {
			conexion = Persistence.createEntityManagerFactory("Series").createEntityManager();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public EntityManager getConexion() {
		return conexion;
	}

	public void setConexion(EntityManager conexion) {
		this.conexion = conexion;
	}

	public void cerrar() {
		if (conexion != null) {
			try {
				conexion.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}

	public List<Usuario> obtenerUsuarios() {
		List<Usuario> resultado = new ArrayList<Usuario>();

		try {
			Query c = conexion.createQuery("FROM Usuario");
			resultado = c.getResultList();

		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Usuario obtenerUsuario(String nick) {
		Usuario resultado = null;

		try {
			return conexion.find(Usuario.class, nick);

		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}
}
