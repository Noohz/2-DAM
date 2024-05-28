package MisClases;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Random;

public class Aplicacion {
	static Random numAleatorio=new Random();
	public static void main(String[] args) {
		
		int puertoEscucha = 23432;
		ServerSocket servidor=null;
		
		// Creamos el server Socket que estará escuchando a los distintos clientes que quieran jugar	
		try {
			servidor=new ServerSocket(puertoEscucha);
			
			// Nos metemos en un bucle en el que escuchamos las peticiones de conexión que hagan los clientes
			while(true) {
				System.out.println("El servidor está escuchando en el puerto 23432");
				Socket socketCliente=servidor.accept();
				
				// Si llego a este punto es porque se ha abierto una petición con un cliente
				System.out.println("Se ha establecido una conexión desde un cliente");
				// Para poder atender concurrentemente varias peticiones, le paso el socket del cliente a un thread para que lo trate
				Thread hilo=new Thread(new GestorConexion(socketCliente));
				// Pongo en marcha el thread
				hilo.start();
			}
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			
			// Si el servidor está abierto se cierra
			if(servidor!=null) {
				try {
					servidor.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}

	}

}
