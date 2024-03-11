//Llamamos al body del documento
const cuerpo = document.body;

//Declaramos el contenedor principal que es un div
let contenedorPrincipal = document.createElement("div");
contenedorPrincipal.className = "container";

//Creamos el segundo contenedor que va a tener la clase gallery
let contenedor = document.createElement("fieldset");

//Dos maneras de poner una clase a un elemento
//contenedor.setAttribute("class", "gallery");
contenedor.className = "gallery";

//Creamos la legenda propia del fieldset
let legenda = document.createElement("legend");
legenda.textContent = "Practica 8";

//Añadimos la legenda al fieldset
contenedor.appendChild(legenda);

let numBordes = 0;

//Hacemos un bucle para insertar las imágenes aleatorias
for (let i = 0; i < 20; i++) {

    let numRandom = Math.floor(Math.random() * 20) + 7;

    //Creamos el elemento img
    let imagen = document.createElement("img");
    //Le ponemos al elemento img sus atributos src
    imagen.setAttribute("src", "https://randomuser.me/api/portraits/men/" + numRandom + ".jpg");

    //Añadimos inicialmente evento mouseover
    imagen.onmouseover = function () {
        imagen.style.transform = "scale(1.5)";
    };

    //Añadimos inicialmente evento mouseleave
    imagen.onmouseleave = function () {
        imagen.style.transform = "scale(1)";
    };

    //Evento de click
    imagen.onclick = function () {

        if (imagen.className == "ponerBorde") {

            numBordes--;
            imagen.className = "quitarBorde";
            imagen.style.transform = "scale(1)";
            imagen.onmouseleave = function () {
                imagen.style.transform = "scale(1)";
            };

            imagen.onmouseover = function () {
                imagen.style.transform = "scale(1.5)";
            };

        } else if (imagen.className != "ponerBorde" && numBordes < 6) {

            numBordes++;
            imagen.className = "ponerBorde";
            //imagen.style.transform = "scale(1.5)";
            imagen.onmouseleave = function () { };
            imagen.onmouseover = function () { };

        }

        if (numBordes == 6) {

            let imagenesNuevas = document.querySelectorAll("img");

            imagenesNuevas.forEach(function (item, posicion) {

                if (item.className != "ponerBorde") {
                    item.onmouseover = function () { };

                    item.style.opacity = "0.5";

                }

            });

        } else {

            let imagenesNuevas = document.querySelectorAll("img");

            imagenesNuevas.forEach(function (item, posicion) {

                if (item.className != "ponerBorde") {
                    item.onmouseover = function () {
                        item.style.transform = "scale(1.5)";
                    };
                    item.style.opacity = "";
                }

            });

        }


    };

    //Añadimos la imagen ya creada al contenedor
    contenedor.appendChild(imagen);

}



contenedorPrincipal.appendChild(contenedor);
cuerpo.appendChild(contenedorPrincipal);

