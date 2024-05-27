package MisClases;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Random;

public class Aplicacion {
	static Random numAleatorio=new Random();
	
	static ArrayList<String> lista = new ArrayList<String>(); 
	public static void main(String[] args) {
		
		int puertoEscucha = 12345;

		// Cargamos las líneas del libro en un ArrayList
		cargarLineasLibro();
		
		// Creamos el server Socket que estará escuchando a los distintos clientes que quieran jugar	
		try (ServerSocket servidor=new ServerSocket(puertoEscucha)) {
			
			// Nos metemos en un bucle en el que escuchamos las peticiones de conexión que hagan los clientes
			while(true) {
				System.out.println("El servidor está escuchando en el puerto 12345");
				Socket socketCliente=servidor.accept();
				
				// Si llego a este punto es porque se ha abierto una petición con un cliente
				System.out.println("Se ha establecido una conexión desde un cliente");
				// Para poder atender concurrentemente varias peticiones, le paso el socket del cliente a un thread para que lo trate
				Thread hilo=new Thread(new GestorConexion(socketCliente, lista));
				// Pongo en marcha el thread
				hilo.start();
			}
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	
	static void cargarLineasLibro() {

		try (BufferedReader fichero=new BufferedReader(new FileReader("alicia.txt"))) {
			
			String linea;
			while((linea=fichero.readLine())!=null)
				Aplicacion.lista.add(linea);
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
