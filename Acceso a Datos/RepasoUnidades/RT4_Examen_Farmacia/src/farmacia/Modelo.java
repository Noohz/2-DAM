package farmacia;

import java.util.ArrayList;
import java.util.List;

import jakarta.persistence.EntityManager;
import jakarta.persistence.Persistence;
import jakarta.persistence.Query;

public class Modelo {
	private EntityManager conexion = null;

	public Modelo() {
		try {
			conexion = Persistence.createEntityManagerFactory("Farmacia").createEntityManager();
		} catch (Exception e) {
			// TODO: handle exception
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

	public List<Farmacia> obtenerFarmacia(String codigo) {
		List<Farmacia> resultado = new ArrayList();

		try {
			Query consulta = conexion.createQuery("FROM farmacia WHERE cif = ?");
			consulta.setParameter(0, codigo);
			resultado = consulta.getResultList();

		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean crearFarmacia(Farmacia far) {
		boolean resultado = false;

		try {
			conexion.getTransaction().begin();
			conexion.persist(far);
			conexion.getTransaction().commit();
			conexion.clear();
			resultado = true;
		} catch (Exception e) {
			conexion.getTransaction().rollback();
			e.printStackTrace();
		}

		return resultado;
	}

	public List<Farmacia> obtenerFarmacias() {
		List<Farmacia> resultado = new ArrayList();
		
		try {
			Query consulta = conexion.createQuery("FROM farmacia");
			resultado = consulta.getResultList();
		} catch (Exception e) {
			e.printStackTrace();
		}		
		return resultado;
	}	
}
