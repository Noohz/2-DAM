package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class GestionConexion extends Thread{
	
	Socket socketCliente;
	BufferedReader lector;
	OutputStream escritor;
	
	
	GestionConexion(Socket socket) {
		socketCliente=socket;
		try {
			InputStream is = socket.getInputStream();
			InputStreamReader isReader=new InputStreamReader(is);
			lector=new BufferedReader(isReader);
			escritor=socket.getOutputStream();

		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public void run(){
		
		boolean salir=false;
		while (salir==false) {
			String mensaje;
			try {
				while((mensaje=lector.readLine())!=null) {
					if(mensaje.equals("Hora")) {
						// Le mando la hora del servidor
						 DateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");
						 Date date = new Date();
						 escritor.write((dateFormat.format(date)+"\n").getBytes());
					}
					if(mensaje.equals("Fecha")) {
						// Le mando la fecha del servidor
						 DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
						 Date date = new Date();
						 escritor.write((dateFormat.format(date)+"\n").getBytes());
					}
					if(mensaje.equals("Fin")) {
						salir=true;
					}

				}
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
	
}
