package examen;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.util.ArrayList;

import software.amazon.awssdk.auth.credentials.AwsSessionCredentials;
import software.amazon.awssdk.auth.credentials.StaticCredentialsProvider;
import software.amazon.awssdk.core.sync.ResponseTransformer;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.GetObjectRequest;

public class Gestor implements Runnable {

	S3Client clienteS3;
	String nombreBucket;

	final String region = "us-east-1";
	final String accessKey = "";
	final String secretKey = "";
	final String sessionToken = "";

	Socket socketCliente;
	OutputStream os;
	BufferedReader lectorDatos;
	InputStream is;

	ArrayList<String> datosPaises = new ArrayList<String>();

	public Gestor(Socket socketCliente) {
		this.socketCliente = socketCliente;

		try {
			os = socketCliente.getOutputStream();
			is = socketCliente.getInputStream();

			InputStreamReader inputStreamReader = new InputStreamReader(is);

			lectorDatos = new BufferedReader(inputStreamReader);

			cargarDatosS3();
		} catch (IOException e) {

			e.printStackTrace();
		}
	}

	private void cargarDatosS3() {
		clienteS3 = S3Client.builder().region(Region.US_EAST_1).credentialsProvider(
				StaticCredentialsProvider.create(AwsSessionCredentials.create(accessKey, secretKey, sessionToken)))
				.build();

		nombreBucket = "arsexamendam2805";

		String objectKey = "datos/Paises.csv";

		try {
			GetObjectRequest getObjectRequest = GetObjectRequest.builder().bucket(nombreBucket).key(objectKey).build();

			InputStream inputStream = clienteS3.getObject(getObjectRequest, ResponseTransformer.toInputStream());

			BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));

			String linea;
			while ((linea = reader.readLine()) != null) {
				datosPaises.add(linea);
			}
		} catch (IOException e) {
			System.err.println("Ha ocurrido un problema al intentar leer el fichero de S3...");
		}
	}

	@Override
	public void run() {
		String linea;
		try {
			boolean salir = false;
			while (!salir) {
				while ((linea = lectorDatos.readLine()) != null) {
					System.out.println("Mensaje recibido del cliente: " + linea);
					String[] partes = linea.split("\t");

					if (partes[0].trim().equals("JuegoGlobal")) {
						int numPreguntas = Integer.parseInt(partes[1].trim());
						if (numPreguntas >= 5 && numPreguntas <= 10) {
							juegoGlobal(numPreguntas);
						} else {
							String motivo = "Debes introducir un número de preguntas entre 5 y 10...";
							os.write(("Error \t" + motivo + "\n").getBytes());
						}
					} else if (partes[0].trim().equals("Final")) {
						salir = true;
						break;
					}
				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				lectorDatos.close();
				os.close();
				socketCliente.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	private void juegoGlobal(int numPreguntas) {
		int cont = 0;
		int numAciertos = 0;
		int numFallos = 0;

		try {
			for (String p : datosPaises) {
				if (cont >= numPreguntas)
					break;
				String[] paises = p.split(";");
				String pais = paises[0];
				String capital = paises[1];

				os.write(("Pregunta \t" + pais + "\t" + (cont + 1) + "\t" + numAciertos + "\t" + numFallos + "\n")
						.getBytes());

				String respuesta = lectorDatos.readLine();
				System.out.println("Respuesta del cliente: " + respuesta);

				if (respuesta != null && respuesta.equals("Respuesta \t" + pais + "\t" + capital)) {
					numAciertos++;
				} else {
					numFallos++;
				}
				cont++;
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
