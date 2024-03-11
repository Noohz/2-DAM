// Lo mismo que el anterior pero que haya 6 divs
// El evento onclick que dice si aciertas o no puede aparecer en cualquiera
// Identificamos el class del div para el evento

console.log("entro ej js")
var btnActivar = document.getElementById("btn1");
btnActivar.onclick = funcion1;

function funcion1() {
    btnActivar.setAttribute("disabled", true)
    const vector = ["red", "green", "blue", "orange", "pink", "yellow"]
    const vectorN = ["Rojo", "Verde", "Azul", "Naranja", "Rosa", "Amarillo"]
    setInterval(cambio, 1000);
    function cambio() {

        const cajas = document.querySelectorAll(".caja");
        console.log("cajas: " + cajas)
        cajas.forEach(recorrer);
        function recorrer(item, index) {
            let posicion1 = Math.floor(Math.random() * vector.length);
            let posicion2 = Math.floor(Math.random() * vector.length);
            item.style.backgroundColor = vector[posicion1]
            item.textContent = vectorN[posicion2];
        }
    }
}
