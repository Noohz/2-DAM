package ejercicio4;

import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.ArrayList;
import java.util.Scanner;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class Aplicacion {

	static Scanner teclado = new Scanner(System.in);

	public static void main(String[] args) {

		boolean salir = false;
		while (salir == false) {

			System.out.println("#** MENÚ **#");
			System.out.println("1 - WEB Scrapping (JSoup).");
			System.out.println("2 - Salir.");

			int opcion = teclado.nextInt();
			teclado.nextLine();
			switch (opcion) {
			case 0:
				salir = true;
				break;
			case 1:
				webScrapping();
				break;
			case 2:
				break;
			}
			
		}
		teclado.close();
	}

	private static void webScrapping() {
		webScrappingFJG();
	}

	private static void webScrappingFJG() {
		ArrayList<String> nombre = new ArrayList<String>();
		ArrayList<String> precio = new ArrayList<String>();
		
		HttpClient httpClient = HttpClient.newHttpClient();

		HttpRequest httpRequest = HttpRequest.newBuilder()
				.uri(URI.create("http://fjgcdam2024examenweb.s3-website-us-east-1.amazonaws.com"))
				/*.header("User-Agent", "Mozilla/5.0").header("charset", "utf-8")*/.build();

		try {
			HttpResponse<String> httpResponse = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());

			String responseBody = httpResponse.body();

			Document document = Jsoup.parse(responseBody);
			
			Elements elementosDefiniciones = document.select("h3");
			for (Element elemento : elementosDefiniciones) {
				System.out.println(elemento.ownText());
				nombre.add(elemento.ownText());
			}
			
			Elements elementoPrecio = document.select("h3 span");
			for (Element element : elementoPrecio) {
				System.out.println(element.ownText());
				precio.add(element.ownText());
			}
			
			for (int i = 0; i < nombre.size(); i ++) {
				System.out.println("Cafe => " + nombre.get(i) + " -- " + " precio => " + precio.get(i));
			}
			
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
