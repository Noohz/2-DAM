let boton = document.getElementById("btn1").onclick = aleatorio; // Elemento donde se va a ejecutar el evento onclick

function aleatorio() {
    let contenedor = document.getElementById("c1"); // Elemento donde se va a depositar el contenido.
    contenedor.textContent = Math.round(Math.random()*10);
}