package servidor;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class GestionRespuesta extends Thread{
	
	DatagramSocket socketServidorUDP;
	DatagramPacket datagramaRecibido;
	

	GestionRespuesta(DatagramSocket socketServidorUDP, DatagramPacket datagramaRecibido) {
		this.socketServidorUDP=socketServidorUDP;
		this.datagramaRecibido=datagramaRecibido;
	}

	@Override
	public void run(){

		// Guardamos el mensaje que viene en el datagrama
		String mensajeRecibido=new String(datagramaRecibido.getData(),0,datagramaRecibido.getLength());
		
		// Recuperamos la direcci�n del cliente que env�a el datagrama
		InetAddress direccionCliente=datagramaRecibido.getAddress();
		
		// Recuperamos el puerto del cliente que env�a el datagrama
		int puertoCliente=datagramaRecibido.getPort();
		
		byte[] arBytes=null;
		
		if(mensajeRecibido.equals("Hora")) {
			// Le mando la hora del servidor
			DateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");
			Date date = new Date();
			String respuesta=dateFormat.format(date);
			arBytes=respuesta.getBytes();
		}
		
		if(mensajeRecibido.equals("Fecha")) {
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
}
