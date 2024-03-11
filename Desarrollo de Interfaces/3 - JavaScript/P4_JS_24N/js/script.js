window.onload = inicio;

const cuerpo = document.body;

var contenedor = document.createElement("div");

function inicio() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let objeto = JSON.parse(this.responseText);
            let res = "";
            let votosTotales = "";
            objeto.forEach(recorrer);

            function recorrer(congreso, indice) {
                let ganador;
                if (congreso.votosPA > congreso.votosPB && congreso.votosPA > congreso.votosPC && congreso.votosPA > congreso.votosPD) {
                    ganador = congreso.votosPA;
                    votosTotales = congreso.votosPA + congreso.votosPB + congreso.votosPC + congreso.votosPD;
                } else if (congreso.votosPB > congreso.votosPA && congreso.votosPB > congreso.votosPC && congreso.votosPB > congreso.votosPD) {
                    ganador = congreso.votosPB;
                    votosTotales = congreso.votosPA + congreso.votosPB + congreso.votosPC + congreso.votosPD;
                } else if (congreso.votosPC > congreso.votosPA && congreso.votosPC > congreso.votosPB && congreso.votosPC > congreso.votosPD) {
                    ganador = congreso.votosPC;
                    votosTotales = congreso.votosPA + congreso.votosPB + congreso.votosPC + congreso.votosPD;
                } else if (congreso.votosPD > congreso.votosPA && congreso.votosPD > congreso.votosPB && congreso.votosPD > congreso.votosPC) {
                    ganador = congreso.votosPD;
                    votosTotales = congreso.votosPA + congreso.votosPB + congreso.votosPC + congreso.votosPD;
                }

                res +=
                    "<a>Partido " + congreso.nombreProvincia + ": " + congreso.Representantes + " Representantes <br></a><br>"
            }
            cuerpo.innerHTML = res;
        }
    }
    xhr.open("GET", "http://moralo.atwebpages.com/menuAjax/Provincias/getProvincias.php", true);
    xhr.send();
}

