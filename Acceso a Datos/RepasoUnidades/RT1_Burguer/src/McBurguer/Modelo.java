package McBurguer;

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
import java.util.ArrayList;
import java.util.Date;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;

public class Modelo {

	private final String FTXT = "empleados.txt";
	private final String FBIN = "pedidos.bin";
	private final String FXML = "productos.xml";
	private final String FOBJ = "caja.obj";

	public Empleado obtenerEmpleado(int codEmp, String ps) {
		Empleado resultado = null;

		BufferedReader br = null;

		try {
			br = new BufferedReader(new FileReader(FTXT));

			String linea = "";
			while ((linea = br.readLine()) != null) {
				String[] datos = linea.split(";");

				if (Integer.parseInt(datos[0]) == codEmp) {
					if (datos[1].equalsIgnoreCase(ps) && (Boolean.parseBoolean(datos[4]) == true)) {
						resultado = new Empleado(codEmp, ps, datos[2], datos[3], Boolean.parseBoolean(datos[4]));
					}
				}
			}

		} catch (FileNotFoundException e) {

			e.printStackTrace();

		} catch (IOException e) {

			e.printStackTrace();

		} finally {
			if (br != null) {
				try {
					br.close();
				} catch (IOException e) {

					e.printStackTrace();
				}
			}
		}

		return resultado;
	}

	public int obtenerCodigoPedido() {
		int resultado = 1;

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");

			rAF.seek(rAF.length() - 28);

			resultado = rAF.readInt() + 1;

		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			System.out.println("Aun no hay pedidos.");

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

	public ArrayList<Producto> obtenerProductos() {
		ArrayList<Producto> resultado = new ArrayList<Producto>();

		try {
			Unmarshaller um = JAXBContext.newInstance(McBurgerXML.class).createUnmarshaller();

			McBurgerXML productos = (McBurgerXML) um.unmarshal(new File(FXML));

			resultado = productos.getListaProductos();

		} catch (JAXBException e) {

			e.printStackTrace();
		}

		return resultado;
	}

	public Producto obtenerProducto(int codigo) {
		Producto resultado = null;

		try {
			Unmarshaller um = JAXBContext.newInstance(McBurgerXML.class).createUnmarshaller();

			McBurgerXML productos = (McBurgerXML) um.unmarshal(new File(FXML));

			for (Producto p : productos.getListaProductos()) {
				if (codigo == p.getId()) {
					return p;
				}
			}

		} catch (JAXBException e) {

			e.printStackTrace();
		}

		return resultado;
	}

	public boolean registrarPedido(Pedido p) {
		boolean resultado = false;

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "rw");

			rAF.seek(rAF.length());

			rAF.writeInt(p.getCodigo());
			rAF.writeLong(p.getFecha().getTime());
			rAF.writeInt(p.getCodEmp());
			rAF.writeInt(p.getCodProd());
			rAF.writeInt(p.getCantidad());
			rAF.writeFloat(p.getPrecio());

			resultado = true;

		} catch (FileNotFoundException e) {

			e.printStackTrace();

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

	public ArrayList<Pedido> obtenerPedido(int codigo) {
		ArrayList<Pedido> resultado = new ArrayList<Pedido>();

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");

			while (true) {
				int codigoLeido = rAF.readInt();

				if (codigo == codigoLeido) {

					Pedido p = new Pedido(codigo, new Date(rAF.readLong()), rAF.readInt(), rAF.readInt(), rAF.readInt(),
							rAF.readFloat());

					resultado.add(p);

				} else {
					rAF.seek(rAF.getFilePointer() + 24);
				}
			}
		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			e.printStackTrace();

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

	public ArrayList<Pedido> obtenerPedidosDeUnEmpleado(int codigoEmpleado) {
		ArrayList<Pedido> resultado = new ArrayList<Pedido>();

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");

			while (true) {
				rAF.seek(rAF.getFilePointer() + 12);
				int cod = rAF.readInt();

				if (cod == codigoEmpleado) {
					rAF.seek(rAF.getFilePointer() - 16);

					resultado.add(new Pedido(rAF.readInt(), new Date(rAF.readLong()), rAF.readInt(), rAF.readInt(),
							rAF.readInt(), rAF.readFloat()));

				} else {
					rAF.seek(rAF.getFilePointer() + 12);
				}

			}
		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			e.printStackTrace();

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

	public boolean modificarCantidadPedido(Pedido p) {
		boolean resultado = false;

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "rw");

			while (true) {
				if (rAF.readInt() == p.getCodigo()) {
					rAF.seek(rAF.getFilePointer() + 12);

					if (rAF.readInt() == p.getCodProd()) {
						rAF.writeInt(p.getCantidad());

						return true;
					} else {
						rAF.seek(rAF.getFilePointer() + 8);
					}

				} else {
					rAF.seek(rAF.getFilePointer() + 24);
				}
			}
		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			e.printStackTrace();

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

	public boolean cerrarCaja(CajaEmpleado c) {
		boolean resultado = false;

		ObjectOutputStream oos = null;

		File fichero = new File(FOBJ);

		if (fichero.exists()) {
			try {
				oos = new miObjectOutputStream(new FileOutputStream(FOBJ, true));

			} catch (FileNotFoundException e) {

				e.printStackTrace();
			} catch (IOException e) {

				e.printStackTrace();
			}

		} else {
			try {
				oos = new ObjectOutputStream(new FileOutputStream(FOBJ, true));
			} catch (FileNotFoundException e) {

				e.printStackTrace();
			} catch (IOException e) {

				e.printStackTrace();
			}
		}
		try {
			oos.writeObject(c);
			resultado = true;

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

	public CajaEmpleado obtenerCajaEmpleado(String dni) {
		CajaEmpleado resultado = null;

		ObjectInputStream ois = null;

		try {
			ois = new ObjectInputStream(new FileInputStream(FOBJ));

			while (true) {
				CajaEmpleado obtenido = (CajaEmpleado) ois.readObject();

				if (obtenido.getDni().equalsIgnoreCase(dni)) {
					return obtenido;
				}
			}

		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			System.err.println("Aun no hay datos de caja.");
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

	public ArrayList<CajaEmpleado> obtenerCaja() {
		ArrayList<CajaEmpleado> resultado = new ArrayList<CajaEmpleado>();

		ObjectInputStream ois = null;

		try {
			ois = new ObjectInputStream(new FileInputStream(FOBJ));

			while (true) {
				resultado.add((CajaEmpleado) ois.readObject());
			}

		} catch (EOFException e) {

		} catch (FileNotFoundException e) {

			System.err.println("Aun no hay datos de caja.");
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

}
