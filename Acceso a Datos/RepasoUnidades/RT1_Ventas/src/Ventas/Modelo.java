package Ventas;

import java.io.BufferedReader;
import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.RandomAccessFile;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class Modelo {

	final String FTXT = "ventas.txt";
	final String FOBJ = "ventas.obj";
	final String FTMP = "ventas.tmp";
	final String FBIN = "stock.bin";
	private SimpleDateFormat formatoFecha = new SimpleDateFormat("dd/MM/yyyy");

	public Modelo() {
	}

	public ArrayList<VentasTxt> obtenerVentasTxt() {

		ArrayList<VentasTxt> resultado = new ArrayList<VentasTxt>();
		BufferedReader lector = null;

		try {
			lector = new BufferedReader(new FileReader(FTXT));

			String linea = "";
			while ((linea = lector.readLine()) != null) {
				String[] campos = linea.split(";");

				VentasTxt v = new VentasTxt(Integer.parseInt(campos[0]), Integer.parseInt(campos[2]),
						formatoFecha.parse(campos[1]), Float.parseFloat(campos[3]));
				resultado.add(v);
			}

		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (NumberFormatException e) {
			System.err.println("Error, existe una fecha incorrecta.");
		} catch (ParseException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			if (lector != null) {
				try {
					lector.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public VentasObj obtenerVentaObj(int producto) {
		VentasObj resultado = null;
		ObjectInputStream ois = null;

		try {
			ois = new ObjectInputStream(new FileInputStream(FOBJ));

			while (true) {
				VentasObj v = (VentasObj) ois.readObject();

				if (v.getProducto() == producto) {
					return v;
				}
			}
		} catch (EOFException e) {
			// No ponemos nada, permite salir del while (true).
		} catch (FileNotFoundException e) {
			System.out.println("El fichero vObj aun no existe.");
		} catch (IOException e) {

			e.printStackTrace();
		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		} finally {
			if (ois != null) {
				try {
					ois.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public boolean crearVenta(VentasObj vObj) {
		boolean resultado = false;
		ObjectOutputStream oos = null;

		try {
			if (new File(FOBJ).exists()) {
				oos = new miObjectOutputStream(new FileOutputStream(FOBJ, true));
			} else {
				oos = new ObjectOutputStream(new FileOutputStream(FOBJ, true));
			}

			oos.writeObject(vObj);
			resultado = true;

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			if (oos != null) {
				try {
					oos.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public boolean modificarVenta(VentasObj vObj) {
		boolean resultado = false;
		ObjectInputStream fOriginal = null;
		ObjectOutputStream fTemporal = null;

		try {
			fOriginal = new ObjectInputStream(new FileInputStream(FOBJ));
			fTemporal = new ObjectOutputStream(new FileOutputStream(FTMP, false));

			while (true) { // Recorro el fichero de ventas y solo cambio las que coincidan con la que hay
							// que modificar.
				VentasObj v = (VentasObj) fOriginal.readObject();

				if (v.getProducto() == vObj.getProducto()) {
					fTemporal.writeObject(vObj);
				} else {
					fTemporal.writeObject(v);
				}
			}

		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		} finally {
			if (fOriginal != null) {
				try {
					fOriginal.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
			if (fTemporal != null) {
				try {
					fTemporal.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		File fO = new File(FOBJ);
		File fT = new File(FTMP);
		if (fO.delete()) {
			if (fT.renameTo(fO)) {
				resultado = true;
			} else {
				System.err.println("Error al renombrar el fichero.");
			}
		} else {
			System.err.println("Error al borrar el fichero.");
		}

		return resultado;
	}

	public ArrayList<VentasObj> obtenerVentasObj() {

		ArrayList<VentasObj> resultado = new ArrayList<VentasObj>();
		ObjectInputStream fVentas = null;

		try {
			fVentas = new ObjectInputStream(new FileInputStream(FOBJ));

			while (true) {
				resultado.add((VentasObj) fVentas.readObject());
			}

		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();

		} catch (ClassNotFoundException e) {

			e.printStackTrace();
		} finally {
			if (fVentas != null) {
				try {
					fVentas.close();

				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public boolean crearProducto(Productos p) {
		boolean resultado = false;
		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "rw"); // La clase RandomAccessFile no tiene Output / Input así que se usa
													// "r" para leer y "rw" para leer y escribir.

			rAF.seek(rAF.getFilePointer()); // Si abrimos para escritura hay que mover el cursor del fichero al final.

			rAF.writeInt(p.getIdProducto());

			// El nombre debe de tener un tamaño fijo (30 carácteres en este caso)
			StringBuffer nombre = new StringBuffer(p.getNombre());
			nombre.setLength(30);

			rAF.writeChars(nombre.toString()); // Hay que usar toString().
			rAF.writeInt(p.getStock());

		} catch (IOException e) {

			e.printStackTrace();
		} finally {
			if (rAF != null) {
				try {
					rAF.close();

				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public ArrayList<Productos> obtenerProductos() {
		ArrayList<Productos> resultado = new ArrayList<Productos>();
		RandomAccessFile productos = null;
		String nombre = "";
				
		try {
			productos = new RandomAccessFile(FBIN, "r");
			
			while (true) {
				Productos p = new Productos();
				
				p.setIdProducto(productos.readInt());
				
				for (int i = 0; i < 30; i++) {
					nombre += productos.readChar();
				}
				p.setNombre(nombre);
				p.setStock(productos.readInt());
			}
		} catch (EOFException e) {
			
		} catch (FileNotFoundException e) {
			
			e.printStackTrace();
			
		} catch (IOException e) {
			
			e.printStackTrace();
		} finally {
			if (productos != null) {
				try {
					productos.close();

				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}
		
		return resultado;
	}
}
