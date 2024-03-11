package MisClases;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

/*
 * Para convertir de un String a Json se pueden usar diferentes librerías como:
 * Gson,Jackson o JSON-Java usada en el ejemplo del tema 1 
 * 
 */

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
/* Por ejemplo con Gson
 * Descargar la librería de https://search.maven.org/artifact/com.google.code.gson/gson/2.10.1/jar?eh=
 * Añadir el .jar a las librerías del proyecto
 */

// Otro ejemplo de API REST está en https://jsonplaceholder.typicode.com/users



public class Ejemplo4 {
	
	
	void ejecutar() {
		
		System.out.print("Escribe el nombre del país (en inglés) : ");
		String pais=Aplicacion.teclado.next();
		mostrarDatos(pais);
	}
	
	void mostrarDatos(String pais) {

		
  	  	URL url;
 	  	try {
  	  		// Indicamos la URL a la que queremos conectarnos
  	  		url = new URL("https://restcountries.com/v3.1/name/" + pais);		

  	  		HttpURLConnection con;
			try {
				// Abrimos una conexión con el servidor
				con = (HttpURLConnection)url.openConnection();
				if(con.getResponseCode()==HttpURLConnection.HTTP_OK) {
					// Capturamos el stream con el contenido de lo que devuelve
	  	  			BufferedReader in = new BufferedReader(
	  	  				new InputStreamReader(con.getInputStream()));

	  	  			StringBuilder respuesta = new StringBuilder();
	  	  			// Vamos añadiendo todas las líneas de la salida en un StringBuilder
	  	  			// La principal diferencia entre StringBuilder y String es que StringBuilder puede cambiar sin necesidad de crear objetos nuevos
	  	  			String linea;
	  	  			while ((linea = in.readLine()) != null) {
	  	  				respuesta.append(linea);
	  	  			}
	  	  			
	            	// Como sé que el contenido del texto representa un array de documentos JSON lo convierto.
	                JsonArray jsonArray = JsonParser.parseString(respuesta.toString()).getAsJsonArray();
	                /*
	                 * Si fuera un documento Json sería:
	                 * JsonObject jsonObject = JsonParser.parseString(jsonString).getAsJsonObject();
	                 */
	                // Por cada documento Json, muestro los siguientes datos
	                for(JsonElement jsonElement : jsonArray) {
	                	System.out.println("------------------------");
	                	System.out.println("JsonObject: " + jsonElement);
	                	JsonObject jsonObject=jsonElement.getAsJsonObject();
	                	System.out.println("Población: " + jsonObject.get("population").getAsInt());
	                	System.out.println("Capital: " + jsonObject.get("capital").getAsString());
	                	System.out.println("Fronteras: " + jsonObject.get("borders").getAsJsonArray());
	                	System.out.println("------------------------");
	                }
				}
				else if (con.getResponseCode() == HttpURLConnection.HTTP_NOT_FOUND) {
	            	System.out.println("No existe ninguna entrada con ese contenido");
				} 
			}catch (IOException e) {
				e.printStackTrace();				
			}
		} catch (MalformedURLException e) {
			e.printStackTrace();
		}
	}
}
