package MisClases;

import software.amazon.awssdk.regions.Region;
import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Base64;
import java.util.Random;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

import software.amazon.awssdk.auth.credentials.AwsSessionCredentials;
import software.amazon.awssdk.auth.credentials.StaticCredentialsProvider;
import software.amazon.awssdk.core.sync.RequestBody;
import software.amazon.awssdk.core.sync.ResponseTransformer;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.CreateBucketRequest;
import software.amazon.awssdk.services.s3.model.DeleteObjectRequest;
import software.amazon.awssdk.services.s3.model.GetObjectRequest;
import software.amazon.awssdk.services.s3.model.ListObjectsRequest;
import software.amazon.awssdk.services.s3.model.ListObjectsResponse;
import software.amazon.awssdk.services.s3.model.ListObjectsV2Request;
import software.amazon.awssdk.services.s3.model.ListObjectsV2Response;
import software.amazon.awssdk.services.s3.model.PutObjectRequest;
import software.amazon.awssdk.services.s3.model.S3Exception;
import software.amazon.awssdk.services.s3.model.S3Object;

public class GestorS3 {

	S3Client clienteS3;  // Objeto cliente con el que vamos a interactuar con el servicio S3
	String nombreBucket; // Nombre del bucket en el que vamos a trabajar

    final String region = "us-east-1";
    final String accessKey = "XXX";
    final String secretKey = "XXX";
    final String sessionToken = "XXX";  // Token de sesión
	
	
	// Constructor
	GestorS3() {
		// Configuramos el cliente de S3 indicándole las credenciales de conexión
		/* Si tuviéramos una cuenta AWS convencional deberíamos realizar la conexión 
		 * basándonos en las credenciales IAM del usuario, indicando su "ACCESS_KEY" y "SECRET_KEY".
		 * Si accedemos a S3 a través del Learner Lab, necesitamos una credencial basada
		 * en el token de sesión que proporciona acceso temporal a los servicios de AWS.
		 * En este caso hay que especificar la "ACCESS_KEY", "SECRET_KEY" y "SESSION_TOKEN 
		 * que se pueden ver en AWS Details tras lanzar el laboratorio virtual.
		 * También existe la posibilidad de dar estos datos en un fichero del proyecto para no tener que indicarlos en el código
		 */
		
		clienteS3 = S3Client.builder()
            .region(Region.US_EAST_1) // Indicamos la región donde trabajaremos
//            .credentialsProvider(StaticCredentialsProvider.create(AwsBasicCredentials.create("ACCESS_KEY", "SECRET_KEY")))
//            .credentialsProvider(StaticCredentialsProvider.create(AwsSessionCredentials.create("ACCESS_KEY", "SECRET_KEY", "SESSION_TOKEN")))
            .credentialsProvider(StaticCredentialsProvider.create(AwsSessionCredentials.create(accessKey, secretKey, sessionToken)))
            .build();	// El método build() es el que me devuelve el cliente de sesión.
    
		// Nombre del bucket en el que vamos a trabajar
		nombreBucket = "fjgcdam2024prueba1";
    }
	
	// ----------------------------------------------------------------------
	
	void listarContenidoBucket() {
		
		// Le pedimos al usuario el prefijo (carpeta) de los contenidos que queremos listar
		System.out.print("Introduce el prefijo(carpeta) de los contenidos. P ej: 'datos/' : ");
		String prefijo=Aplicacion.teclado.nextLine();
		
		try {
			// Llamamos a la API de S3 para listar objetos en el bucket que tengan en su key el prefijo indicado
			ListObjectsResponse listObjectsResponse = clienteS3.listObjects(builder -> builder.bucket(nombreBucket).prefix(prefijo));
			
			// Vamos recorriendo la lista de objetos que hay en los contenidos de la respuesta
			for (S3Object s3Object : listObjectsResponse.contents()) {
				// Imprime información sobre cada objeto
				System.out.println("Nombre del objeto: " + s3Object.key());
				System.out.println("Tamaño del objeto: " + s3Object.size());
				System.out.println("Última modificación: " + s3Object.lastModified());
				System.out.println("ETag: " + s3Object.eTag());
				System.out.println("------");
			}
		} catch(S3Exception e){
			System.out.println("Hay problemas para acceder a ese bucket");
		}
	}
	
	// ----------------------------------------------------------------------
	
	void crearBucket() {
		// Le pedimos al usuario el nombre del bucket
		System.out.print("Introduce el nombre que quieres que tenga el bucket :");
		String nuevoNombre=Aplicacion.teclado.nextLine();
		
        try {
            // Instanciamos la solicitud para crear el bucket
            CreateBucketRequest createBucketRequest = CreateBucketRequest.builder()
                    .bucket(nuevoNombre)
                    .build();

            // Ejecutamos la solicitud para crear el bucket
            clienteS3.createBucket(createBucketRequest);

            System.out.println("El bucket " + nuevoNombre + " se ha creado con éxito.");
        } catch (S3Exception e) {
        	// Ha habido problemas en la creación del bucket
            System.out.println("Ha habido un problema en la creación del bucket. Quizás ya exista uno con ese nombre");
        }		
	}
	
	// ----------------------------------------------------------------------
	
