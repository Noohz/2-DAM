package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.ArrayList;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;



public class GestorConexion implements Runnable{
	
	ArrayList<String> lista;
	Socket socketCliente;
	OutputStream os;
    BufferedReader lectorDatos;

    ArrayList<String> listaPalabras;
    
    
    final String[] palabras={"carroza","puerta","musculo","tibia","nariz","pierna"};
  
    
    
    String palabraJuego;
    char[] estadoActual;
    int numFallos;
    int letrasRestantes;
    
	GestorConexion(Socket cliente, ArrayList<String> lista) throws IOException {
		
		this.lista=lista;
		
		// Guardamos en un atributo el socket del cliente con el que tenemos establecida la conexión
		socketCliente=cliente;
		
		// Para el socket del cliente capturamos su outputStream e inputStream
		os=socketCliente.getOutputStream(); // Flujo para enviar datos al socket
		InputStream is=socketCliente.getInputStream();  // Permite recibir datos desde el socket
		
		// Si uso un InputStreamReader puedo trabajar con el Stream como si fuera de caracteres en 
		// lugar de bytes, ya que decodifica los bytes usando un juego de caracteres específico
        InputStreamReader inputStreamReader = new InputStreamReader(is); 
        
        // BufferedReader es una clase que proporciona un búfer para mejorar la eficiencia de la lectura de caracteres desde un Reader
        // permitiendo tener que hacer menos accesos al Stream, ya que el buffer se va llenando automáticamente cuando usamos métodos como read o readline
        lectorDatos = new BufferedReader(inputStreamReader);
 	}
	
	

	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		
		String linea;
		// Esperamos a recibir datos desde el cliente
		try {
			
			boolean salir=false;
			System.out.println("Estoy en el run del thread");
			while(salir==false) {
				
				// Al hacer un readLine() de BufferedReader se queda esperando hasta que el buffer reciba datos suficientes
				while((linea=lectorDatos.readLine())!=null)	{
					System.out.println("Dato llegado al servidor : " + linea);

					// Obtengo las distintas partes que componen la cadena
					String[] partes=linea.split("\t");
					
					
					// Procesamos los distintos tipos de mensajes que le llegan al servidor
					if(partes[0].equalsIgnoreCase("Linea")) {
						int numLinea=Integer.parseInt(partes[1]);
						if(numLinea==-1)
							numLinea=Aplicacion.numAleatorio.nextInt(lista.size());
						
						if(numLinea>=lista.size()) {
							// La línea pedida excede el tamaño de la lista
							os.write(("Error\t"+numLinea+"\n").getBytes());
						} else {
							os.write(("Resultado\t"+numLinea+"\t"+lista.get(numLinea)+"\n").getBytes());
						}
					}
					if(partes[0].equalsIgnoreCase("Lineas")) {
						int numLineaInicial=Integer.parseInt(partes[1]);
						int numLineas=Integer.parseInt(partes[2]);
						
						if(numLineaInicial>=0 && numLineaInicial<lista.size() && 
						   numLineaInicial+numLineas < lista.size() )
						{
							for(int i=numLineaInicial;i<numLineaInicial+numLineas;i++) {
								os.write(("Resultado\t"+i+"\t"+lista.get(i)+"\n").getBytes());
							}
							os.write(("FinalEnvio\n").getBytes());
						}
						else {
							// El rango elegido por el usuairo no es correcto
							os.write(("Error\t"+numLineaInicial+"\n").getBytes());
						}
					}
					if(partes[0].equalsIgnoreCase("NumVecesPalabra")) {
						String palabraBuscada=partes[1];
						
						int numVeces=0;
						for(String lineaLista: lista) {
							String[] palabras=lineaLista.split("[ :.,;]");
							for(String palabra:palabras) {
								if(palabra.equalsIgnoreCase(palabraBuscada))
									numVeces++;
							}
						}
						
						os.write(("ResultadoNum\t"+palabraBuscada+"\t"+numVeces+"\n").getBytes());
					}
					if(partes[0].equalsIgnoreCase("Final")) {
						// El usuario se ha ido
						salir=true;
					}
					
					
				}
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		finally {
			// Cerramos los streams y el socket del cliente
			try {
				/* Cuando se cierra un BufferedReader que ha sido creado a partir de un InputStreamReader, y ese InputStreamReader a su  
				 vez ha sido creado a partir de un InputStream, no se necesita cerrar explícitamente el InputStreamReader o el 
				 InputStream. Cuando cierras un BufferedReader, automáticamente cierra también el Reader subyacente (InputStreamReader en este caso), 
				 y el Reader a su vez cierra el InputStream subyacente.*/
				lectorDatos.close();
				os.close();
				socketCliente.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
