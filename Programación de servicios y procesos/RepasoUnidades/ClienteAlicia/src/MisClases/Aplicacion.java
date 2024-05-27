package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.UnknownHostException;
import java.time.LocalTime;
import java.util.Scanner;

public class Aplicacion {
	
	public static boolean deboFinalizar=false;
	static Scanner teclado=new Scanner(System.in);

	public static String mandarMensajeServidor(OutputStream os,BufferedReader lectorDatos,String mensaje,boolean esperarRespuesta) {
		// Capturamos los flujos de salida y entrada del socket
		
		try {
//	        System.out.println("Le paso al servidor el mensaje");
	        // Le pedimos al servidor que haga la acción que le indiquemos
	        os.write((mensaje+"\n").getBytes());
	        
	        if(esperarRespuesta==true) {
	        	
	        	if(mensaje.startsWith("Lineas")) {
	        		boolean salir=false;
	        		while(salir==false) {
		        		// Esperamos a poder leer la respuesta del servidor   
		        		String linea=leerRespuestaServidor(lectorDatos);
		        		// Tratamos la respuesta del servidor
		        		if(linea!=null)
		        			tratarMensajeServidor(os,lectorDatos,linea);
		        		
		        		if(linea.startsWith("FinalEnvio"))
		        			salir=true;
	        		}
	        	}
	        	else {
	        		// Esperamos a poder leer la respuesta del servidor   
	        		String linea=leerRespuestaServidor(lectorDatos);
	        		// Tratamos la respuesta del servidor
	        		if(linea!=null)
	        			tratarMensajeServidor(os,lectorDatos,linea);
	        		return linea;
	        	}
	        }
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} 
		return null;
	}	
	
	// ***************************************************************	
	// ***************************************************************	
		
	public static String leerRespuestaServidor(BufferedReader lectorDatos) {
    	String linea=null;
    	try {
			while((linea=lectorDatos.readLine())!=null) {
//				System.out.println(linea);
				break; // Nos salimos del bucle while para que no se quede esperando por otra línea
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    	return linea;
	}
	
// ***************************************************************	
// ***************************************************************	
	
	static void tratarMensajeServidor(OutputStream os,BufferedReader lectorDatos, String linea) {

		String[] partes=linea.split("\t");
		
		if(partes[0].equals("Resultado")) {
			System.out.println(partes[1] + " - " + partes[2]);
		}
		else if(partes[0].equals("Error")) {
			System.out.println("Error con número de línea : " + partes[1]);			
		}
		else if(partes[0].equals("ResultadoNum")) {
			System.out.println("El número de veces que aparece la palabra " + partes[1] + " es : " + partes[2]);			
		}
	}
	
// ***************************************************************	
// ***************************************************************	
		
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		String servidor="localhost";
		int puertoServidor=12345;
		Socket socket=null;
		OutputStream os=null;
		BufferedReader lectorDatos=null;
		InputStream is = null;
		
		// Establecemos una conexión con el servidor
		try {
			socket=new Socket(servidor, puertoServidor);

			os=socket.getOutputStream();
			is=socket.getInputStream();  // Permite recibir datos desde el socket
	        InputStreamReader inputStreamReader = new InputStreamReader(is);
	        lectorDatos = new BufferedReader(inputStreamReader);	
			

        	deboFinalizar=false;
			while(deboFinalizar==false)
			{
				// Le muestro al usuario el menú
				System.out.println("********************************");
				System.out.println("1-Solicitar línea fichero (-1 aleatoria)");
				System.out.println("2-Solicitar líneas fichero");
				System.out.println("3-Obtener número de veces que aparece la palabra");
				System.out.println("4-Salir");
				System.out.println("********************************");
				
				int opcion=teclado.nextInt();
				teclado.nextLine();
				
				if(opcion==1) {
					System.out.print("Elige el número de línea (-1 si aleatorio) :");
					int numLinea=teclado.nextInt();
					teclado.nextLine();
					mandarMensajeServidor(os,lectorDatos,"Linea\t"+numLinea+"\n",true);
				}
				else if(opcion==2) {
					System.out.print("Elige el número de línea inicial :");
					int numLineaInicial=teclado.nextInt();
					teclado.nextLine();
					System.out.print("Indica el número de líneas que quieres :");
					int numLineas=teclado.nextInt();
					teclado.nextLine();

					mandarMensajeServidor(os,lectorDatos,"Lineas\t"+numLineaInicial+"\t"+numLineas+"\n",true);
				}
				else if(opcion==3) { 
					System.out.print("Escribe la palabra :");
					String palabra=teclado.nextLine();
					mandarMensajeServidor(os,lectorDatos,"NumVecesPalabra\t"+palabra+"\n",true);
				}
				else {
					deboFinalizar=true;
				}
			}	
			
			// Le mandamos al servidor un mensaje para finalizar la conexión
			mandarMensajeServidor(os,lectorDatos,"Final\n",false);			
			
		} catch (UnknownHostException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			
			if(os!=null)
				try {
					os.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			
			if(lectorDatos!=null)
				try {
					lectorDatos.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
		
			if(socket!=null)
				try {
					socket.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			
			if(teclado!=null)
				teclado.close();
		}
				
	}

}
