package cliente;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.Scanner;

public class Aplicacion {
	
	
	public static void mandarMensaje(DatagramSocket socketClienteUDP, String servidor, int puerto, String mensaje, boolean esperaRespuesta) {
	
		DatagramPacket datagramaEnviar=null;
		
		byte[] arBytes=mensaje.getBytes();
		
		try {
			InetAddress dirServidor = InetAddress.getByName(servidor);
			datagramaEnviar=new DatagramPacket(arBytes,arBytes.length,dirServidor,puerto);
			try {
				System.out.println("El cliente env�a un mensaje al servidor : " + mensaje);
				socketClienteUDP.send(datagramaEnviar);
				if(esperaRespuesta==true) {
					// Espero la respuesta del servidor
					byte[] buffer=new byte[1024];
					DatagramPacket datagramaRespuesta=new DatagramPacket(buffer,buffer.length);
					socketClienteUDP.receive(datagramaRespuesta);
					String respuesta=new String(datagramaRespuesta.getData(),0,datagramaRespuesta.getLength());
					System.out.println(respuesta);
				}

			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String servidor="localhost";
		int puerto=20000;

		DatagramSocket socketClienteUDP=null;
		Scanner teclado=new Scanner(System.in);
		try {

			socketClienteUDP=new DatagramSocket();
			
			boolean salir=false;
			while(salir==false) {
				// Mostramos el men� de opciones por pantalla
				System.out.println("1 - Hora\n2 - Fecha\n3 - Salir\n");
			
				int valor=teclado.nextInt();
				if(valor==1) {
					mandarMensaje(socketClienteUDP,servidor, puerto, "Hora", true); 
				}
				if(valor==2) {
					mandarMensaje(socketClienteUDP,servidor, puerto, "Fecha", true); 
				}
				if(valor==3) {
					salir=true;
				}
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			// Cerramos los streams y los sockets
			if(socketClienteUDP!=null)
				socketClienteUDP.close();
		}
		
	}

}
