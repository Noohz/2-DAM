let boton = document.getElementById("btn1").onclick = crono;

function crono() {
    btn1.setAttribute("disabled", true);
    let codColor = ["Red", "Yellow", "Orange", "Green", "Blue"];
    let nombres = ["Rojo", "Amarillo", "Naranja", "Verde", "Azul"];

    setInterval(cambiar, 1000);
    function cambiar() {
        let contenedor = document.getElementById("c1");
        let num = Math.floor(Math.random() * codColor.length);
        let num2 = Math.floor(Math.random() * nombres.length);
        
        contenedor.textContent = nombres[num2];
        contenedor.style.backgroundColor = codColor[num];

        contenedor.onclick = comprobar;
        
        function comprobar() {
            if (num == num2 ) {
                alert("Acierto")
            } else {
                alert("Fallo")
            }
        }

    }    
}