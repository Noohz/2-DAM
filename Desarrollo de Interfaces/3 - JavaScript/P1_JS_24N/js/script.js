window.onload = inicio;
var intervalo1 = setInterval(video1, 3000);
var tbody = document.getElementsByTagName("tbody");

function inicio() {

    video1();
}
function video1() {
    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var objeto = JSON.parse(this.responseText);
            let divParrafo = document.getElementById("parrafo");

            let dato = objeto.length;
            let numAleatorio = Math.floor(Math.random() * dato);

            divParrafo.innerHTML = "<video  src='" + objeto[numAleatorio].url + "' width = '500' height = '300' controls autoplay loop ></video>";
        }
    };
    xhr.open("GET", "http://camacho.atwebpages.com/webcam/getWebcam.php", true);
    xhr.send();
}

function cargarTabla() {
    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var objeto = JSON.parse(this.responseText);
            let divParrafo = document.getElementById("parrafo");

            let dato = objeto.length;
            objeto.forEach(recorrer);
            function recorrer(item, index) {
                let fila = document.createElement("tr");
                const ciudad = [item.ciudad_nombre, item.ciudad_poblacion, item.video, item.imagen, item.ciudad_ID];
                for (let i = 0; i < ciudad.length; i++) {
                    // fila.innerHTML += "<td scope='col'>" + ciudad[i] + "</td>"
                    let columna = document.createElement("td");
                    columna.appendChild(ciudad[i]);
                    fila.appendChild(columna);
                }
                tbody.appendChild(fila);
            }
        }
    };
    xhr.open("GET", "http://camacho.atwebpages.com/carouselCiudades2/getCiudades.php", true);
    xhr.send();
}
