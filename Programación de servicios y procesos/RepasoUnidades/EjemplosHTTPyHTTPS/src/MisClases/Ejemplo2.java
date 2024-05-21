package MisClases;

import java.net.HttpURLConnection;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.net.http.HttpHeaders;


public class Ejemplo2 {

		
	void ejecutar() {

		// Creamos una instancia de HttpClient
        HttpClient httpClient = HttpClient.newHttpClient();

        // Creamos una instancia de HttpRequest con la URL de destino
        HttpRequest httpRequest = HttpRequest.newBuilder()
              .uri(URI.create("https://www.marca.com"))
              .build();

        try {
            // Enviar la solicitud y obtener la respuesta
            HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());
        	
        	/*La sintaxis <String> entre los corchetes angulares (<>) se refiere a los 
        	  par�metros de tipo gen�rico. En Java, los gen�ricos permiten que las clases
        	  y m�todos operen con tipos de datos de manera m�s general, 
        	  proporcionando flexibilidad y reutilizaci�n del c�digo. 
        	  El tipo que especificas entre los corchetes angulares es 
        	  conocido como "argumento de tipo" o "par�metro de tipo"
        	 
        	  Por ejemplo, si sabemos que el contenido de la respuesta es un String:
        	  HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());
        	  String responseBody = httpResponse.body();
        	
			  El tipo de datos que puedes obtener de un HttpResponse 
			  depende de la implementaci�n de BodyHandler que utilices al 
			  recibir la respuesta. Algunos de los tipos de datos comunes 
			  que puedes obtener son: 
			  	String, ByteArray, InputStream y File     	
        	 
        	 */
        	/*
        	 
				En el m�todo send de la clase HttpClient, el segundo par�metro 
				es un objeto de tipo HttpResponse.BodyHandler. 
				Este par�metro es responsable de procesar el cuerpo de la 
				respuesta HTTP despu�s de realizar la solicitud. 
				El m�todo send realiza una solicitud HTTP y espera una 
				respuesta del servidor. El cuerpo de la respuesta se 
				procesa utilizando el HttpResponse.BodyHandler que 
				proporcionas.Existen varias implementaciones predefinidas de BodyHandler 
				en la clase HttpResponse.BodyHandlers. Algunas de las opciones comunes son:
        	  	BodyHandlers.ofString() --> Devuelve un BodyHandler que procesa el cuerpo de
        	  	 la respuesta como una cadena de caracteres (String).
        	  	BodyHandlers.ofByteArray():
				BodyHandlers.ofInputStream():
				BodyHandlers.ofFile(Path file):
        	 */

            // Imprimir el c�digo de estado
            int statusCode = httpResponse.statusCode();
        	System.out.println("C�digo de Estado: " + statusCode);
            
            if (statusCode == 200) {//
//            if (statusCode == HttpURLConnection.HTTP_OK) {
            	// Imprimir las cabeceras de la respuesta
            	HttpHeaders headers = httpResponse.headers();
            	headers.map().forEach((k, v) -> System.out.println(k + ": " + v));
            	/* El m�todo map() de la interfaz HttpHeaders en Java retorna un 
            	 * Map<String, List<String>> que representa las cabeceras HTTP 
            	 * de la respuesta. 
            	 * Este m�todo proporciona un mapeo de los nombres de las cabeceras a las 
            	 * listas de valores asociados con esos nombres.
            	 * 
            	 * El m�todo forEach se utiliza para iterar sobre el mapa
            	 * de cabeceras (Map<String, List<String>>) devuelto por 
            	 * headers.map().
            	 * En este caso, se proporciona una expresi�n lambda
            	 * (k, v) -> System.out.println(k + ": " + v) como BiConsumer.
            	 * k: Es la clave, que representa el nombre de una cabecera.
				   v: Es el valor asociado a esa clave, que es una lista de cadenas que representa los valores de la cabecera.
            	 */
            	
            	// Imprimir el cuerpo de la respuesta
            	String responseBody = httpResponse.body();
//            	System.out.println("Cuerpo de la Respuesta:\n" + responseBody);
            }
        } catch (Exception e) {
            // Manejar excepciones
            e.printStackTrace();
        }
	}
}