	void borrarContenidoBucket() {

		// Este método borra todo el contenido que haya en la carpeta indicada del bucket de trabajo

		// Ruta donde borraremos el contenido
		String ruta="datosGenerados/";
		
		
		// Hemos de recordar que en S3 no existe el concepto de carpeta, sino que hay objetos con barras en sus nombres de ficheros.
		// Lo que se puede hacer es borrar todos los objetos que tengan el mismo prefijo, pero primero
		// hay que ir buscándolos con list_objects
       
		// Lista todos los objetos que tengan el prefijo con el nombre de la carpeta
		ListObjectsResponse listObjectsResponse = clienteS3.listObjects(builder -> builder.bucket(nombreBucket).prefix(ruta));

        // Vamos recorriendo todos los objetos de la lista de respuesta obtenida y
		// eliminamos cada objeto uno a uno
        for (S3Object s3Object : listObjectsResponse.contents()) {

        	DeleteObjectRequest deleteObjectRequest = DeleteObjectRequest.builder()
                    .bucket(nombreBucket)
                    .key(s3Object.key())
                    .build();
            clienteS3.deleteObject(deleteObjectRequest);
            System.out.println("Objeto eliminado: " + s3Object.key());		
        }
	}
	
	// ----------------------------------------------------------------------
	
	void leerContenidoObjetoTexto() {
        // Especificamos el nombre del objeto que deseamos leer
        String objectKey = "datos/Titanic.csv";

        try {
        	// Llamamos a la API de S3 para obtener información sobre el objeto
        	GetObjectRequest getObjectRequest = GetObjectRequest.builder()
                .bucket(nombreBucket)
                .key(objectKey)
                .build();
        	// Obtenemos el flujo de entrada desde el objeto S3 que intentamos obtener
        	InputStream inputStream = clienteS3.getObject(getObjectRequest, ResponseTransformer.toInputStream());
        	// Convertimos el flujo de entrada a texto usando BufferedReader
        	BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));

            // Leemod línea por línea y muestra el contenido
            String linea;
            while ((linea = reader.readLine()) != null) {
                System.out.println(linea);
            }
        } catch (IOException e) {
            //e.printStackTrace();
        	System.out.println("Hubo un problema accediendo al objeto");
        }
	}	
	
	// ----------------------------------------------------------------------
	
	void generarContenidoFicherosTexto() {

		// Ruta donde crearemos el contenido
		String ruta="datosGenerados/";
		
		// Creamos 10 ficheros de 1000 números aleatorios cada 5 segundos y los guardamos 
		// una carpeta con el momento y un fichero llamado datos.dat
		
		Random numAleatorio=new Random();
		for(int contador=0;contador<10;contador++) {
			
			// Generamos el objeto OutputStream donde escribiremos el contenido
	        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();

			// Generamos un fichero con 1000 números aleatorios
			for(int i=0;i<1000;i++) {
				int numero=numAleatorio.nextInt(0,1000001);
	            String numeroStr = numero + "\n";
	            try {
					outputStream.write(numeroStr.getBytes(StandardCharsets.UTF_8));
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			
			// Una vez que tengo los 1000 números escritos en el ByteOutputStream
			
			// Generamos un inputStream a partir del outputStream
			InputStream inputStream=new ByteArrayInputStream(outputStream.toByteArray());
		
			// Obtenemos la fecha y hora actual con el formato (MM-DD-AAAA_HH-MM-SS)
	        LocalDateTime currentDateTime = LocalDateTime.now();
	        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("MM-dd-yyyy_HH-mm-ss");
	        String cadenaFechaHora=currentDateTime.format(formatter);

	        // Establecemos el nombre que tendrá el objeto
	        String nombreObjeto= ruta + cadenaFechaHora+ "/contenido.dat";

	        
            // Creamos la solicitud para sobrescribir el objeto
            PutObjectRequest putObjectRequest = PutObjectRequest.builder()
                    .bucket(nombreBucket)
                    .key(nombreObjeto)
                    .build();

            // Creamos un objeto RequestBody a partir de un InputStream
            RequestBody requestBody=null;

            try {
				requestBody = RequestBody.fromInputStream(inputStream, inputStream.available());
	            // Escribimos el contenido del objeto en S3 
	            clienteS3.putObject(putObjectRequest, requestBody);	
	            System.out.println("Subido el objeto :" + nombreBucket + "/" + nombreObjeto);
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			// Hacemos una pausa de 5 segundos;			
			try {
				Thread.sleep(5000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			} 
		}
	}

// ----------------------------------------------------------------------

	void leerContenidoApiRest() {
		
        // Endpoint para listar buckets
//		String endpoint = "https://s3-accesspoint.us-east-1.amazonaws.com/datos2/Titanic.csv";
//        String endpoint = "https://fjgcdam2024prueba1.s3.us-east-1.amazonaws.com/datos2/Titanic.csv";
        String endpoint = "http://s3.amazonaws.com/fjgcdam2024prueba1/datos2/Titanic.csv";

        try {
            // Construye la URL para la solicitud
            URL url = new URL(endpoint);

            // Abre una conexión HTTP
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            // Configura la solicitud HTTP GET
            connection.setRequestMethod("GET");
            // Añade las cabeceras necesarias para la autenticación
            connection.setRequestProperty("X-Amz-Security-Token", sessionToken);
            connection.setRequestProperty("X-Amz-Secret-Key", secretKey);
            connection.setRequestProperty("X-Amz-Access-Key-Id", accessKey);

            // Obtiene la respuesta
            int responseCode = connection.getResponseCode();

            // Lee la respuesta
            if (responseCode == HttpURLConnection.HTTP_OK) {
                BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String inputLine;
                StringBuilder response = new StringBuilder();

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                in.close();

                // Imprime la respuesta
                System.out.println(response.toString());
            } else {
            	BufferedReader in = new BufferedReader(new InputStreamReader(connection.getErrorStream()));
            	String linea;
                while ((linea = in.readLine()) != null) {
                    System.out.println(linea);
                }
                in.close();
            	System.out.println("Error en la solicitud. Código de respuesta: " + responseCode);
            }

            // Cierra la conexión
            connection.disconnect();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }		

// ----------------------------------------------------------------------

}
