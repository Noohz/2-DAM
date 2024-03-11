package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Aplicacion {
	
	
	public static void mandarMensaje(BufferedReader lector,OutputStream escritor, String mensaje, boolean esperaRespuesta) {
		
		// Mandamos el mensaje al servidor
		try {
			escritor.write(mensaje.getBytes());
			if(esperaRespuesta==true) {
				// Espero la respuesta del servidor
				String respuesta;
				while((respuesta=lector.readLine())!=null) {
					System.out.println(respuesta);
					break;
				}
			}
	
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String servidor="localhost";
		int puerto=20000;

		Socket socketCliente=null;
		OutputStream escritor=null;
		BufferedReader lector=null;
		
		Scanner teclado=new Scanner(System.in);
		
		try {
			// Abrimos una conexión con el Servidor
			socketCliente=new Socket(servidor,puerto);
			InputStream is = socketCliente.getInputStream();
			escritor=socketCliente.getOutputStream();			
			InputStreamReader isReader=new InputStreamReader(is);
			lector=new BufferedReader(isReader);
			
			boolean salir=false;
			while(salir==false) {
				// Mostramos el menú de opciones por pantalla
				System.out.println("1 - Hora\n2 - Fecha\n3 - Salir\n");
			
				int valor=teclado.nextInt();
				if(valor==1) {
					mandarMensaje(lector,escritor, "Hora\n", true); 
				}
				if(valor==2) {
					mandarMensaje(lector,escritor, "Fecha\n", true); 
				}
				if(valor==3) {
					mandarMensaje(lector,escritor, "Fin\n", false);
					salir=true;
				}
			}
			
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			// Cerramos los streams y los sockets
			try {
				if(lector!=null)
					lector.close();
				if(escritor!=null)
					escritor.close();
				if(socketCliente!=null)
					socketCliente.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		
	}

}
