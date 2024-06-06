package MisClases;


import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

/* 

Para procesar el cuerpo de un HttpResponse y filtrar las etiquetas HTML 
que cumplen con ciertas caracter�sticas, puedes utilizar una biblioteca 
de an�lisis HTML como JSoup. 
JSoup facilita la manipulaci�n y b�squeda de elementos HTML en Java.

Primero, debes asegurarte de incluir la biblioteca JSoup en tu proyecto. 
Puedes descargarla desde el sitio web oficial de JSoup (https://jsoup.org/) 
o utilizar una herramienta de gesti�n de dependencias como Maven o Gradle.
 */

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class Ejemplo3 {

	// https://www.imdb.com/find/?q=paul+newman
	
	void ejecutar() {
	
		System.out.print("Escribe el t�rmino : ");
		String termino=Aplicacion.teclado.next();
		mostrarDefiniciones(termino);
	}
	
	
	void mostrarDefiniciones(String termino) {
        // Crear una instancia de HttpClient
        HttpClient httpClient = HttpClient.newHttpClient();

        // Crear una instancia de HttpRequest con la URL de destino
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(URI.create("https://www.wordreference.com/definicion/"+termino))
//                .header("User-Agent", "Mozilla/5.0")
//                .header("charset", "utf-8")
                .build();

        try {
            // Enviar la solicitud y obtener la respuesta
            HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());

            // Obtener el cuerpo de la respuesta
            String responseBody = httpResponse.body();
/*            System.out.println(responseBody); */
             
            // Parsear el cuerpo HTML utilizando JSoup
            Document document = Jsoup.parse(responseBody);

            // Seleccionar elementos con una clase espec�fica
            Elements elementosDefiniciones = document.select("ol.entry li");

            // Iterar sobre los elementos seleccionados
            for (Element elemento : elementosDefiniciones) {
                System.out.println(elemento.ownText());
            }
        } catch (Exception e) {
            // Manejar excepciones
            e.printStackTrace();
        }		
	}
}
