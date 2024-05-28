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
	        	// Esperamos a poder leer la respuesta del servidor   
	        	String linea=leerRespuestaServidor(lectorDatos);
	        	// Tratamos la respuesta del servidor
	        	if(linea!=null)
	        		tratarMensajeServidor(os,lectorDatos,linea);
	        	return linea;
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
		
		if(partes[0].equals("Inicio")) {
			// El servidor nos está mandando la palabra inicial.
			// Pos 1 : Num Fallos	Pos 2 : estadoPalabra
			System.out.println("El número de fallos que llevas es : " + partes[1]);
			System.out.println("La palabra a adivinar es :" + partes[2]);
		}
		else if(partes[0].equals("Aciertos")) {
			// Pos 1 : Num Aciertos		Pos 2 : Num Fallos		Pos 3 : estadoPalabra
			System.out.println("Has adivinado :" + partes[1]);			
			System.out.println("El número de fallos que llevas es :" + partes[2]);
			System.out.println("El estado actual de la palabra es :" + partes[3]);			
		}
		else if(partes[0].equals("Fallos")) {
			// Pos 1 : Num Fallos		Pos 2 : estadoPalabra
			System.out.println("Has fallado una vez más");			
			System.out.println("El número de fallos que llevas es :" + partes[1]);
			System.out.println("El estado actual de la palabra es :" + partes[2]);			
		}
		else if(partes[0].equals("Triunfo")) {
			// Pos 1 : Num Fallos		Pos 2 : PalabraJuego
			System.out.println("Enhorabuena has ganado la partida");			
			System.out.println("El número de fallos total fue:" + partes[1]);
			System.out.println("La palabra con la que se jugó era :" + partes[2]);
		}
		else if(partes[0].equals("Derrota")) {
			// Pos 1 : Num Fallos		Pos 2 : PalabraJuego
			System.out.println("¡Lastima!. Perdiste la partida");			
			System.out.println("El número de fallos total fue:" + partes[1]);
			System.out.println("La palabra con la que se jugó era :" + partes[2]);
		}

		if(partes[0].equals("Triunfo") || partes[0].equals("Derrota")) {
			System.out.println("¿Quieres volver a jugar?. Escribe s si quieres u otra cosa si no: ");
			String respuesta=Aplicacion.teclado.nextLine();
			if(respuesta.equalsIgnoreCase("s")) {
				// Le mandamos al servidor el mensaje de que queremos jugar otra partida
				mandarMensajeServidor(os,lectorDatos,"Otra\n",true);
			}
			else deboFinalizar=true;  // Para que termine la partida			
		}
	}
	
// ***************************************************************	
// ***************************************************************	
		
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		String servidor="localhost";
		int puertoServidor=23432;
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
			
	        
	        // Leemos la palabra que nos manda el servidor inicialmente
        	String linea=leerRespuestaServidor(lectorDatos);
        	if(linea!=null)
        		tratarMensajeServidor(os,lectorDatos,linea);
        	

        	deboFinalizar=false;
			while(deboFinalizar==false)
			{
				// Le muestro al usuario el menú
				System.out.println("1 - Indicar nueva letra \n2 - Intentar resolver \n3 - Salir");
				int opcion=teclado.nextInt();
				teclado.nextLine();
				
				if(opcion==1) {
					// Le pido al usuario que elija la letra
					System.out.println("Elige la nueva letra :");
					String texto=teclado.nextLine();
					// Me quedo sólo con la primera letra y se lo envío al servidor
					if(texto.length()>0) {
						// Pido la hora al servidor a través del socket
						mandarMensajeServidor(os,lectorDatos,"Letra\t"+texto.charAt(0)+"\n",true);
					}
				}
				else if(opcion==2) {
					// Le pido al usuario que escriba la palabra que cree que es :
					System.out.println("Escribe la palabra que crees que es : ");
					String texto=teclado.nextLine();
					if(texto.length()>0) {
						// Pido la hora al servidor a través del socket
						mandarMensajeServidor(os,lectorDatos,"Palabra\t"+texto+"\n",true);
					}
				}
				else { 
//					mandarMensajeServidor(os,lectorDatos,"Salir",false);
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
