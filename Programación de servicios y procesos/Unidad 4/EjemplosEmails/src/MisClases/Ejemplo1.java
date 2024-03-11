package MisClases;

import java.io.IOException;
import javax.mail.MessagingException;

public class Ejemplo1 {
	
	void ejecutar() {
  	  	try {
  	  		// Pedimos la dirección a la que queremos manr el email
  	  		System.out.print("Introduce el email del destinatario del mensaje: ");
  	  		String emailDestinatario=Aplicacion.teclado.nextLine();
  	  		
  	  		System.out.print("Introduce el asunto : ");
  	  		String asunto=Aplicacion.teclado.nextLine();

  	  		System.out.print("Introduce el mensaje : ");
  	  		String mensaje=Aplicacion.teclado.nextLine();

  	  		emailDestinatario="fernandopruebasdam@gmail.com";
  	  		asunto="Mensaje de prueba";
  	  		mensaje="Este es el texto del mensaje";
  	  		
  	  		GestorEmail gestor=new GestorEmail();
  	  		
  	  		gestor.enviarMensajeTexto(emailDestinatario,asunto,mensaje);
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
