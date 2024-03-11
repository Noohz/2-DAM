//vector de colores para el fondo
const colores = ['#FF0000','#00FF00','#0000FF','#FFFF00','#FF69B4','#FFA500'];
//vector texto
const nombres=["Rojo","Verde","Azul","Amarillo","Rosa","Naranja"];
//identificar el botón de comienzo
var boton1=document.getElementById("btn1");
//random para sacar el color de fondo del botón comienzo
let num1 = Math.floor(Math.random()*5);
boton1.style.backgroundColor = colores[num1];
//evento
var contadorAciertos=0;
boton1.addEventListener("click",funcion1);


function funcion1(){
    //deshabilitar el botón inicio
    boton1.setAttribute("disabled",true);
    //vector de las cajas internas
    let vectorCaja = document.getElementsByClassName("caja");
    //llamar al método del juego colores
    accionRandom();
    //llamar al método de juegos cada 5 segundos
    intervalo2 = setInterval(accionRandom, 5000);
    
    function accionRandom(){
        //recorrer todos los elementos pertenciente a la
        //clase .caja
        for(let elemento of vectorCaja){
            let num1 = Math.floor(Math.random()*5);
            //cambiar el estilo random a c1, c2, c3, c4...
            elemento.style.backgroundColor = colores[num1];
            //poner color black a la fuente del contenido c1,
            elemento.style.color="black";
            //random para el texto
            let num2=Math.floor(Math.random()*5)
            elemento.style.fontSize="50px";
            //nombre del texto de c1, c2, c3...
            elemento.innerHTML=nombres[num2];
            //evento sobre cada una de las cajas
            //del bloque
            elemento.onclick=function(){
                if (num1==num2){
                   //si hago click sobre el botón
                   //y además coinciden sus códigos random
                   //acierto
                    elemento.style.backgroundColor="Black";
                    elemento.innerText="okkkkk";
                    elemento.style.color="white";
                    contadorAciertos++;
                    if (contadorAciertos==10){
                        clearInterval(intervalo2);
                        alert("fin partida. 10 aciertos")
                    }
                }else{
                     //si hago click sobre el botón
                   //y además NO coinciden sus códigos random
                   //error
                    elemento.style.backgroundColor="white";
                    elemento.innerText="errrrror";
                    elemento.style.color="red";
                }
            }
        }

    }


}