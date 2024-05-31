package instaMongo;

import java.util.ArrayList;
import java.util.Arrays;

import org.bson.Document;
import org.bson.conversions.Bson;

import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Accumulators;
import com.mongodb.client.model.Aggregates;
import com.mongodb.client.model.Filters;
import com.mongodb.client.model.Updates;
import com.mongodb.client.result.InsertOneResult;
import com.mongodb.client.result.UpdateResult;

public class Modelo {

	MongoClient conexion = null;
	MongoDatabase bd = null;

	public Modelo() {
		try {
			conexion = MongoClients.create("mongodb://localhost");
			bd = conexion.getDatabase("instamongo");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public MongoClient getConexion() {
		return conexion;
	}

	public void setConexion(MongoClient conexion) {
		this.conexion = conexion;
	}

	public Usuario comprobarCorreo(String email) {
		Usuario resultado = null;
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			Bson filtro = Filters.eq("email", email);
			Document d = col.find(filtro).first();
			
			if (d != null) {
				resultado = new Usuario(d.getInteger("id", 0), d.getString("email"), d.getString("nombre"), d.getInteger("numPublicaciones", 0));
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public int obtenerUltimoID() {
		int resultado = 1;
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			Document d = col.aggregate(Arrays.asList(Aggregates.group(null, Accumulators.max("ID", "$id")))).first();
			if (d != null) {
				resultado = d.getInteger("ID", 1) + 1;
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public boolean crearUsuario(Usuario usr) {
		boolean resultado = false;
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			InsertOneResult r = col.insertOne(new Document()
					.append("id", usr.getId())
					.append("email", usr.getEmail())
					.append("nombre", usr.getNombre())
					.append("numPublicaciones", usr.getNumPublicaciones()));
			
			if (r.getInsertedId() != null) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	public ArrayList<Usuario> obtenerUsuarios() {
		ArrayList<Usuario> resultado = new ArrayList<Usuario>();
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			MongoCursor<Document> r = col.find().iterator();
			
			while (r.hasNext()) {
				Document d = r.next();
				resultado.add(new Usuario(d.getInteger("id", 0), d.getString("email"), d.getString("nombre"), d.getInteger("numPublicaciones", 0)));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public Usuario comprobarUsuario(int idUsr) {
		Usuario resultado = null;
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			Bson filtro = Filters.eq("id", idUsr);
			Document d = col.find(filtro).first();
			
			if (d != null) {
				resultado = new Usuario(d.getInteger("id", 0), d.getString("email"), d.getString("nombre"), d.getInteger("numPublicaciones", 0));
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public int obtenerUltimoIDFoto() {
		int resultado = 1;
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Document d = col.aggregate(Arrays.asList(Aggregates.group(null, Accumulators.max("ID", "$id")))).first();
			if (d != null) {
				resultado = d.getInteger("ID", 1) + 1;
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public boolean crearFoto(Foto f) {
		boolean resultado = false;
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			
			ArrayList<Document> v = new ArrayList<Document>();
			
			for (Visualizacion vis : f.getVisualizaciones()) {
				Document d = new Document()
						.append("amigo", vis.getAmigo())
						.append("meGusta", vis.isMeGusta());
				v.add(d);
			}
			
			InsertOneResult r = col.insertOne(new Document()
					.append("id", f.getId())
					.append("propietario", f.getPropietario())
					.append("url", f.getUrl())
					.append("fecha", f.getFecha())
					.append("visualizaciones", v));
			
			if (r.getInsertedId() != null) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public boolean actualizarFotosPublicadas(Usuario usr) {
		boolean resultado = false;
		
		try {
			MongoCollection<Document> col = bd.getCollection("usuarios");
			Bson filtro = Filters.eq("id", usr.getId());
			Bson modif = Updates.inc("numPublicaciones", usr.getNumPublicaciones() +1);
			UpdateResult rs = col.updateOne(filtro, modif);
			
			if (rs.getModifiedCount() == 1) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public ArrayList<Foto> obtenerFotos(Usuario usr) {
		ArrayList<Foto> resultado = new ArrayList<Foto>();
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Bson filtro = Filters.eq("propietario", usr.getId());
			MongoCursor<Document> r = col.find(filtro).iterator();

			while (r.hasNext()) {
				Document d = r.next();
				ArrayList<Visualizacion> v = new ArrayList<Visualizacion>();
				
				ArrayList<Document> d1 = (ArrayList<Document>) d.get("visualizaciones");
				
				for (Document doc : d1) {
					v.add(new Visualizacion(doc.getInteger("amigo", 0), doc.getBoolean("meGusta", false)));
				}

				resultado.add(new Foto(d.getInteger("id", 0), d.getInteger("propietario", 0), d.getString("url"), d.getDate("fecha"), v));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public ArrayList<Foto> obtenerFotosObservado(Usuario observador, Usuario observado) {
		ArrayList<Foto> resultado = new ArrayList<Foto>();
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Bson filtro = Filters.nin("visualizaciones.amigo", observador.getId());
			MongoCursor<Document> r = col.find(filtro).iterator();

			while (r.hasNext()) {
				Document d = r.next();
				
				if (d.getInteger("propietario", 0) == observado.getId()) {
					ArrayList<Visualizacion> v = new ArrayList<Visualizacion>();
					
					ArrayList<Document> d1 = (ArrayList<Document>) d.get("visualizaciones");
					
					for (Document doc : d1) {
						v.add(new Visualizacion(doc.getInteger("amigo", 0), doc.getBoolean("meGusta", false)));
					}

					resultado.add(new Foto(d.getInteger("id", 0), d.getInteger("propietario", 0), d.getString("url"), d.getDate("fecha"), v));
				}	
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	public Foto comprobarFoto(int idFotoObservado) {
		Foto resultado = null;
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Bson filtro = Filters.eq("id", idFotoObservado);
			MongoCursor<Document> r = col.find(filtro).iterator();

			while (r.hasNext()) {
				Document d = r.next();
				ArrayList<Visualizacion> v = new ArrayList<Visualizacion>();
				
				ArrayList<Document> d1 = (ArrayList<Document>) d.get("visualizaciones");
				
				for (Document doc : d1) {
					v.add(new Visualizacion(doc.getInteger("amigo", 0), doc.getBoolean("meGusta", false)));
				}

				resultado = new Foto(d.getInteger("id", 0), d.getInteger("propietario", 0), d.getString("url"), d.getDate("fecha"), v);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}

	
	public boolean aniadirVisualizacion(Foto f, boolean leGusta) {
		boolean resultado = false;
		int idAmigo = 0;
		boolean meGusta = false;
		
		for (Visualizacion v : f.getVisualizaciones()) {
			idAmigo = v.getAmigo();
			meGusta = v.isMeGusta();
		}
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Bson filtro = Filters.eq("id", f.getId());			
			Bson modif = Updates.addToSet("visualizaciones", new Document().append("amigo", idAmigo).append("meGusta", meGusta));
			UpdateResult r = col.updateOne(filtro, modif);

			if (r.getModifiedCount() == 1) {
				resultado = true;
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;		
	}

	
	public ArrayList<Foto> obtenerFotosObservador(Usuario observador) {
		ArrayList<Foto> resultado = new ArrayList<Foto>();
		
		try {
			MongoCollection<Document> col = bd.getCollection("fotos");
			Bson filtro = Filters.in("visualizaciones.amigo", observador.getId());
			MongoCursor<Document> r = col.find(filtro).iterator();

			while (r.hasNext()) {
				Document d = r.next();
				
				if (d.getInteger("propietario", 0) == observador.getId()) {
					ArrayList<Visualizacion> v = new ArrayList<Visualizacion>();
					
					ArrayList<Document> d1 = (ArrayList<Document>) d.get("visualizaciones");
					
					for (Document doc : d1) {
						v.add(new Visualizacion(doc.getInteger("amigo", 0), doc.getBoolean("meGusta", false)));
					}

					resultado.add(new Foto(d.getInteger("id", 0), d.getInteger("propietario", 0), d.getString("url"), d.getDate("fecha"), v));
				}	
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}
}