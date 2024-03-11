package com.example.examen13diciembreaitor;

public class Pais {
    String nombrePais;
    String capital;
    String continente;
    int numHabitantes;

    public Pais() {

    }

    public Pais(String nombrePais, String capital, String continente, int numHabitantes) {
        this.nombrePais = nombrePais;
        this.capital = capital;
        this.continente = continente;
        this.numHabitantes = numHabitantes;
    }

    public String getNombrePais() {
        return nombrePais;
    }

    public void setNombrePais(String nombrePais) {
        this.nombrePais = nombrePais;
    }

    public String getCapital() {
        return capital;
    }

    public void setCapital(String capital) {
        this.capital = capital;
    }

    public String getContinente() {
        return continente;
    }

    public void setContinente(String continente) {
        this.continente = continente;
    }

    public int getNumHabitantes() {
        return numHabitantes;
    }

    public void setNumHabitantes(int numHabitantes) {
        this.numHabitantes = numHabitantes;
    }

    @Override
    public String toString() {
        return "Pais{" + "nombrePais='" + nombrePais + '\'' + ", capital='" + capital + '\'' + ", continente='" + continente + '\'' + ", numHabitantes=" + numHabitantes + '}';
    }
}
