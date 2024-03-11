window.onload = inicio;

var tarjetaFruta = document.getElementById("cajaX");

function inicio() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let objeto = JSON.parse(this.responseText);
            let tarjetasHTML = "";

            objeto.forEach(recorrer);

            function recorrer(fruta, indice) {
                tarjetasHTML +=
                    "<div class='card' style='width: 8rem;'>" +
                    "<img class='card-img-top' src=" + fruta.photo + " alt='IMGFRUTA' onclick='imagenClicada(" + indice + ")'>" +
                    "<div class='card-body'>" +
                    "<h5 class='card-title'>" + fruta.name + "</h5>" +
                    "<p class='card-text'>" + fruta.price + "</p>" +
                    "<p class='card-text'>" + fruta.stockActual + "</p>" +
                    "</div>" +
                    "</div>";
            }

            tarjetaFruta.innerHTML = tarjetasHTML;
        }
    }

    xhr.open("GET", "http://moralo.atwebpages.com/menuAjax/productos3/getProductos.php", true);
    xhr.send();
}


function imagenClicada(indice) {

    console.log("Imagen clicada. " + indice);
}
