package ejercicio;

import java.io.File;
import java.nio.file.Paths;

import software.amazon.awssdk.auth.credentials.AwsSessionCredentials;
import software.amazon.awssdk.auth.credentials.StaticCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.CreateBucketRequest;
import software.amazon.awssdk.services.s3.model.PutObjectRequest;
import software.amazon.awssdk.services.s3.model.S3Exception;

public class BucketS3 {

	S3Client clienteS3;
	String nombreBucket;

	final String region = "us-east-1";
	final String accessKey = "ASIAZI2LBTYOSHAMU6HH";
	final String secretKey = "TRnp1o0ZURsiW1s7ZwdX2MgCriLHjmwxvabg2Ung";
	final String sessionToken = "FwoGZXIvYXdzEAMaDFUNv/0jcI1ecgv3GyLFAbORN15WC8dZKWKaUGFkQWFS5odFbx1tRrpByTXS1M641tY6dC3Yb1rHj432189/3VPQudPkK4K/PZXW5t5cApZI1StREag1jCcaxSK0IlFTVdwaWJRlYckZn+JXVUCyJHHLh98Z5qJq8Y5ZvVKxtHHlwJr7iiwm8j5xlcQ6+kIon2+Y5uAXnK8CUAepEGsmbxwueRsH79uRHX5vxv2C+7LjJmAze4+NvOOB4rUheRebMC2BVElCyDc7JCbB5hadvGCrjhDaKOLvh64GMi2KyVEthHGWq4CJH0LJ6b2e8A9oNCED2Jo+z2Grjuck3PRK8fH2pNPBh3CoCsA=";

	public BucketS3() {
		clienteS3 = S3Client.builder().region(Region.US_EAST_1).credentialsProvider(
				StaticCredentialsProvider.create(AwsSessionCredentials.create(accessKey, secretKey, sessionToken)))
				.build();

		nombreBucket = "bucketquijotears";
	}

	public void crearBucket() {
		System.out.print("Introduce el nombre del Bucket a crear:");
		String nuevoNombre = Aplicacion.teclado.nextLine();

		try {
			CreateBucketRequest createBucketRequest = CreateBucketRequest.builder().bucket(nuevoNombre).build();

			clienteS3.createBucket(createBucketRequest);

			System.out.println("El bucket " + nuevoNombre + " se ha creado correctamente. \n");
			
			System.out.println("Subiendo el txt del quijote al bucket...");
			
			PutObjectRequest putObjectRequest = PutObjectRequest.builder().bucket(nombreBucket).key("original/quijote.txt").build();
			File txtQuijote = new File("el_quijote.txt");
			clienteS3.putObject(putObjectRequest, Paths.get(txtQuijote.getPath()));
			
			System.out.println("Se ha subido el quijote correctamente.\n");
			
		} catch (S3Exception e) {

			System.out.println("Ha ocurrido un error a la hora de crear el bucket." + e);
		}
	}

	public void descomponerQuijote() {
		
		
		
	}

}
