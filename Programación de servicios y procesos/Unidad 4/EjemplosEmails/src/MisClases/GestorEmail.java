package MisClases;

import java.io.File;
import java.io.IOException;
import java.util.Properties;

import javax.mail.Address;
import javax.mail.Folder;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Multipart;
import javax.mail.NoSuchProviderException;
import javax.mail.Session;
import javax.mail.Store;
import javax.mail.Transport;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMessage.RecipientType;
import javax.mail.internet.MimeMultipart;

import com.sun.mail.imap.IMAPFolder;

public class GestorEmail {

	private Properties propiedades;
	private Session sesion;
	
	// Cuenta desde la que enviaremos los correos
	String emailEmisor="";
	// Contrase�a de aplicaci�n creada para la cuenta anterior
	String passwordEmisor="";
	
	
	
	private Session getSessionImap() {
		propiedades=new Properties();
		
		// Indica que el protocolo que vamos a usar el es de IMAP
		propiedades.setProperty("mail.store.protocol", "imap");
		// Indica el host del servidor IMAP que vamos a usar		
		propiedades.setProperty("mail.imap.host", "imap.gmail.com");
		// Indica el puerto del servidor SMTP que vamos a usar
		propiedades.setProperty("mail.imap.port", "993");
		// habilita la conexi�n segura mediante SSL/TLS
		propiedades.setProperty("mail.imap.ssl.enable", "true");
		
		// Obtenemos la sesi�n sobre la que trabajaremos
		sesion=Session.getDefaultInstance(propiedades);
		return sesion;
	}
	
	
	
	public void leerMensajesCuentaIMAP() throws Exception{

		// Paso 1. Creaci�n de la sesi�n con la que trabajaremos. La crea en la propiedad de la clase Session"sesion"
		Session sesion=getSessionImap();

		// Paso 2. Obtenemos un objeto Store asociado a una IMAP con conexi�n segura
		/* La clase Store en JavaMail se utiliza para 
		 * representar el almacenamiento de correo electr�nico
		 * y proporciona m�todos para conectarse a un 
		 * servidor de correo, acceder a buzones de correo 
		 * y realizar operaciones relacionadas con el 
		 * almacenamiento de mensajes.
		 */
		Store almacen=sesion.getStore("imaps");
		
		// Paso 3. Establecemos una conexi�n con el servidor
		almacen.connect("imap.gmail.com",993,emailEmisor,passwordEmisor);
		
		// Paso 4. Obtenemos una referencia al buz�n INBOX
		IMAPFolder inbox=(IMAPFolder) almacen.getFolder("INBOX");

		// Paso 5. Leemos los mensajes del buz�n INBOX en el array mensajes
		inbox.open(Folder.READ_WRITE);
		Message[] mensajes=inbox.getMessages();

		// Paso 6. Recorremos los distintos mensajes que hay en el array
		for(int i=0;i<mensajes.length;i++) {
			// Obtenemos el mensaje a procesar
			Message mensaje=mensajes[i];
			
			// Obtenemos la direcci�n qu� env�a el mensaje
			Address[] direccionesOrigen=mensaje.getFrom();
			String direccionFrom=direccionesOrigen[0].toString();
			
			// Obtenesmos la direcci�n a quien va dirigido el mensaje
			Address[] direccionesDestino=mensaje.getRecipients(RecipientType.TO);
			String direccionTo=direccionesDestino[0].toString();
			
			// Obtenemos el asunto
			String asunto=mensaje.getSubject();
         
			// Obtenemos el contenido del mensaje
			Object content = mensaje.getContent();
            String textoMensaje="";
            
            // Si el contenido del mensaje no est� formado s�lo por texto
			if (content instanceof MimeMultipart) {			
	 	 	   MimeMultipart mimeMultipart=(MimeMultipart)mensaje.getContent();
	 	 	   // Habr�a que procesar ese contenido si quisi�ramos 	 	   
	 	 	   textoMensaje="El mensaje no s�lo tiene texto plano";
			}
			// Si el contenido del mensaje est� formado s�lo por texto.
            else if (content instanceof String) {
            	textoMensaje = (String) content;            	
            }
			// Mostramos por consola la informaci�n del mensaje
			System.out.printf("De %s a %s Asunto: %s \n Mensaje : %s\n\n",direccionFrom,direccionTo,asunto,textoMensaje);
		}
		
		// Paso 7. Cerramos la conexi�n
		almacen.close();
	}

	
	
	
	public void enviarMensajeTexto(String destinatario, String asunto, String textoMensaje) throws AddressException, MessagingException, IOException {
		
		// Paso 1. Creaci�n de la sesi�n con la que trabajaremos. La crea en la propiedad de la clase Session"sesion"
		abrirSesionServidorSMTP();

		// Paso 2. Creamos una instancia de la clase Message con la informaci�n del mensaje que se va a enviar
		Message mensaje=crearMensajeTexto(destinatario,asunto,textoMensaje);
		
		// Paso 3. Abrimos una conexi�n con el servidor en un objeto de la clase Transport
		Transport t=conectarServidorSMTP();
		
		// Paso 4. Enviamos el mensaje a trav�s de la conexi�n creada en el apartado anterior
		t.sendMessage(mensaje, mensaje.getAllRecipients());
		
		// Paso 5. Cerramos la conexi�n
		t.close();
	}
	

	
	
