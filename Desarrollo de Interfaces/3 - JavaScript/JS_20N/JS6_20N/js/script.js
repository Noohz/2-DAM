window.addEventListener("load", inicio);


function inicio() {
    var imagenReferencia;
    let contenedorP = document.createElement("div");
    contenedorP.className = "container";
    let cuerpo = document.querySelector("body");
    cuerpo.appendChild(contenedorP);
    let contenedorR = document.createElement("div");
    contenedorR.className = "gallery";
    contenedorP.appendChild(contenedorR);
    let contenedorS = document.createElement("fieldset");
    contenedorS.className = "gallery";
    let texto = document.createElement("legend");

    texto.textContent = "Práctica 6_ 20N";

    contenedorS.appendChild(texto);
    contenedorP.appendChild(contenedorS);


    refrescar();

    var segundos = 30;
    var temporizador = setInterval(refrescar, 10000);

    function refrescar() {
        contenedorS.innerHTML = "";
        contenedorR.innerHTML = "";
        /**  let arrayImg = document.querySelectorAll("img");
         console.log(arrayImg);
         arrayImg.forEach(function (item, indice) {
             contenedorS.removeChild(item);
         }
         )*/
        ;
        var contadorBordes = 0;

        cargarImagenReferencia();
        for (let i = 0; i < 20; i++) {
            let num1 = Math.floor(Math.random() * 20);
            let rutaH = "https://randomuser.me/api/portraits/men/";
            let rutaM = "https://randomuser.me/api/portraits/women/";

            let imagen = document.createElement("img");
            imagen.className = "gallery img";
            contenedorS.appendChild(imagen);
            if (i % 2 == 0) {
                imagen.src = rutaH + num1 + ".jpg";

            } else {
                imagen.src = rutaM + num1 + ".jpg";
            }

            //imagen.onmouseover = expandir;
            //imagen.onmouseleave = encoger;
            // imagen.onclick = borde;
            imagen.onclick = comparar;

            function comparar() {
                console.log(imagen.getAttribute("src"));
                console.log("imagen de Referencia: " + imagenReferencia);
                let imagenSelec = imagen.getAttribute("src");
                let imagenRef = imagenReferencia;

                if (imagenSelec == imagenRef) {
                    alert("Acierto");
                } else {
                    alert("Error");
                }
            }
            function expandir() {
                imagen.style.transform = "scale(1.5)";
            }

            function encoger() {
                imagen.style.transform = "scale(1)";
            }

            function borde() {
                if (imagen.className == "ponerBorde") {
                    imagen.className = "quitarBorde";
                    contadorBordes--;
                    console.log(contadorBordes);

                } else {
                    if (contadorBordes == 6) {
                        return;
                    }
                    imagen.className = "ponerBorde";
                    contadorBordes++;
                    console.log(contadorBordes);

                }

                if (contadorBordes == 6) {
                    console.log("Desactivación de Bordes Operativa");
                    let arrayImg = document.querySelectorAll("img");
                    console.log(arrayImg);
                    arrayImg.forEach(function (item, indice) {
                        item.disabled = "true";
                    }
                    )
                        ;
                }
            }
        }
    }

    function cargarImagenReferencia() {
        let rutaH = "https://randomuser.me/api/portraits/men/";
        let rutaM = "https://randomuser.me/api/portraits/women/";
        let num3 = Math.floor(Math.random() * 20);
        let imagenR = document.createElement("img");
        imagenR.className = "gallery img";
        let num2 = Math.round(Math.random() * 2);
        if (num2 == 1) {
            imagenR.src = rutaM + num3 + ".jpg";
        } else {
            imagenR.src = rutaH + num3 + ".jpg";
        }

        contenedorR.appendChild(imagenR);
        imagenReferencia = imagenR.src;
    }

}