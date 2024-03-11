// Si todo el dom se ha cargado correctamente al 100%
window.onload = inicio();

// Función inicio
// Booleana entra a true: el mejor de los casos, no va a haber errores.
// var = variable global, let = variable local
var bool = true;
function inicio() {
    // Recoger todo lo que hay en el formulario
    // Identificar los componentes html
    let expediente = document.getElementById("expediente").value;
    let nombre = document.getElementById("nombre").value;
    let apellidos = document.getElementById("apellidos").value;
    let dwec = document.getElementById("dwec").value;
    let dwes = document.getElementById("dwes").value;
    let ds = document.getElementById("ds").value;
    let eie = document.getElementById("eie").value;
    let diw = document.getElementById("diw").value;

    let smExpediente = document.getElementById("smExpediente");
    let smNombre = document.getElementById("smNombre");
    let smApellidos = document.getElementById("smApellidos");
    let smDwec = document.getElementById("smDwec");
    let smDwes = document.getElementById("smDwes");
    let smDs = document.getElementById("smDs");
    let smEie = document.getElementById("smEie");
    let smDiw = document.getElementById("smDiw");

    let btnAccion = document.getElementById("btnAccion");
    let accion = document.getElementById("accion");

    accion.onsubmit = function () {
        // Si alguno de los campos está vacio no se ejecuta el submit.
        if (expediente == "" || nombre == "" || apellidos == ""
            || dwec == "" || dwes == "" || ds == "" || eie == "" || diw == "") {
            bool = false;
            smExpediente.innerHTML = "*Campo Obligatorio";
            smNombre.innerHTML = "*Campo Obligatorio";
            smApellidos.innerHTML = "*Campo Obligatorio";
            smDwec.innerHTML = "*Campo Obligatorio";
            smDwes.innerHTML = "*Campo Obligatorio";
            smDs.innerHTML = "*Campo Obligatorio";
            smEie.innerHTML = "*Campo Obligatorio";
            smDiw.innerHTML = "*Campo Obligatorio";

        } else {
            console.log("entra en else");
            let cadena = String(expediente);
            if (cadena.length != 6) {
                bool = false;
                smExpediente.innerHTML = "* Cadena debe de tener 6 caracteres";
            } else {
                for (let i; i < cadena.length - 1; i++) {
                    let caracter = cadena.charAt(i);
                    if (isNaN(caracter)) { // isNaN -> is Not a Number
                        smExpediente.innerHTML = "* Los 5 primeros tienen que ser números"
                        bool = false;
                    }
                }
                let caracter = cadena.charAt(cadena.length - 1);
                if (!/[A-Z]/.test(caracter) && bool != false) {
                    console.log(caracter);
                    smExpediente.innerHTML = "* Último carácter letra mayúscula";
                    bool = false;
                }
                // Termina la validación del expediente

                // Comienza la validación de la calificaciones
                if (dwec < 1 || dwec > 10 && bool != false) {
                    bool = false;
                    smDwec.innerHTML = "* No cumple con el rango";
                }
                if (dwes < 0 || dwes > 10 && bool != false) {
                    bool = false;
                    smDwes.innerHTML = "* No cumple con el rango";
                }
                if (ds < 0 || ds > 10 && bool != false) {
                    bool = false;
                    smDs.innerHTML = "* No cumple con el rango";
                }
                if (eie < 0 || eie > 10 && bool != false) {
                    bool = false;
                    smEie.innerHTML = "* No cumple con el rango";
                }
                if (diw < 0 || diw > 10 && bool != false) {
                    bool = false;
                    smDiw.innerHTML = "* No cumple con el rango";
                }
            }

        }
        return bool;
    }
}