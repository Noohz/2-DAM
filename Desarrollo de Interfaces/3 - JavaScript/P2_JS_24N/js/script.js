window.onload = inicio;

const componentes = [];
var contenedorAzul;
var contenedorVerde;
var contenedorRojo;
function inicio() {

    let boton = document.getElementById("mover");
    boton.onclick = mover;
    let contenedorBody = document.querySelector("body");
    let contenedorPrincipal = document.createElement("div");
    contenedorPrincipal.className = "container";

    //contenedores secundarios
    let contenedorTodos = document.createElement("fieldset");
    contenedorTodos.className = "gallery";
    let leyendaTodos = document.createElement("legend");
    leyendaTodos.textContent = "Total";
    contenedorTodos.appendChild(leyendaTodos);

    //contenedor azul
    contenedorAzul = document.createElement("fieldset");
    contenedorAzul.className = "gallery";
    let leyendaAzul = document.createElement("legend");
    leyendaAzul.textContent = "Azul";
    contenedorAzul.appendChild(leyendaAzul);

    //contenedores verde
    contenedorVerde = document.createElement("fieldset");
    contenedorVerde.className = "gallery";
    let leyendaVerde = document.createElement("legend");
    leyendaVerde.textContent = "Verde";
    contenedorVerde.appendChild(leyendaVerde);

    //contenedores Rojo
    contenedorRojo = document.createElement("fieldset");
    contenedorRojo.className = "gallery";
    let leyendaRojo = document.createElement("legend");
    leyendaRojo.textContent = "Rojo";
    contenedorRojo.appendChild(leyendaRojo);

    contenedorBody.appendChild(contenedorTodos);
    contenedorBody.appendChild(contenedorRojo);
    contenedorBody.appendChild(contenedorVerde);
    contenedorBody.appendChild(contenedorAzul);

    for (let i = 0; i < 20; i++) {

        let contenedor = document.createElement("div");
        contenedor.className = "gallery div";
        contenedor.style.width = "100 px";
        contenedor.style.height = "50 px";

        let n = Math.floor(Math.random() * 3);

        switch (n) {

            case 0:

                contenedor.style.backgroundColor = "blue";
                contenedor.textContent = "Azul";

                break;

            case 1:

                contenedor.style.backgroundColor = "green";
                contenedor.textContent = "Verde";

                break;

            case 2:

                contenedor.style.backgroundColor = "red";
                contenedor.textContent = "Rojo";

                break;
        }

        componentes.push(contenedor);
        contenedorTodos.appendChild(contenedor);
    }
}

function mover() {

    componentes.forEach(recorrer);

    function recorrer(item, indice) {

        if (item.textContent == "Azul") {

            contenedorAzul.appendChild(item);

        } else if (item.textContent == "Rojo") {

            contenedorRojo.appendChild(item);

        } else if (item.textContent == "Verde") {

            contenedorVerde.appendChild(item);
        }
    }
}