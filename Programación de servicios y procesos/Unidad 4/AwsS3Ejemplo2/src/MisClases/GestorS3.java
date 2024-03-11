package MisClases;

import software.amazon.awssdk.regions.Region;
import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
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
import software.amazon.awssdk.services.s3.model.DeleteObjectResponse;
import software.amazon.awssdk.services.s3.model.GetObjectRequest;
import software.amazon.awssdk.services.s3.model.HeadBucketRequest;
import software.amazon.awssdk.services.s3.model.ListObjectsRequest;
import software.amazon.awssdk.services.s3.model.ListObjectsResponse;
import software.amazon.awssdk.services.s3.model.ListObjectsV2Request;
import software.amazon.awssdk.services.s3.model.ListObjectsV2Response;
import software.amazon.awssdk.services.s3.model.NoSuchBucketException;
import software.amazon.awssdk.services.s3.model.NoSuchKeyException;
import software.amazon.awssdk.services.s3.model.PutObjectRequest;
import software.amazon.awssdk.services.s3.model.S3Exception;
import software.amazon.awssdk.services.s3.model.S3Object;

public class GestorS3 {

	S3Client clienteS3;  // Objeto cliente con el que vamos a interactuar con el servicio S3
	String nombreBucketTrabajo; // Nombre del bucket en el que vamos a trabajar
    String rutaQuijoteS3="original/quijote.txt"; // Establecemos la ruta del objeto del Qujote en S3
    
    final String region = "us-east-1";
    final String accessKey = "";
    final String secretKey = "";
    final String sessionToken = "";  // Token de sesión
	
	
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
            .credentialsProvider(StaticCredentialsProvider.create(AwsSessionCredentials.create(accessKey, secretKey, sessionToken)))
            .build();	// El método build() es el que me devuelve el cliente de sesión.
    
