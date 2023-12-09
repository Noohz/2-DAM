package com.example.tareaud2;

public class Usuario {
    private int id;
    private String nombre, email, contrasenia;

    public Usuario(int id, String nombre, String email, String contrasenia) {
        this.id = id;
        this.contrasenia = contrasenia;
        this.nombre = nombre;
        this.email = email;
    }

    public Usuario(String nombre, String contrasenia, String email) {
        this.contrasenia = contrasenia;
        this.nombre = nombre;
        this.email = email;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getContrasenia() {
        return contrasenia;
    }

    public void setContrasenia(String contrasenia) {
        this.contrasenia = contrasenia;
    }

    @Override
    public String toString() {
        return "Usuario{" + "nombre='" + nombre + '\'' + ", email='" + email + '\'' + '}';
    }
}
