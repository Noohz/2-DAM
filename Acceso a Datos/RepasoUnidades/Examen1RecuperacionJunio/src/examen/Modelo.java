package examen;

import java.io.BufferedReader;
import java.io.EOFException;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.ArrayList;

public class Modelo {

	final String FTXT = "artistas.txt";
	final String FBIN = "canciones.bin";

	public Modelo() {

	}

	public ArrayList<Artista> obtenerArtistasTxt() {
		ArrayList<Artista> resultado = new ArrayList<Artista>();

		BufferedReader lector = null;

		try {
			lector = new BufferedReader(new FileReader(FTXT));

			String linea = "";
			while ((linea = lector.readLine()) != null) {
				String[] datos = linea.split(";");

				Artista aTXT = new Artista(Integer.parseInt(datos[0]), datos[1], datos[2]);

				resultado.add(aTXT);
			}

		} catch (FileNotFoundException e) {

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

	public boolean crearCancion(Canciones c) {
		boolean resultado = false;

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "rw");

			rAF.seek(rAF.length());

			rAF.writeInt(c.getCodigo());
			rAF.writeInt(c.getArtista());

			StringBuffer titulo = new StringBuffer(c.getTitulo());
			titulo.setLength(50);
			rAF.writeChars(titulo.toString());

			rAF.writeInt(c.getDuracion());

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

	public Artista buscarArtista(int codArtista) {
		Artista resultado = null;

		BufferedReader bR = null;

		try {
			bR = new BufferedReader(new FileReader(FTXT));

			String linea = "";
			while ((linea = bR.readLine()) != null) {
				String[] datos = linea.split(";");

				if (Integer.parseInt(datos[0]) == codArtista) {
					resultado = new Artista(codArtista, datos[1], datos[2]);
				}
			}

		} catch (FileNotFoundException e) {

			e.printStackTrace();
		} catch (NumberFormatException e) {

			e.printStackTrace();
		} catch (IOException e) {

			e.printStackTrace();
		}

		return resultado;
	}

	public ArrayList<Canciones> obtenerCancionesDelArtista(Canciones c2) {
		ArrayList<Canciones> resultado = new ArrayList<Canciones>();
		String titulo = "";

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");
			rAF.seek(4);

			if (rAF.readInt() == c2.getArtista()) {
				while (true) {
					Canciones cancion = new Canciones();

					cancion.setCodigo(rAF.readInt());
					cancion.setArtista(rAF.readInt());

					for (int i = 0; i < 50; i++) {
						cancion.setTitulo(titulo += rAF.readChar());
					}
					cancion.setTitulo(titulo.trim());
					cancion.setDuracion(rAF.readInt());

					resultado.add(cancion);
				}
			} else {
				rAF.seek(rAF.getFilePointer() + 108);
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

	public ArrayList<Canciones> obtenerTodasLasCanciones() {
		ArrayList<Canciones> resultado = new ArrayList<Canciones>();

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");

			while (true) {
				Canciones cancion = new Canciones();

				cancion.setCodigo(rAF.readInt());
				cancion.setArtista(rAF.readInt());

				for (int i = 0; i < 50; i++) {
					cancion.setTitulo(cancion.getTitulo() + rAF.readChar());
				}
				cancion.setTitulo(cancion.getTitulo().trim());
				cancion.setDuracion(rAF.readInt());

				resultado.add(cancion);
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

	public Canciones obtenerCancion(int cancionBuscada) {
		Canciones resultado = null;

		String titulo = "";

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "r");

			while (true) {
				int codigo = rAF.readInt();

				if (codigo == cancionBuscada) {
					resultado = new Canciones();

					resultado.setCodigo(codigo);
					resultado.setArtista(rAF.readInt());

					for (int i = 0; i < 50; i++) {
						resultado.setTitulo(titulo += rAF.readChar());
					}

					resultado.setDuracion(rAF.readInt());

					return resultado;

				} else {
					rAF.seek(rAF.getFilePointer() + 104);
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

	public boolean modificarCancion(Canciones c) {
		boolean resultado = false;

		RandomAccessFile rAF = null;

		try {
			rAF = new RandomAccessFile(FBIN, "rw");

			while (true) {

				int codigo = rAF.readInt();

				if (codigo == c.getCodigo()) {
					rAF.seek(rAF.getFilePointer() + 104);

					rAF.writeInt(c.getDuracion());

					return true;

				} else {
					rAF.seek(rAF.getFilePointer() + 108);
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

}
