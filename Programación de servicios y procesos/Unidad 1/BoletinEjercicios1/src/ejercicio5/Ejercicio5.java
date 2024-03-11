package ejercicio5;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

// OJO, como estas librerías no forman parte del java estándar, hay que descargarse el JAR de la librería y añadírsela al proyecto
// json-20230618.jar en la carpeta Libraries del proyecto
import org.json.JSONArray;
import org.json.JSONObject;

public class Ejercicio5 {
	public static void main(String[] args) {
		String countryName = "";
		// Le pasamos el nombre del país por parámetro
		if (args.length > 0) {
			countryName = args[0];
		}
		int codSalida = 0;
		try {
			// Construye la URL de la API de REST Countries
			String apiUrl = "https://restcountries.com/v3.1/name/" + countryName;
			URL url = new URL(apiUrl);
			
			// Abre una conexión HTTP
			HttpURLConnection conexionHTTP = (HttpURLConnection) url.openConnection();
			conexionHTTP.setRequestMethod("GET");
			
			// Lee la respuesta de la API
			int codigoRespuesta = conexionHTTP.getResponseCode();
			
			if (codigoRespuesta == HttpURLConnection.HTTP_OK) {
				BufferedReader reader = new BufferedReader(new InputStreamReader(conexionHTTP.getInputStream()));
				StringBuilder respuesta = new StringBuilder();
				String linea;
				while ((linea = reader.readLine()) != null) {
					respuesta.append(linea);
				}
				
				reader.close();
				
				// La respuesta contiene datos en formato JSON. Se procesa de la siguioente forma:
				JSONObject jsonDatos = new JSONArray(respuesta.toString()).getJSONObject(0);
				
				int poblacion = jsonDatos.getInt("population"); // Se extrae el dato que tiene el campo "population"
				System.out.println("Población de " + countryName + ": " + poblacion); // Imprimimos la población del país
			} else {
				// Si los datos del país indicado están mal entraría por aquí
				System.err.println("Error al obtener datos de la API. Código de respuesta: " + codigoRespuesta);
				codSalida = -1; // Cerramos el proceso con código de salida -1
			}
			// Cierra la conexión
			conexionHTTP.disconnect();
		} catch (Exception e) {
			e.printStackTrace();
			codSalida = -2; // Cerramos el proceso con código de salida -2
		}
		System.exit(codSalida);
	}
}