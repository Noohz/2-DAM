package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class Ejemplo1 {
	
	void ejecutar() {
  	  	URL url;
  	  	try {
  	  		// Indicamos la URL a la que queremos conectarnos
//  	  		url = new URL("https://www.marca.com");
  	  		url = new URL("https://dle.rae.es/edificio");
	  		
  	  		
  	  		HttpURLConnection con;
			try {
				// Abrimos una conexión con el servidor
				con = (HttpURLConnection)url.openConnection();
//				con.setRequestMethod("GET");
//				con.setRequestProperty("charset", "utf-8");
				con.setRequestProperty("User-Agent", "Mozilla/5.0");		

				// Hacemos la petición y analizamos el código de la respuesta
				int respuesta=con.getResponseCode();
				if(respuesta==HttpURLConnection.HTTP_OK) {
					// Capturamos el stream con el contenido de lo que devuelve
	  	  			BufferedReader in = new BufferedReader(
	  	  				new InputStreamReader(con.getInputStream()));
		 
	  	  			// Mostramos por consola el contenido recibido
	  	  			String linea;
	  	  			while ((linea = in.readLine()) != null) {
	  	  				System.out.println(linea);
	  	  			}
				}
				else System.out.println(respuesta);
				
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
  	  	}
  	  	catch (MalformedURLException e) {
  	  		// TODO Auto-generated catch block
  	  		e.printStackTrace();
  	  	}
	}
 }
