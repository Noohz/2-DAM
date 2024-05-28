package bricolaje;

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
import com.mongodb.client.result.InsertOneResult;

public class Modelo {
	private MongoClient conexion = null;
	private MongoDatabase bd = null;

	public Modelo() {
		try {
			conexion = MongoClients.create("mongodb://localhost");
			bd = conexion.getDatabase("bricolaje");
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

	public void cerrar() {
		try {
			conexion.close();
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	public Producto obtenerProducto(String codigo) {
		Producto resultado = null;

		try {
			// Nos conectamos a la colección Producto
			MongoCollection<Document> col = bd.getCollection("productos");
			Bson filtro = Filters.eq("codigo", codigo);
			Document d = col.find(filtro).first();

			if (d != null) {
				resultado = new Producto(d.getString("codigo"), d.getString("nombre"), d.getDouble("precio"),
						d.getInteger("stock"));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean crearProducto(Producto p) {
		boolean resultado = false;

		try {
			MongoCollection<Document> col = bd.getCollection("productos");
			InsertOneResult r = col.insertOne(new Document().append("codigo", p.getCodigo())
					.append("nombre", p.getNombre()).append("stock", p.getStock()).append("precio", p.getPrecio()));

			if (r.getInsertedId() != null) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Producto> obtenerProductos() {
		ArrayList<Producto> resultado = new ArrayList<Producto>();

		try {
			MongoCollection<Document> col = bd.getCollection("productos");
			MongoCursor<Document> r = col.find().iterator(); // Si hacemos un SELECT * hay que usar el iterator.
			
			while (r.hasNext()) {
				Document d = r.next();
				
				resultado.add(new Producto(d.getString("codigo"), d.getString("nombre"), d.getDouble("precio"),
						d.getInteger("stock")));
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	
	public int obtenerNumeroFactura() {
		int resultado = 1;
		
		try {
			MongoCollection<Document> col = bd.getCollection("facturas");
			Document d = col.aggregate(Arrays.asList(Aggregates.group(null, Accumulators.max("N", "$numero")))).first(); // El "N" del Accumulators.Max se refiere al alias del campo.
			
			resultado = d.getInteger("N", 1) +1;
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultado;
	}
}
