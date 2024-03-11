package MisClases;


/* 

Para procesar el cuerpo de un HttpResponse y filtrar las etiquetas HTML 
que cumplen con ciertas características, puedes utilizar una biblioteca 
de análisis HTML como JSoup. 
JSoup facilita la manipulación y búsqueda de elementos HTML en Java.

Primero, debes asegurarte de incluir la biblioteca JSoup en tu proyecto. 
Puedes descargarla desde el sitio web oficial de JSoup (https://jsoup.org/) 
o utilizar una herramienta de gestión de dependencias como Maven o Gradle.
 */

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.Scanner;

public class Ejemplo6 {
	
	void ejecutar() {
	
        // Crear una instancia de HttpClient
        HttpClient httpClient = HttpClient.newHttpClient();

        // Crear una instancia de HttpRequest con la URL de destino
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(URI.create("https://bolsarama.es/acciones/ibex35"))
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
            Elements elementosDefiniciones = document.select("table tbody tr");

            // Iterar sobre los elementos seleccionados
            for (Element elemento : elementosDefiniciones) {
                
            	Elements cabecera=elemento.select("th:nth-child(1)");
                for (Element elemento2 : cabecera) {
                	System.out.print(elemento2.text()+":");
                }        	

                Elements cotizacion=elemento.select("td:nth-child(2)");
                for (Element elemento3 : cotizacion) {
                	System.out.println(elemento3.text());
                }        	
//            	System.out.println(elemento.text());
            }
        } catch (Exception e) {
            // Manejar excepciones
            e.printStackTrace();
        }		
	}
}
