package hba;

import java.util.ArrayList;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;

@Entity
@Table
public class Usuario {
	
	@Id
	private String nick;
	
	@Column(nullable = false)
	private String email;
	
	@OneToMany(cascade = CascadeType.ALL, mappedBy = "clave.usuario")
	private ArrayList<Reproduccion> listaReproducciones = new ArrayList<Reproduccion>();

	public Usuario() {

	}

	public Usuario(String nick, String email) {
		this.nick = nick;
		this.email = email;
	}

	public String getNick() {
		return nick;
	}

	public void setNick(String nick) {
		this.nick = nick;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public ArrayList<Reproduccion> getListaReproducciones() {
		return listaReproducciones;
	}

	public void setListaReproducciones(ArrayList<Reproduccion> listaReproducciones) {
		this.listaReproducciones = listaReproducciones;
	}

	@Override
	public String toString() {
		return "Usuario [nick=" + nick + ", email=" + email + "]";
	}
}
