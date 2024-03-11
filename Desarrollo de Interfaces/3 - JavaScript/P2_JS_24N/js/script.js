const cuerpo = document.body;

let contenedorPrincipal = document.createElement("div");
contenedorPrincipal.className = "container";

let contenedor = document.createElement("fieldset");
contenedor.className = "gallery";

let legenda = document.createElement("legend");
legenda.textContent = "Total";
contenedor.appendChild(legenda);

var Colores = ["Azul", "Rojo", "Naranja", "Verde"];
var idColores = ["blue", "red", "orange", "green"];

for (let i = 0; i < 20; i++) {
    let numAl = Math.floor(Math.random() * Colores.length);

    let boton = document.createElement("button");
    boton.textContent = Colores[numAl];
    boton.style.backgroundColor = idColores[numAl];

    contenedor.appendChild(boton);
}

contenedorPrincipal.appendChild(contenedor);
cuerpo.appendChild(contenedorPrincipal);
