// Random entre 1 y 1000
// Si el numero es mayor que 500 fondo amarillo
// Si el numero es menor que 500 fondo verde 

let boton = document.getElementById("btn1").onclick = aleatorio; // Elemento donde se va a ejecutar el evento onclick
let num;

function aleatorio() {
    let contenedor = document.getElementById("c1"); // Elemento donde se va a depositar el contenido.
    contenedor.textContent = Math.round(Math.random()*1000);
    num = contenedor.textContent; // Le asignamos el contenido del contenedor donde estaba el número a la variable nueva

    if (num > 500) {
        contenedor.style.backgroundColor = "Yellow";
        contenedor.style.color = "Blue";
    } else {
        contenedor.style.color = "Red";
        contenedor.style.backgroundColor = "Green";
    }
}