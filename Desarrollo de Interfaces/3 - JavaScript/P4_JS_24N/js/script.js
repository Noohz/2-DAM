const partidos = ["PartidoA", "PartidoB", "PartidoC", "PartidoD"];
const sumaRepresen = [0, 0, 0, 0];
const sumaVotosTo = [0, 0, 0, 0];
const sumaProvincias = ["", "", "", ""];
var xhr = new XMLHttpRequest();

xhr.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
        var objeto = JSON.parse(this.responseText);
        objeto.forEach(recorrer);
        function recorrer(item, indice) {
            const votos = [Number(item.votosPA), Number(item.votosPB), Number(item.votosPC), Number(item.votosPD)]
            var mayor = -1;
            var pos = -1;
            for (let i = 0; i < votos.length; i++) {
                if (votos[i] >= mayor) {
                    mayor = votos[i];
                    pos = i;
                }
            }
            sumaRepresen[pos] += Number;
        }
    }
};
xhr.open("GET", "http://moralo.atwebpages.com/menuAjax/Provincias/getProvincias.php", true);
xhr.send();