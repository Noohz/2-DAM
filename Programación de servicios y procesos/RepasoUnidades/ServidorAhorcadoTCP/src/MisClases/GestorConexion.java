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
	
	Socket socketCliente;
	OutputStream os;
    BufferedReader lectorDatos;

    ArrayList<String> listaPalabras;
    
    
    final String[] palabras={"carroza","puerta","musculo","tibia","nariz","pierna"};
  
    
    
    String palabraJuego;
    char[] estadoActual;
    int numFallos;
    int letrasRestantes;
    
	GestorConexion(Socket cliente) throws IOException {
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
		
 //       listaPalabras=new ArrayList<String>();
 //       cargarPalabrasHtml();
        
        // Cargamos la palabra inicial del juego
        cargarPalabraInicial();
 	}
	
	
	void cargarPalabraInicial() throws IOException{
  
		// Selecciono aleatoriamente la palabra con la que va a jugar el cliente
		palabraJuego=palabras[Aplicacion.numAleatorio.nextInt(palabras.length)];

		/*        if(listaPalabras.size()>0)
        	palabraJuego=listaPalabras.get(Aplicacion.numAleatorio.nextInt(listaPalabras.size()));        
        else palabraJuego=palabras[Aplicacion.numAleatorio.nextInt(palabras.length)];
*/        
        // Ponemos el estadoActual de la palabra con todas las letras ocultas
        estadoActual=new char[palabraJuego.length()];
        
        for(int i=0;i<palabraJuego.length();i++)
        	estadoActual[i]='-';
        
        
        numFallos=0;
        letrasRestantes=palabraJuego.length();
        
        // Le envío al jugador el estado actual de la palabra
		os.write(("Inicio\t"+numFallos+"\t"+new String(estadoActual)+"\n").getBytes());
	}
	
    // Cargar Array de palabras del fichero html
    void cargarPalabrasHtml() {
        // Crear una instancia de HttpClient
        HttpClient httpClient = HttpClient.newHttpClient();

        // Crear una instancia de HttpRequest con la URL de destino
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(URI.create("http://fjgcpsp2024webexamen.s3-website-us-east-1.amazonaws.com"))
                .build();

        try {
            // Enviar la solicitud y obtener la respuesta
            HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());

            // Obtener el cuerpo de la respuesta
            String responseBody = httpResponse.body();
/*            System.out.println(responseBody); */
             
            // Parsear el cuerpo HTML utilizando JSoup
            Document document = Jsoup.parse(responseBody);

            // Seleccionar elementos con una clase específica
            Elements elementosDefiniciones = document.select("ul.listaPalabras li");

            // Iterar sobre los elementos seleccionados
            for (Element elemento : elementosDefiniciones) {
            	// Añado la palabra leida a la lista de Palabras
            	listaPalabras.add(elemento.ownText());
            }
        } catch (Exception e) {
            // Manejar excepciones
            e.printStackTrace();
        }		
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
					
					if(partes[0].equals("Otra"))
					{
						cargarPalabraInicial();
					}
						
					if(partes[0].equals("Letra"))
					{
						// Chequeo la letra indicada en la palabra
						if(partes[1].length()==1) {
							char letraUsuario=partes[1].charAt(0);
							int numAciertos=0;	
							// Ponemos el estadoActual de la palabra con todas las letras ocultas
					        for(int i=0;i<palabraJuego.length();i++) {
					        	if(palabraJuego.charAt(i)==letraUsuario && estadoActual[i]=='-') {
					        		numAciertos++;
					        		letrasRestantes--;
					        		estadoActual[i]=letraUsuario;
					        	}
					        }
					        
					        if(numAciertos>0) {
					        	// Si el usuario ha acertado alguna

					        	if(letrasRestantes==0) {
					        		// Acertó todas las que faltaban y por lo tanto ganó la partida
						    		os.write(("Triunfo\t"+numFallos+"\t"+palabraJuego+"\n").getBytes());
					        	}
					        	else {
					        		// Sólo acertó parte de las que faltaban
					        		os.write(("Aciertos\t"+numAciertos+"\t"+numFallos+"\t"+new String(estadoActual)+"\n").getBytes());
					        	}
					        }
					        else {
					        	// Si el usuario no ha acertado ninguna
					        	numFallos++;
					        	if(numFallos<7) { 
					        		os.write(("Fallos\t"+numFallos+"\t"+new String(estadoActual)+"\n").getBytes());
					        	}
					        	else os.write(("Derrota\t"+"\t"+numFallos+"\t"+palabraJuego+"\n").getBytes());
					        }
						}
					}
					else if(partes[0].equals("Palabra")) {
						// Compruebo si la palabra que me ha mandado el jugador es la palabra a adivinar
						if(partes[1].equalsIgnoreCase(this.palabraJuego)) {
							// El usuario ha acertado y ha ganado la partida
				    		os.write(("Triunfo\t"+numFallos+"\t"+palabraJuego+"\n").getBytes());
						} 
						else {
				        	numFallos++;
				        	if(numFallos<7) { 
				        		os.write(("Fallos\t"+numFallos+"\t"+new String(estadoActual)+"\n").getBytes());
				        	}
				        	else os.write(("Derrota\t"+numFallos+"\t"+palabraJuego+"\n").getBytes());
						}
					}

					else if(partes[0].equals("Final")) {
						// La partida ha concluido
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
