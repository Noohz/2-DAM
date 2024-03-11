document.getElementById("btn1").addEventListener("click",funcion1);
function funcion1(){


let numeroX=Math.round(Math.random()*10);
   console.log("entro f4");
    let intentos=0;
    let fin=false;
    while(!fin){
        let numeroMio=prompt("¿Cuál es el número X?");
        intentos++;
        if (parseInt(numeroX)==parseInt(numeroMio)){
            fin=true;
            alert("Aciertas!!!!!")
            with (document.getElementById("c1")){
                innerHTML="Intentos:<br>"+intentos;
                style.backgroundColor="orange";
                style.fontSize="35px";
            }
      
        }else    if (parseInt(numeroX)>parseInt(numeroMio)){
            alert("más alto")
        }else{
            alert("más bajo")
        }
    }
}