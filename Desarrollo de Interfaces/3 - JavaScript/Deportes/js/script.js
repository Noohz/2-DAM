window.onload = inicio;
const URLPAISES = "https://www.thesportsdb.com/api/v1/json/3/all_countries.php";
const URLDEPORTES = "deportes.json";
const URLEQUIPOS = "https://www.thesportsdb.com/api/v1/json/3/search_all_leagues.php?c=";

var comboPaises = document.getElementById("paises");
var comboDeportes = document.getElementById("deportes");
var contenido = document.getElementById("equipos");

function inicio() {
    obtenerPaises();
    obtenerDeportes();
    comboPaises.addEventListener("change", accion);
    comboDeportes.addEventListener("change", accion);

}

async function obtenerPaises() {
    const response= await fetch(url);
    const data = await response.json();

    for (let i = 0; i < data.countries.length; i++) {
        comboPaises.innerHTML = ''
    }
}

async function obtenerDeportes() {

}

function accion() {

}