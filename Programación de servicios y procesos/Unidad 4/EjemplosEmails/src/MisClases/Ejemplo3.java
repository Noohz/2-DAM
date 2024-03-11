package MisClases;


public class Ejemplo3 {

	// https://www.imdb.com/find/?q=paul+newman
	
	void ejecutar() {
   		GestorEmail gestor=new GestorEmail();
  		try {
			gestor.leerMensajesCuentaIMAP();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
