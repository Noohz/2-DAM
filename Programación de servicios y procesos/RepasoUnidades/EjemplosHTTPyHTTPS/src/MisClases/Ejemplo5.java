package MisClases;

import java.net.HttpURLConnection;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
/*
 * Para convertir de un String a Json se pueden usar diferentes librerías como:
 * Gson,Jackson o JSON-Java usada en el ejemplo del tema 1 
 * 
 */

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;

/* Por ejemplo con Gson
 * Descargar la librería de https://search.maven.org/artifact/com.google.code.gson/gson/2.10.1/jar?eh=
 * Añadir el .jar a las librerías del proyecto
 */

// Otro ejemplo de API REST está en https://jsonplaceholder.typicode.com/users

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;

public class Ejemplo5 {
	
	
	void ejecutar() {
		
		System.out.print("Escribe el nombre del país (en inglés) : ");
		String pais=Aplicacion.teclado.next();
		mostrarDatos(pais);
	}
	
	void mostrarDatos(String pais) {

		// Creamos una instancia de HttpClient
        HttpClient httpClient = HttpClient.newHttpClient();

        // Creamos una instancia de HttpRequest con la URL y los datos del destino
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(URI.create("https://restcountries.com/v3.1/name/" + pais))
                .build();
        
        
		try {
	        // Enviar la solicitud y obtener la respuesta
			HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());
			
            // Imprimir el código de estado
            int statusCode = httpResponse.statusCode();
        	System.out.println("Código de Estado: " + statusCode);
            
            if (statusCode == HttpURLConnection.HTTP_OK) {
            	// Si la respuesta del servidor es correcta
            	
            	// Como sé que el contenido del texto representa un array de documentos JSON lo convierto.
                JsonArray jsonArray = JsonParser.parseString(httpResponse.body()).getAsJsonArray();
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
            else if (statusCode == HttpURLConnection.HTTP_NOT_FOUND) {
            	System.out.println("No existe ninguna entrada con ese contenido");
            }
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
