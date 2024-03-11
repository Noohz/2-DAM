// 2 arrays, 1 de codigo color y otro de nombres.
// Que coja uno aleatorio

let boton = document.getElementById("btn1").onclick = aleatorio;

let codColor = ["Red", "Yellow", "Orange", "Green", "Blue"];
let nombres = ["Rojo", "Amarillo", "Naranja", "Verde", "Azul"];


function aleatorio() {
    let contenedor = document.getElementById("c1");
    let num = Math.floor(Math.random() * codColor.length);
    contenedor.textContent = nombres[num];

    contenedor.style.color = nombres[num];
    contenedor.style.backgroundColor = codColor[num];
}