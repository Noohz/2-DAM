package servidor;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Aplicacion {

	public static void main(String[] args) {
		// Servidor TCP
		
		int puertoEscucha=20000;
		ServerSocket servidor=null;
		
		// Creamos el objeto de la clase ServerSocket
		try {
			servidor=new ServerSocket(puertoEscucha);
			System.out.println("El servidor est� escuchando");
			while(true) {
				Socket socketCliente=null;
				socketCliente=servidor.accept();
				System.out.println("Se ha establecido una conexi�n con un cliente");
				// Se ha estalecido una conexi�n con un cliente
				GestionConexion conexionCliente=null;
				conexionCliente=new GestionConexion(socketCliente);
				conexionCliente.start();
			}
			
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			if(servidor!=null)
				try {
					servidor.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
		}
	}

}