	public void enviarMensajeConAdjunto(String destinatario, String asunto, String textoMensaje,String rutaFichero) throws AddressException, MessagingException, IOException {
		
		// Paso 1. Creaci�n de la sesi�n con la que trabajaremos. La crea en la propiedad de la clase "sesion"
		abrirSesionServidorSMTP();

		// Paso 2. Creamos una instancia de la clase Message con la informaci�n del mensaje que se va a enviar
		Message mensaje=this.crearMensajeConAdjunto(destinatario,asunto,textoMensaje,rutaFichero);
		
		// Paso 3. Abrimos una conexi�n con el servidor en un objeto de la clase Transport
		Transport t=conectarServidorSMTP();
		
		// Paso 4. Enviamos el mensaje a trav�s de la conexi�n creada en el apartado anterior
		t.sendMessage(mensaje, mensaje.getAllRecipients());
		
		// Paso 5. Cerramos la conexi�n
		t.close();
	}
	

	
	
	private void abrirSesionServidorSMTP() {
		
		/* Devuelve un objeto de tipo Properties que contiene informaci�n sobre la configuraci�n
		   y propiedades del sistema en el cual se est� ejecutando la aplicaci�n Java	*/
		propiedades=System.getProperties();
		
		// A�adimos claves espec�ficas al conjunto de propiedades ya que ser�n necesarias para obtener la sesi�n 

		// Indica si la autenticaci�n SMTP est� habilitada en el servidor
		propiedades.put("mail.smtp.auth", "true");      
		// Indica el host del servidor SMTP que vamos a usar
		propiedades.put("mail.smtp.host", "smtp.gmail.com");
		// Indica el puerto en el que trabaja el servidor
		propiedades.put("mail.smtp.port", "587");
		// Indica si la capa de seguridad TLS (Transport Layer Security) debe ser habilitada al establecer la conexi�n con el servidor SMTP
		propiedades.put("mail.smtp.starttls.enable", "true");
		
		
		/* Obtenemos una instancia de la clase javax.mail.Session
		 
		 La clase Session se usa para configurar diversos aspectos del entorno de JavaMail al 
		 enviar o recibir mensajes de correo electr�nico. La sesi�n act�a como un contenedor
		 para las propiedades y ajustes necesarios para establecer la conexi�n con el servidor de 
		 correo electr�nico
		
		
		 El segundo par�metro igual a null indica que no hay ning�n Authenticator que se encargue de ofrecer las credenciales al servidor
		*/
		sesion=Session.getInstance(propiedades,null);  
	}
	
	private Message crearMensajeTexto(String destinatario,String asunto, String textoMensaje) throws MessagingException, AddressException, IOException{
		
		// Creamos la instancia de la clase Message
		Message mensaje=new MimeMessage(sesion);
		// Indicamos quien env�a el mensaje
		mensaje.setFrom(new InternetAddress(emailEmisor));
		// Indicamos los destinatarios del mensaje. En este caso en el campo Para (TO) del mensaje
		mensaje.addRecipient(Message.RecipientType.TO,new InternetAddress(destinatario));
		// Indicamos el asunto del objeto mensaje
		mensaje.setSubject(asunto);
		// Indicamos el texto del objeto mensaje
		mensaje.setText(textoMensaje);
		return mensaje;
	}

	private Message crearMensajeConAdjunto(String destinatario,String asunto, String textoMensaje, String rutaFichero) throws MessagingException, AddressException, IOException{
		
		// Creamos la instancia de la clase Message
		Message mensaje=new MimeMessage(sesion);
		// Indicamos quien env�a el mensaje
		mensaje.setFrom(new InternetAddress(emailEmisor));
		// Indicamos los destinatarios del mensaje. En este caso en el campo Para (TO) del mensaje
		mensaje.addRecipient(Message.RecipientType.TO,new InternetAddress(destinatario));
		// Indicamos el asunto del objeto mensaje
		mensaje.setSubject(asunto);

		// Creamos el cuerpo del mensaje
		MimeBodyPart cuerpoMensaje=new MimeBodyPart();
		// Le asignamos el texto del mensaje
		cuerpoMensaje.setText(textoMensaje);

		// Creamos el objeto MimeBodyPart con el fichero adjunto del mensaje
		MimeBodyPart parteAdjuntos=new MimeBodyPart();
		parteAdjuntos.attachFile(new File(rutaFichero));

		// Creamos elobjeto MimeMultipart que englobar� los dos anteriores 
		Multipart contenidoGlobal=new MimeMultipart();
		// Le a�adimos la parte del texto
		contenidoGlobal.addBodyPart(cuerpoMensaje);
		// Le a�adimos la parte de los ficheros adjuntos
		contenidoGlobal.addBodyPart(parteAdjuntos);

		// Asociamos al mensaje el contenido global
		mensaje.setContent(contenidoGlobal);
		return mensaje;
	}

	
	private Transport conectarServidorSMTP() throws NoSuchProviderException, MessagingException{
		
		// Obtenemos, a partir de la sesi�n, una instancia del objeto Transport asociado al protocolo SMTP 
		Transport t= (Transport) sesion.getTransport("smtp");
		// Establecemos una conexi�n con el servidor
		t.connect(propiedades.getProperty("mail.smtp.host"), emailEmisor, passwordEmisor);
		return t;		
	}
}