		// Nombre del bucket en el que vamos a trabajar
		nombreBucketTrabajo = "";	
    }

	// ----------------------------------------------------------------------
	
	void crearBucketTrabajo() {
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
            nombreBucketTrabajo=nuevoNombre;
        } catch (S3Exception e) {
        	// Ha habido problemas en la creación del bucket
            System.out.println("Ha habido un problema en la creación del bucket. Quizás ya exista uno con ese nombre");
        }
        System.out.println("El bucket de trabajo actual es: " + nombreBucketTrabajo);

	}
	
	// ----------------------------------------------------------------------
	
	void establecerBucketTrabajo() {
		// Le pedimos al usuario el nombre del bucket
		System.out.print("Introduce el nombre del bucket que quieres establerer");
		String nombreBucket=Aplicacion.teclado.nextLine();
		
		// Chequeamos si existe un bucket con ese nombre en S3
		HeadBucketRequest headBucketRequest = HeadBucketRequest.builder()
	            .bucket(nombreBucket)
	            .build();

	    try {
	        clienteS3.headBucket(headBucketRequest);
            nombreBucketTrabajo=nombreBucket;
	    } catch (NoSuchBucketException e) {
        	System.out.println("El bucket que has indicado no está asociado a nuestra cuenta AWS");
	    }		
        
        System.out.println("El bucket de trabajo actual es: " + nombreBucketTrabajo);
	}
	
	// ----------------------------------------------------------------------

	void copiarQuijoteDesdeLocal() {
		// Le pedimos al usuario que nos indique donde está el fichero en el sistema de archivos local
		System.out.print("Introduce la ruta local donde está el fichero con el Quijote: ");
		String rutaFichero=Aplicacion.teclado.nextLine();
		
	    // Creamos un objeto File con la ruta del archivo
        File fichero = new File(rutaFichero);

        // Verifica si el archivo existe
        if (fichero.exists()) {
        	
        	// Lo subo a S3
        	// Creamos la solicitud para sobrescribir el objeto
            PutObjectRequest putObjectRequest = PutObjectRequest.builder()
                    .bucket(nombreBucketTrabajo)
                    .key(rutaQuijoteS3)
                    .build();

            // Creamos un objeto RequestBody a partir de un InputStream
            RequestBody requestBody=null;

            try {
            	// Creamos el RequestBody desde el fichero 
				requestBody = RequestBody.fromFile(fichero);
	            // Escribimos el contenido del objeto en S3 
	            clienteS3.putObject(putObjectRequest, requestBody);	
	            System.out.println("Subido el Quijote a :" + nombreBucketTrabajo + "/" + rutaQuijoteS3);
			} catch (S3Exception e) {
				// TODO Auto-generated catch block
	            System.out.println("El objeto no ha podido subirse");
			}
        } else {
            System.out.println("El fichero indicado no existe en tu sistema de archivos local");
        }
    }			

	// ----------------------------------------------------------------------
	
	void crearFragmentosQuijote() {
		
		// Le indicamos al usuario que nos indique la carpeta donde quiere crear los fragmentos dentro del bucket
		System.out.print("Introduce la carpeta del bucket donde quieres crear los fragmentos: ");
		String carpetaDestino=Aplicacion.teclado.nextLine();
		
		// Intentamos leer el contenido del Quijote que hay en el bucket de trabajo
        try {
        	// Llamamos a la API de S3 para obtener información sobre el objeto
        	GetObjectRequest getObjectRequest = GetObjectRequest.builder()
                .bucket(nombreBucketTrabajo)
                .key(rutaQuijoteS3)
                .build();
        	// Obtenemos el flujo de entrada desde el objeto S3 que intentamos obtener
        	InputStream inputStream = clienteS3.getObject(getObjectRequest, ResponseTransformer.toInputStream());
        	// Convertimos el flujo de entrada a texto usando BufferedReader
        	BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream,"UTF-8"));

            // Leemos línea por línea y muestra el contenido
            String linea;
            int contadorFichero=1;
            StringBuilder contenido= new StringBuilder();
            int contadorLinea=0;
            boolean huboError=false;
            while ((linea = reader.readLine()) != null && huboError==false) {
            	contenido.append(linea+"\n");
            	contadorLinea++;
            	if(contadorLinea==1001) {
            		// Subimos el objeto con el fragmento a S3
            		try{
            			subirFragmento (contadorFichero, contenido, carpetaDestino);
                		contadorLinea=0;  // Restablecemos el contador de Línea
                		contadorFichero++; // Incrementamos el contador de fichero
                		contenido=new StringBuilder(); // Creamos un nuevo objeto para el nuevo contenido
            		}
            		catch(IOException e) {
            			huboError=true;
            		}
            	}
            }
            
            // Escribo el último fragmento si procede
            if(contadorLinea>0 && huboError==false) {
        		try{
        			subirFragmento (contadorFichero, contenido, carpetaDestino);
        		}
        		catch(IOException e) {
        			huboError=true;
        		}
            }
            
            if(huboError==true) {
            	System.out.println("Se produjo un error durante la creación de los fragmentos");
            }
        } catch (IOException e) {
        	System.out.println("Hubo un problema accediendo al objeto del Quijote. ¿Seguro que lo has subido?");
        }
	}

	// ----------------------------------------------------------------------
		
	void subirFragmento (int numFragmento, StringBuilder contenido, String carpetaUsuario) throws IOException {

		String nombreObjeto=carpetaUsuario+"/quijote"+numFragmento+".txt";

		// Creamos la solicitud para sobrescribir el objeto
        PutObjectRequest putObjectRequest = PutObjectRequest.builder()
                .bucket(nombreBucketTrabajo)
                .key(nombreObjeto)
                .build();

        // Creamos un objeto RequestBody a partir de un String
        RequestBody requestBody=null;

		requestBody = RequestBody.fromString(contenido.toString());
        // Escribimos el contenido del objeto en S3 
        clienteS3.putObject(putObjectRequest, requestBody);	
        System.out.println("Subido el objeto :" + nombreBucketTrabajo + "/" + nombreObjeto);
	}

	// ----------------------------------------------------------------------
		
	void listarFragmentos() {
		
		// Le pedimos al usuario el prefijo (carpeta) donde están los fragmentos
		System.out.print("Introduce el prefijo(carpeta) donde están los fragmentos (P.Ej: fragmentos/): ");
		String prefijo=Aplicacion.teclado.nextLine();
		
		try {
			// Llamamos a la API de S3 para listar objetos en el bucket que tengan en su key el prefijo indicado
			ListObjectsResponse listObjectsResponse = clienteS3.listObjects(builder -> builder.bucket(nombreBucketTrabajo).prefix(prefijo));
			
			// Vamos recorriendo la lista de objetos que hay en los contenidos de la respuesta
			for (S3Object s3Object : listObjectsResponse.contents()) {
				// Imprime información sobre cada objeto
				System.out.println("Nombre del objeto: " + s3Object.key());
			}
		} catch(S3Exception e){
			System.out.println("Hay problemas para acceder a ese contenido del bucket");
		}
	}

	// ----------------------------------------------------------------------
	
	void leerContenidoFragmento() {

		// Le pedimos al usuario la ruta del fragmento a leer
		System.out.print("Introduce la ruta(key) del fragmento a leer (P.Ej: fragmentos/quijote12.txt): ");
		String rutaObjeto=Aplicacion.teclado.nextLine();

        try {
        	// Llamamos a la API de S3 para obtener información sobre el objeto
        	GetObjectRequest getObjectRequest = GetObjectRequest.builder()
                .bucket(nombreBucketTrabajo)
                .key(rutaObjeto)
                .build();
        	// Obtenemos el flujo de entrada desde el objeto S3 que intentamos obtener
        	InputStream inputStream = clienteS3.getObject(getObjectRequest, ResponseTransformer.toInputStream());
        	// Convertimos el flujo de entrada a texto usando BufferedReader
        	BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream,"UTF-8"));

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

	void borrarFragmento() {

		// Le pedimos al usuario la ruta del fragmento a borrar
		System.out.print("Introduce la ruta(key) del fragmento a borrar (P.Ej: fragmentos/quijote12.txt): ");
		String rutaObjeto=Aplicacion.teclado.nextLine();

		try {
       	 	DeleteObjectRequest deleteObjectRequest = DeleteObjectRequest.builder()
              .bucket(nombreBucketTrabajo)
              .key(rutaObjeto)
              .build();
       	 	clienteS3.deleteObject(deleteObjectRequest);
       	 	System.out.println("Objeto eliminado: " + rutaObjeto);
         } catch(S3Exception e) {
			System.out.println("Hubo problemas borrando el objeto. ¿Seguro que existe?");
		}
    }
	
	// ----------------------------------------------------------------------

	void borrarCarpetaFragmentos() {
		// Este método borra todo el contenido que haya en la carpeta indicada por el usuario en el bucket de trabajo

		// Le pedimos al usuario la ruta de la carpeta a borrar
		System.out.print("Introduce la ruta de la carpeta que quieres borrar (P.Ej: fragmentos/): ");
		String rutaCarpeta=Aplicacion.teclado.nextLine();

		// Hemos de recordar que en S3 no existe el concepto de carpeta, sino que hay objetos con barras en sus nombres de ficheros.
		// Lo que se puede hacer es borrar todos los objetos que tengan el mismo prefijo, pero primero
		// hay que ir buscándolos con list_objects
       
		// Lista todos los objetos que tengan el prefijo con el nombre de la carpeta
		ListObjectsResponse listObjectsResponse = clienteS3.listObjects(builder -> builder.bucket(nombreBucketTrabajo).prefix(rutaCarpeta));

        // Vamos recorriendo todos los objetos de la lista de respuesta obtenida y
		// eliminamos cada objeto uno a uno
        for (S3Object s3Object : listObjectsResponse.contents()) {
        	DeleteObjectRequest deleteObjectRequest = DeleteObjectRequest.builder()
                    .bucket(nombreBucketTrabajo)
                    .key(s3Object.key())
                    .build();
            clienteS3.deleteObject(deleteObjectRequest);
            System.out.println("Objeto eliminado: " + s3Object.key());		
        }
	}
	
	// ----------------------------------------------------------------------
}
