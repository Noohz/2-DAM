package MisClases;

import java.io.IOException;
import java.nio.file.FileSystems;
import java.nio.file.Path;

import javax.mail.MessagingException;

public class Ejemplo2 {

		
	void ejecutar() {
  	  	try {
  	  		// Pedimos la dirección a la que queremos manr el email
  	  		System.out.print("Introduce el email del destinatario del mensaje: ");
  	  		String emailDestinatario=Aplicacion.teclado.nextLine();
  	  		
  	  		System.out.print("Introduce el asunto : ");
  	  		String asunto=Aplicacion.teclado.nextLine();

  	  		System.out.print("Introduce el mensaje : ");
  	  		String mensaje=Aplicacion.teclado.nextLine();

  	  		String rutaFichero="";
  	  		emailDestinatario="fernandopruebasdam@gmail.com";
  	  		asunto="Mensaje de prueba";
  	  		mensaje="Este es el texto del mensaje";
  	  		
  	  		
  	  		boolean ficheroValido=false;
  	  		while(!ficheroValido) {
  	  			System.out.print("Introduce la ruta del fichero que quieres adjuntar mensaje : ");
  	  			rutaFichero=Aplicacion.teclado.nextLine();
  	  			rutaFichero="C:\\Ejemplos\\Hola.txt";
  	  			// Comprobamos si existe un fichero en la ruta indicada
  	  			
  	  			// Crear un objeto Path a partir de la cadena de ruta
  	  			Path path = FileSystems.getDefault().getPath(rutaFichero);
  		 
  	  			if (java.nio.file.Files.exists(path))
  	  				ficheroValido=true;
  	  		}
  	  		
  	  		GestorEmail gestor=new GestorEmail();
  	  		gestor.enviarMensajeConAdjunto(emailDestinatario,asunto,mensaje,rutaFichero);
  	  	}  	  		
		catch (MessagingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
