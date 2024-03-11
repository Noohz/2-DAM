window.onload = inicio;
var tabla = document.getElementById("cajaTabla");
var bloqueHTML = document.createElement("div");

function inicio() {
    let elemento = document.querySelector("#botonAdd");
    elemento.addEventListener("click", insertarFruta);

    console.log("entro en inicio");
    // Encabezamiento de la tabla HTML
    bloqueHTML.innerHTML = "<div class='row'>" +
        "<div class='col-lg-2 text-center'>ID</div>" +
        "<div class='col-lg-2 text-center'>NOMBRE</div>" +
        "<div class='col-lg-2 text-center'>PRECIO</div>" +
        "<div class='col-lg-2 text-center'>IMAGEN</div>" +
        "<div class='col-lg-2 text-center'>ELIMINAR</div>" +
        "<div class='col-lg-2 text-center'>MODIFICAR</div></div>";

    // Bloque de Ajax para extraer datos
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        // Controlar el estado de la petición de datos al servidor
        if (this.readyState == 4 && this.status == 200) {
            let objeto = JSON.parse(this.responseText);
            objeto.forEach(recorrer);

            function recorrer(fruta, indice) {
                const vector = (fruta.id, fruta.name, fruta.price, fruta.photo);
                console.log(vector)
                bloqueHTML.innerHTML += "<div class='row'>" +
                    "<div class='col-lg-2 text-center'>" + fruta.id + "</div>" +
                    "<div class='col-lg-2 text-center'>" + fruta.name + "</div>" +
                    "<div class='col-lg-2 text-center'>" + fruta.price + "</div>" +
                    "<div class='col-lg-2 text-center'><img src=" + fruta.photo + " width='80' height='90' </img></div>" +
                    // Con un href simulo un boton utilizando las clases btn btn-danger
                    // javascript:void(0) anula el link del ancla a
                    // Pero tengo que añadir el evento de javascript
                    "<div class='col-lg-2 text-center'><a href=javascript:void(0) " +
                    "class='btn btn-danger btn-md' onclick=eliminar(" + fruta.id + ")>Eliminar</a></div>" +
                    "<div class='col-lg-2 text-center'><a href=javascript:void(0) " +
                    "class='btn btn-info btn-md' onclick=modificar('" + vector + "')>Modificar </a></div></div>";
            }
        }
    }
    xhr.open("GET", "http://moralo.atwebpages.com/menuAjax/productos3/getProductos.php", true);
    xhr.send();
    console.log("bloqueHTML" + bloqueHTML)
    tabla.appendChild(bloqueHTML);
}

function eliminar(id) {
    console.log("item para eliminar" + id);
}

function modificar(fruta) {
    console.log("modificar: " + fruta);
}

function insertarFruta() {
    let idTxt = document.querySelector("#txtId").value;
    let nombreTxt = document.querySelector("#txtName").value;
    let precioTxt = document.querySelector("#txtPrecio").value;
    let imagenTxt = document.querySelector("#txtImagen").value;

    let btnConfirmar = document.querySelector("#btnInsertar");
    btnConfirmar.addEventListener("click", confirmacion);
    function confirmacion() {
        $.ajax({
            url:"http://moralo.atwebpages.com/menuAjax/productos3/insertarProductos.php",
            data: {
                id: idTxt,
                name: nombreTxt,
                price: precioTxt,
                photo: imagenTxt
            },
            method: "GET",
            typeof: "JSON",
        })
    }
}