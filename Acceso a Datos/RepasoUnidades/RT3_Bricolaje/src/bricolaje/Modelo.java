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
import com.mongodb.client.model.Field;
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
		ArrayList<Producto> resultado = new ArrayList<>();
		try {
			MongoCollection<Document> col = bd.getCollection("productos");
			MongoCursor<Document> r = col.find().iterator();
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
			Document d = col.aggregate(Arrays.asList(Aggregates.group(null, Accumulators.max("n", "$numero")))).first();
			if (d != null) {
				resultado = d.getInteger("n", 1) + 1;
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
		return resultado;
	}

	public boolean crearFactura(Factura f) {
		boolean resultado = false;
		try {
			MongoCollection<Document> col = bd.getCollection("facturas");
			ArrayList<Document> datos = new ArrayList<Document>();
			for (Detalle detalle : f.getListaDetalles()) {
				Document d = new Document().append("producto", detalle.getProducto())
						.append("cantidad", detalle.getCantidad()).append("PrecioUnidad", detalle.getPrecioUnidad());
				datos.add(d);
			}
			InsertOneResult r = col.insertOne(new Document().append("numero", f.getNumero())
					.append("fecha", f.getFecha()).append("cliente", f.getCliente())
					.append("facturaAnulacion", f.getFacturaAnulacion()).append("detalle", datos));
			if (r.getInsertedId() != null) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return resultado;
	}

	public boolean actualizarStock(Detalle i) {
		boolean resultado = false;
		try {
			MongoCollection<Document> col = bd.getCollection("productos");
			Bson filtro = Filters.eq("codigo", i.getProducto());
			Bson modif = Updates.inc("stock", i.getCantidad() * -1);
			UpdateResult rs = col.updateOne(filtro, modif);
			if (rs.getModifiedCount() == 1) {
				resultado = true;
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return resultado;

	}

	public ArrayList<Factura> obtenerFacturas() {
		ArrayList<Factura> resultado = new ArrayList<Factura>();

		try {
			MongoCollection<Document> col = bd.getCollection("facturas");
			Bson filtro = Filters.eq("facturaAnulacion", 0);
			MongoCursor<Document> r = col.find(filtro).iterator();

			while (r.hasNext()) {
				Document d = r.next();
				ArrayList<Detalle> detalle = new ArrayList<Detalle>();
				ArrayList<Document> d1 = (ArrayList<Document>) d.get("detalle");
				for (Document doc : d1) {
					detalle.add(new Detalle(doc.getString("producto"), doc.getInteger("cantidad"),
							doc.getDouble("PrecioUnidad")));
				}

				resultado.add(new Factura(d.getInteger("numero", 0), d.getDate("fecha"), d.getString("cliente"),
						detalle, d.getInteger("facturaAnulacion", 0)));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public Factura obtenerFactura(int numFactura) {
		Factura resultado = null;

		try {
			MongoCollection<Document> col = bd.getCollection("facturas");
			Bson filtro = Filters.and(Filters.eq("facturaAnulacion", 0), Filters.eq("numero", numFactura));
			Document r = col.find(filtro).first();

			if (r != null) {
				Document d = r;
				ArrayList<Detalle> detalle = new ArrayList<Detalle>();
				ArrayList<Document> d1 = (ArrayList<Document>) d.get("detalle");
				for (Document doc : d1) {
					detalle.add(new Detalle(doc.getString("producto"), doc.getInteger("cantidad"),
							doc.getDouble("PrecioUnidad")));
				}

				resultado = new Factura(d.getInteger("numero", 0), d.getDate("fecha"), d.getString("cliente"), detalle,
						d.getInteger("facturaAnulacion", 0));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public boolean modificarFacturaOriginal(int nAnulacion, int nOriginal) {
		boolean resultado = false;

		try {
			MongoCollection<Document> col = bd.getCollection("facturas");
			Bson filtro = Filters.eq("numero", nOriginal);
			Bson modif = Updates.set("facturaAnulacion", nAnulacion);
			UpdateResult r = col.updateOne(filtro, modif);

			if (r.getModifiedCount() == 1) {
				resultado = true;
			}

		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Object[]> obtenerEstadisticas() {
		ArrayList<Object[]> resultado = new ArrayList<Object[]>();

		try {
			MongoCollection<Document> col = bd.getCollection("facturas");

			MongoCursor<Document> r = col.aggregate(Arrays.asList(Aggregates.unwind("$detalle"),
					Aggregates.addFields(new Field<Document>("importe",
							new Document("$multiply", Arrays.asList("$detalle.PrecioUnidad", "$detalle.cantidad")))),
					Aggregates.group("$detalle.producto", Accumulators.sum("numVentas", 1), // Equivale a count
							Accumulators.sum("cantidad", "$detalle.cantidad"), Accumulators.sum("importe", "$importe")),
					// Colec Dest, clave externa, clave primaria, alias
					Aggregates.lookup("productos", "_id", "codigo", "datosProducto"))).iterator();

			while (r.hasNext()) {

				Document d = r.next();
				System.out.println("**** Datos en JSON *****");
				System.out.println(d.toJson());
				System.out.println("**** Fin Datos en JSON *****");
				ArrayList<Document> producto = (ArrayList<Document>) d.get("datosProducto");
				resultado.add(new Object[] { d.getString("_id"), producto.get(0).getString("nombre"),
						d.getInteger("numVentas"), d.getInteger("cantidad"), d.getDouble("importe") });
			}

		} catch (Exception e) {
			e.printStackTrace();
		}

		return resultado;
	}

}