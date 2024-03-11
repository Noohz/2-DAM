import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'AngCalc';
  visor:string="";
  guardar:number=0;
  vectorN:number[] | undefined;
  vectorO:string[]|undefined;
  arrastra:boolean=false;
  operador:number=0;
  operar(valor:string) {
   if (Number(valor)>=0){
    console.log("entro en número")
    this.visor+=Number(valor);

   }else
   {
    switch(valor){
      case "-1":{
        if (this.arrastra==true){
          this.visor=String(this.guardar/Number(this.visor));
          this.guardar=Number(this.visor);
          this.visor="";

        }else{
          this.guardar=Number(this.visor);
          this.visor="";
          console.log(this.guardar);
          this.arrastra=true;
          this.operador=-1;
        }

        break;
      }
      case "-2":{
        if (this.arrastra==true){
          this.visor=String(Number(this.visor)*this.guardar);
          this.guardar=Number(this.visor);
          this.visor="";

          console.log("operador acciona"+this.operador)
        }else{
          this.guardar=Number(this.visor);
          this.visor="";
          console.log("guardando numero: "+this.guardar);
          this.arrastra=true;
          this.operador=-2;
        }

        break;
      }
      case "-3":{
        if (this.arrastra==true){
          console.log("entro en sumar guardar");
          this.visor=String(Number(this.visor)+this.guardar);
          this.guardar=Number(this.visor);
          this.visor="";

        }else{
          this.guardar=Number(this.visor);
          this.visor="";
          console.log(this.guardar);
          this.arrastra=true;
          this.operador=-3;
        }

        break;

      }
      case "-4":{
        if (!this.visor.includes("."))
        {this.visor+=".";}
        break;
      }
      case "-5":{
        console.log("entro en igual");
        console.log("operador "+this.operador);
        if (this.operador==-1){
          this.visor=String(this.guardar/Number(this.visor));
          this.guardar=0;
        }
        if (this.operador==-2){
          this.visor=String(Number(this.visor)*this.guardar);
          console.log("operacion:" +this.visor);
          this.guardar=0;
        }
        if (this.operador==-3){
          this.visor=String(Number(this.visor)+this.guardar);
          this.guardar=0;
        }
        if (this.operador==-6){
          this.visor=String(this.guardar-Number(this.visor));
          this.guardar=0;
        }


         this.guardar=Number(this.visor);
         this.arrastra=false;
         break;

      }
      case "-6":{
        if (this.arrastra==true){
          console.log("restando");
          this.visor=String(Number(this.visor)-this.guardar);
          this.guardar=Number(this.visor);
          this.visor="";
        }else{
          this.guardar=Number(this.visor);
          this.visor="";
          console.log(this.guardar);
          this.arrastra=true;
        }
        this.operador=-6;
        break;
      }

      case "-7":{
        console.log("entro en 7")
        this.visor="";
        this.arrastra=false;
        this.guardar=0;
        this.operador=0;
        break;
      }
      case "-8":{
        this.visor="";
        break;
      }

    }
   }
  }

}

