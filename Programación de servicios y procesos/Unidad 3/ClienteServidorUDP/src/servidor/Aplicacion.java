package servidor;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Aplicacion {

	
	public static void responderDatagramaCliente(DatagramSocket socketServidorUDP, DatagramPacket datagramaRecibido) {
	
		// Guardamos el mensaje que viene en el datagrama
		String mensajeRecibido=new String(datagramaRecibido.getData(),0,datagramaRecibido.getLength());
		
		// Recuperamos la direcci�n del cliente que env�a el datagrama
		InetAddress direccionCliente=datagramaRecibido.getAddress();
		
		// Recuperamos el puerto del cliente que env�a el datagrama
		int puertoCliente=datagramaRecibido.getPort();
		
		byte[] arBytes=null;
		
		if(mensajeRecibido.equalsIgnoreCase("Hora")) {
			// Le mando la hora del servidor
			DateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");
			Date date = new Date();
			String respuesta=dateFormat.format(date);
			arBytes=respuesta.getBytes();
		}
	
		if(mensajeRecibido.equalsIgnoreCase("Fecha")) {
			// Le mando la fecha del servidor
			 DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
			 Date date = new Date();
			 String respuesta=dateFormat.format(date);
 			 arBytes=respuesta.getBytes();
		}

		if(arBytes!=null) {
			// Enviamos el datagrama
			DatagramPacket datagramaRespuesta=new DatagramPacket(arBytes,arBytes.length,direccionCliente,puertoCliente);
			try {
				socketServidorUDP.send(datagramaRespuesta);
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	
	public static void main(String[] args) {
		
		
		// Servidor UDP

		// Si quiero responder en el propio Thread o e un Thread independiente		
		int tipoRespuesta=1;        
		// Puerto en el que escuchar� el servidor
		int puertoEscucha=20000;
		
		DatagramSocket socketServidorUDP=null;
		
		try {
			socketServidorUDP=new DatagramSocket(puertoEscucha);
			System.out.println("El servidor est� escuchando en el puerto " + puertoEscucha);
			byte[] buffer=new byte[1024];
			DatagramPacket datagramaRecibido=new DatagramPacket(buffer, buffer.length);

			while(true) {
					try {
						socketServidorUDP.receive(datagramaRecibido);
						if(tipoRespuesta==1) {
							// Vamos a responder al cliente en el propio hilo principal
							responderDatagramaCliente(socketServidorUDP,datagramaRecibido);
						}
						
						else {
							// Vamos a responder al cliente creando un hilo independiente
							GestionRespuesta respuestaCliente=null;
							respuestaCliente=new GestionRespuesta(socketServidorUDP,datagramaRecibido);
							respuestaCliente.start();
						}
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			}
		} catch (SocketException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			if(socketServidorUDP!=null)
				socketServidorUDP.close();
		}
	}
}
